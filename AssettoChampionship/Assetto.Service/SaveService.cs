﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Interfaces.Service;
using Assetto.Common.Output;
using Assetto.Common.ProcessedResult;
using Assetto.Common.SaveGames;
using Newtonsoft.Json;

namespace Assetto.Service
{
    public class SaveService : ISaveService
    {
        public const string RESULT_DIR = "Data";
        public const string RESULT_FILE_NAME = "Data.dat";

        public List<SaveCache> CachedSave { get; set; }

        public IFileService FileService { get; set; }

        public SaveService(IFileService fileService)
        {
            this.CachedSave = new List<SaveCache>();
            this.FileService = fileService;
        }

        private void SaveCache(SavedSeason save)
        {
            var cacheForSeries = this.CachedSave.FirstOrDefault(cs => cs.SeasonId == save.SeasonId);
            if (cacheForSeries == null)
            {
                this.CachedSave.Add(new SaveCache()
                {
                    SeasonId = save.SeasonId,
                    Save = save
                });
            }
            else
            {
                cacheForSeries.Save = save;
            }
        }

        private SaveCache LoadCache(string seriesId)
        {
            return CachedSave.FirstOrDefault(cs => cs.SeasonId == seriesId);
        }

        public SavedSeason SaveResult(string seasonId, string eventId, string sessionId, Result result)
        {
            SavedSeason seasonResults = null;
            if (!CreateResultFileIfNotExist(seasonId))
            {
                // File already existed   
                seasonResults = LoadResultFile(seasonId);
            }
            else
            {
                seasonResults = CreateSavedSeason(seasonId, eventId, sessionId, result);
            }
            seasonResults = InsertOrUpdateResult(seasonResults, eventId, sessionId, result);
            SaveResult(seasonResults);
            this.SaveCache(seasonResults);
            return seasonResults;
        }


        public SavedSeason InsertOrUpdateResult(SavedSeason savedSeason, string eventId, string sessionId, Result result)
        {
            if (SavedSeasonContainsSession(savedSeason, eventId, sessionId))
            {
                savedSeason = UpdateResult(savedSeason, eventId, sessionId, result);
            }
            else
            {
                savedSeason = InsertResult(savedSeason, eventId, sessionId, result);
            }
            return savedSeason;
        }

        public SavedSeason InsertResult(SavedSeason savedSeason, string eventId, string sessionId, Result result)
        {
            if (!savedSeason.SavedEventResults.ContainsKey(eventId))
            {
                savedSeason.SavedEventResults[eventId] = new SavedEventResult()
                {
                    EventId = eventId,
                    SessionResult = new Dictionary<string, Result>()
                };
            }

            if (savedSeason.SavedEventResults[eventId].SessionResult.ContainsKey(sessionId)
                && savedSeason.SavedEventResults[eventId].SessionResult[sessionId] != null
            )
                throw new Exception("The result is already exist in the season.");

            StoreResult(savedSeason, eventId, sessionId, result);
            return savedSeason;
        }

        public SavedSeason UpdateResult(SavedSeason savedSeason, string eventId, string sessionId, Result result)
        {
            if (!savedSeason.SavedEventResults[eventId].SessionResult.ContainsKey(sessionId)
                //|| savedSeason.SavedEventResults[eventId].SessionResult[sessionId] == null
            )
                throw new Exception("The result does not exist in the season.");

            StoreResult(savedSeason, eventId, sessionId, result);
            return savedSeason;

        }

        public SavedSeason StoreResult(SavedSeason savedSeason, string eventId, string sessionId, Result result)
        {
            result.Id = sessionId;
            savedSeason.SavedEventResults[eventId].SessionResult[sessionId] = result;
            return savedSeason;
        }

        public bool SavedSeasonContainsSession(SavedSeason savedSeason, string eventId, string sessionId)
        {
            if (savedSeason == null 
                || savedSeason.SavedEventResults == null
                || !savedSeason.SavedEventResults.ContainsKey(eventId)
                || (savedSeason.SavedEventResults.ContainsKey(eventId)
                    && savedSeason.SavedEventResults[eventId] == null)) return false;

            if (savedSeason.SavedEventResults[eventId].SessionResult == null
                || !savedSeason.SavedEventResults[eventId].SessionResult.ContainsKey(sessionId)
                || (savedSeason.SavedEventResults[eventId].SessionResult.ContainsKey(sessionId)
                    && savedSeason.SavedEventResults[eventId].SessionResult[sessionId] == null)) return false;

            return true;
        }

        private SavedSeason CreateSavedSeason(string seasonId, string eventId, string sessionId, Result result)
        {
            var savedEventResult = new SavedEventResult()
            {
                EventId = eventId,
                SessionResult = new Dictionary<string, Result>()
                {
                    {sessionId, result}
                }
            };


            return new SavedSeason()
            {
                SeasonId = seasonId
                ,
                SavedEventResults = new Dictionary<string, SavedEventResult>()
                {
                    {eventId, savedEventResult}

                }
            };
        }

        public SavedSeason GetSavedSeason(string seasonId)
        {
            try
            {
                return LoadResultFile(seasonId);
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public Result LoadResult(string seasonId, string eventId, string sessionId)
        {
            try
            {
                var saveCache = LoadCache(seasonId);
                if (saveCache != null)
                {
                    // Already cached, returns saved game or null
                    if (saveCache.Save == null
                        || !saveCache.Save.SavedEventResults.Keys.Contains(eventId)
                        || !saveCache.Save.SavedEventResults[eventId].SessionResult.Keys.Contains(sessionId)) return null;
                    return saveCache.Save.SavedEventResults[eventId].SessionResult[sessionId];
                }
                else
                {
                    // Not cached yet, reads it.
                    SavedSeason savedSeason = null;
                    try
                    {
                        savedSeason = LoadResultFile(seasonId);
                        this.SaveCache(savedSeason);
                        return savedSeason.SavedEventResults[eventId].SessionResult[sessionId];
                    }
                    catch (Exception)
                    {
                        savedSeason = new SavedSeason() { SeasonId = seasonId, SavedEventResults = new Dictionary<string, SavedEventResult>() };
                        this.SaveCache(savedSeason);
                        return null;
                    }

                }

            }
            catch (Exception)
            {
                //TODO
                return null;
                //throw;
            }
        }


        private SavedSeason LoadResultFile(string seasonId)
        {
            var text = this.FileService.ReadFile(
                RESULT_DIR
                + Path.DirectorySeparatorChar + seasonId
                + Path.DirectorySeparatorChar + RESULT_FILE_NAME);

            return JsonConvert.DeserializeObject<SavedSeason>(text);

        }


        private bool CreateResultFileIfNotExist(string seasonId)
        {
            // Create result dir if not exists
            this.FileService.CreateDirIfNotExist(RESULT_DIR);

            var dirPath = RESULT_DIR
                 + Path.DirectorySeparatorChar + seasonId;

            // Create season result dir if not exists
            this.FileService.CreateDirIfNotExist(dirPath);

            var filePath = dirPath
                           + Path.DirectorySeparatorChar + RESULT_FILE_NAME;

            // Create season result file if not exists
            return this.FileService.CreateResultFileIfNotExist(filePath, "{}");
        }

        private bool SaveResult(SavedSeason savegame)
        {
            var filePath =
                RESULT_DIR
                + Path.DirectorySeparatorChar + savegame.SeasonId
                + Path.DirectorySeparatorChar + RESULT_FILE_NAME;
            this.FileService.WriteFile(filePath, JsonConvert.SerializeObject(savegame, Formatting.Indented));
            return true;
        }
    }
}
