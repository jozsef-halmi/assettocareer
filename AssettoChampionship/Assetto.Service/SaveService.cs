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

        public IFileService FileService { get; set; }

        public SaveService(IFileService fileService)
        {
            this.FileService = fileService;
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
                seasonResults = CreateSavedSeason(sessionId, eventId, sessionId, result);
            }
            InsertOrUpdateResult(seasonResults, eventId, sessionId, result);
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
            if (savedSeason.SavedEventResults[eventId].SessionResult[sessionId] != null)
                throw new Exception("The result is already exist in the season.");

            StoreResult(savedSeason, eventId, sessionId, result);
            return savedSeason;
        }

        public SavedSeason UpdateResult(SavedSeason savedSeason, Guid eventId, Guid sessionId, Result result)
        {
            if (savedSeason.SavedEventResults[eventId].SessionResult[sessionId] == null)
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

        private bool SavedSeasonContainsSession(SavedSeason savedSeason, Guid eventId, Guid sessionId)
        {
            if (savedSeason.SavedEventResults[eventId] == null) return false;

            if (savedSeason.SavedEventResults[eventId].SessionResult[sessionId] == null) return false;

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


        public Result LoadResult(Guid seasonId, Guid eventId, Guid sessionId)
        {
            try
            {
                var savedSeason = LoadResultFile(seasonId);
                return savedSeason.SavedEventResults[eventId].SessionResult[sessionId];
            }
            catch (Exception)
            {
                //TODO
                throw;
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
            return this.FileService.CreateResultFileIfNotExist(filePath);
        }
    }
}
