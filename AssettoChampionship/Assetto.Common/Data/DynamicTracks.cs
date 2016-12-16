﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Data
{
    public static class DynamicTracks
    {
        public static DynamicTrackData Dusty = new DynamicTrackData() {
            Preset = 0,
            LapGain = 30,
            Randomness = 1,
            SessionStart = 86,
            SessionTransfer = 50
        };

        public static DynamicTrackData Old = new DynamicTrackData()
        {
            Preset = 1,
            LapGain = 50,
            Randomness = 3,
            SessionStart = 89,
            SessionTransfer = 80
        };

        public static DynamicTrackData Slow = new DynamicTrackData()
        {
            Preset = 2,
            LapGain = 300,
            Randomness = 1,
            SessionStart = 96,
            SessionTransfer = 80
        };

        public static DynamicTrackData Green = new DynamicTrackData()
        {
            Preset = 3,
            LapGain = 132,
            Randomness = 2,
            SessionStart = 95,
            SessionTransfer = 90
        };

        public static DynamicTrackData Fast = new DynamicTrackData()
        {
            Preset = 4,
            LapGain = 700,
            Randomness = 2,
            SessionStart = 98,
            SessionTransfer = 80
        };

        public static DynamicTrackData Optimum = new DynamicTrackData()
        {
            Preset = 5,
            LapGain = 1,
            Randomness = 0,
            SessionStart = 100,
            SessionTransfer = 100
        };
    }
}
