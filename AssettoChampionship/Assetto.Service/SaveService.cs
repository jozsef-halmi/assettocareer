using System;
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

        private SaveCache LoadCache(Guid seriesId)
        {
            return CachedSave.FirstOrDefault(cs => cs.SeasonId == seriesId);
        }

        public SavedSeason SaveResult(Guid seasonId, Guid eventId, Guid sessionId, Result result)
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


        public SavedSeason InsertOrUpdateResult(SavedSeason savedSeason, Guid eventId, Guid sessionId, Result result)
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

        public SavedSeason InsertResult(SavedSeason savedSeason, Guid eventId, Guid sessionId, Result result)
        {
            if (!savedSeason.SavedEventResults.ContainsKey(eventId))
            {
                savedSeason.SavedEventResults[eventId] = new SavedEventResult()
                {
                    EventId = eventId,
                    SessionResult = new Dictionary<Guid, Result>()
                };
            }

            if (savedSeason.SavedEventResults[eventId].SessionResult.ContainsKey(sessionId)
                && savedSeason.SavedEventResults[eventId].SessionResult[sessionId] != null
            )
                throw new Exception("The result is already exist in the season.");

            StoreResult(savedSeason, eventId, sessionId, result);
            return savedSeason;
        }

        public SavedSeason UpdateResult(SavedSeason savedSeason, Guid eventId, Guid sessionId, Result result)
        {
            if (!savedSeason.SavedEventResults[eventId].SessionResult.ContainsKey(sessionId)
                //|| savedSeason.SavedEventResults[eventId].SessionResult[sessionId] == null
            )
                throw new Exception("The result does not exist in the season.");

            StoreResult(savedSeason, eventId, sessionId, result);
            return savedSeason;

        }

        public SavedSeason StoreResult(SavedSeason savedSeason, Guid eventId, Guid sessionId, Result result)
        {
            result.Id = sessionId;
            savedSeason.SavedEventResults[eventId].SessionResult[sessionId] = result;
            return savedSeason;
        }

        public bool SavedSeasonContainsSession(SavedSeason savedSeason, Guid eventId, Guid sessionId)
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

        private SavedSeason CreateSavedSeason(Guid seasonId, Guid eventId, Guid sessionId, Result result)
        {
            var savedEventResult = new SavedEventResult()
            {
                EventId = eventId,
                SessionResult = new Dictionary<Guid, Result>()
                {
                    {sessionId, result}
                }
            };


            return new SavedSeason()
            {
                SeasonId = seasonId
                ,
                SavedEventResults = new Dictionary<Guid, SavedEventResult>()
                {
                    {eventId, savedEventResult}

                }
            };
        }

        public SavedSeason GetSavedSeason(Guid seasonId)
        {
            try
            {
                return LoadResultFile(seasonId);
            }
            catch (Exception)
            {
                // TODO: Log
                return null;
            }
            
        }

        public Result LoadResult(Guid seasonId, Guid eventId, Guid sessionId)
        {
            try
            {
                var saveCache = LoadCache(seasonId);
                if (saveCache != null && saveCache.Save == null)
                {
                    var savedSeason = LoadResultFile(seasonId);
                    saveCache.Save = savedSeason;
                    return savedSeason.SavedEventResults[eventId].SessionResult[sessionId];
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                //TODO
                return null;
                //throw;
            }
        }


        private SavedSeason LoadResultFile(Guid seasonId)
        {
            var text = this.FileService.ReadFile(
                RESULT_DIR
                + Path.DirectorySeparatorChar + seasonId
                + Path.DirectorySeparatorChar + RESULT_FILE_NAME);

            return JsonConvert.DeserializeObject<SavedSeason>(text);

        }


        private bool CreateResultFileIfNotExist(Guid seasonId)
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
