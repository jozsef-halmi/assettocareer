﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.DTO
{
    public class EventDTO
    {
        public string EventId { get; set; }
        public string SeriesId { get; set; }


        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public bool IsAvailable { get; set; }



        public string Track { get; set; }



        public string Layout { get; set; }

        public bool IsLayoutAvailable => !string.IsNullOrEmpty(Layout);
        public int SessionsCount { get; set; }

        public List<SessionDTO> Sessions { get; set; }

        public bool IsCarMissing { get; set; }
        public bool IsTrackMissing { get; set; }

    }
}
