using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Service.Tests.Data
{
    public static class TestData
    {
        public static string QualifyOutputLog_PlayerWithoutTime = @"{
	""track"": ""magione"",
	""number_of_sessions"": 1,
	""players"": [{
		""name"": ""PlayerWithoutTime"",
		""car"": ""ks_abarth500_assetto_corse"",
		""skin"": ""0_official""
	}, {
		""name"": ""Jazmine Hermanson"",
		""car"": ""ks_abarth500_assetto_corse"",
		""skin"": ""orange_grey""
	}, {
		""name"": ""Kendal Buckley"",
		""car"": ""ks_abarth500_assetto_corse"",
		""skin"": ""racing_500""
	}, {
		""name"": ""Erlend Braband"",
		""car"": ""ks_abarth500_assetto_corse"",
		""skin"": ""light_blue_orange""
	}, {
		""name"": ""Kurtis Nadeau"",
		""car"": ""ks_abarth500_assetto_corse"",
		""skin"": ""black_neon""
	}, {
		""name"": ""Darell Hoyt"",
		""car"": ""ks_abarth500_assetto_corse"",
		""skin"": ""silver_red""
	}],
	""sessions"": [{
		""event"": 0,
		""name"": ""Qualifying"",
		""type"": 2,
		""lapsCount"": 0,
		""duration"": 10,
		""laps"": [{
			""lap"": 0,
			""car"": 1,
			""sectors"": [78026, 38898],
			""time"": 116924
		}, {
			""lap"": 1,
			""car"": 1,
			""sectors"": [49525, 38867],
			""time"": 88392
		}, {
			""lap"": 2,
			""car"": 1,
			""sectors"": [49077, 127610],
			""time"": 176687
		}, {
			""lap"": 3,
			""car"": 1,
			""sectors"": [53593, 39074],
			""time"": 92667
		}, {
			""lap"": 4,
			""car"": 1,
			""sectors"": [49247, 39097],
			""time"": 88344
		}, {
			""lap"": 5,
			""car"": 1,
			""sectors"": [48933, 38943],
			""time"": 87876
		}, {
			""lap"": 0,
			""car"": 2,
			""sectors"": [69972, 38979],
			""time"": 108951
		}, {
			""lap"": 1,
			""car"": 2,
			""sectors"": [49355, 39033],
			""time"": 88388
		}, {
			""lap"": 2,
			""car"": 2,
			""sectors"": [49593, 38754],
			""time"": 88347
		}, {
			""lap"": 3,
			""car"": 2,
			""sectors"": [49446, 38969],
			""time"": 88415
		}, {
			""lap"": 4,
			""car"": 2,
			""sectors"": [48931, 39038],
			""time"": 87969
		}, {
			""lap"": 0,
			""car"": 3,
			""sectors"": [88134, 38862],
			""time"": 126996
		}, {
			""lap"": 1,
			""car"": 3,
			""sectors"": [49032, 38924],
			""time"": 87956
		}, {
			""lap"": 2,
			""car"": 3,
			""sectors"": [49539, 117882],
			""time"": 167421
		}, {
			""lap"": 3,
			""car"": 3,
			""sectors"": [54058, 39055],
			""time"": 93113
		}, {
			""lap"": 4,
			""car"": 3,
			""sectors"": [49619, 38854],
			""time"": 88473
		}, {
			""lap"": 0,
			""car"": 4,
			""sectors"": [144496, 38857],
			""time"": 183353
		}, {
			""lap"": 1,
			""car"": 4,
			""sectors"": [48967, 38884],
			""time"": 87851
		}, {
			""lap"": 2,
			""car"": 4,
			""sectors"": [49367, 39223],
			""time"": 88590
		}, {
			""lap"": 0,
			""car"": 5,
			""sectors"": [155413, 39173],
			""time"": 194586
		}, {
			""lap"": 1,
			""car"": 5,
			""sectors"": [49248, 38771],
			""time"": 88019
		}, {
			""lap"": 2,
			""car"": 5,
			""sectors"": [49228, 81491],
			""time"": 130719
		}, {
			""lap"": 3,
			""car"": 5,
			""sectors"": [52154, 38908],
			""time"": 91062
		}, {
			""lap"": 4,
			""car"": 5,
			""sectors"": [49513, 38893],
			""time"": 88406
		}],
		""lapstotal"": [0, 6, 5, 5, 3, 5],
		""bestLaps"": [{
			""car"": 1,
			""time"": 87876,
			""lap"": 5
		}, {
			""car"": 2,
			""time"": 87969,
			""lap"": 4
		}, {
			""car"": 3,
			""time"": 87956,
			""lap"": 1
		}, {
			""car"": 4,
			""time"": 87851,
			""lap"": 1
		}, {
			""car"": 5,
			""time"": 88019,
			""lap"": 1
		}]
	}],
	""extras"": [{
		""name"": ""bestlap"",
		""time"": 0
	}]
}";


        public static string RaceOutputLog_Player2nd = @"
{
	""track"": ""magione"",
	""number_of_sessions"": 1,
	""players"": [
		{
			""name"": ""PlayerFinishedSecond"",
			""car"": ""ks_abarth500_assetto_corse"",
			""skin"": ""0_official""

        }, 
		{
			""name"": ""Jazmine Hermanson"",
			""car"": ""ks_abarth500_assetto_corse"",
			""skin"": ""orange_grey""
		}, 
		{
			""name"": ""Kendal Buckley"",
			""car"": ""ks_abarth500_assetto_corse"",
			""skin"": ""racing_500""
		}, 
		{
			""name"": ""Erlend Braband"",
			""car"": ""ks_abarth500_assetto_corse"",
			""skin"": ""light_blue_orange""
		}, 
		{
			""name"": ""Kurtis Nadeau"",
			""car"": ""ks_abarth500_assetto_corse"",
			""skin"": ""black_neon""
		}, 
		{
			""name"": ""Darell Hoyt"",
			""car"": ""ks_abarth500_assetto_corse"",
			""skin"": ""silver_red""
		}],
	""sessions"": [
		{
			""event"": 0,
			""name"": ""Quick Race"",
			""type"": 3,
			""lapsCount"": 3,
			""duration"": 30,
			""laps"": [
				{
					""lap"": 0,
					""car"": 0,
					""sectors"": [56074, 40433],
					""time"": 96507
				}, 
				{
					""lap"": 1,
					""car"": 0,
					""sectors"": [51209, 39286],
					""time"": 90495
				}, 
				{
					""lap"": 2,
					""car"": 0,
					""sectors"": [51520, 46174],
					""time"": 97694
				}, 
				{
					""lap"": 0,
					""car"": 1,
					""sectors"": [56672, 40869],
					""time"": 97541
				}, 
				{
					""lap"": 1,
					""car"": 1,
					""sectors"": [50681, 39285],
					""time"": 89966
				}, 
				{
					""lap"": 2,
					""car"": 1,
					""sectors"": [51581, 44861],
					""time"": 96442
				}, 
				{
					""lap"": 0,
					""car"": 2,
					""sectors"": [58473, 39865],
					""time"": 98338
				}, 
				{
					""lap"": 1,
					""car"": 2,
					""sectors"": [51355, 38993],
					""time"": 90348
				}, 
				{
					""lap"": 2,
					""car"": 2,
					""sectors"": [51929, 44546],
					""time"": 96475
				}, 
				{
					""lap"": 0,
					""car"": 3,
					""sectors"": [57289, 40613],
					""time"": 97902
				}, 
				{
					""lap"": 1,
					""car"": 3,
					""sectors"": [51219, 39001],
					""time"": 90220
				}, 
				{
					""lap"": 2,
					""car"": 3,
					""sectors"": [51508, 45508],
					""time"": 97016
				}, 
				{
					""lap"": 0,
					""car"": 4,
					""sectors"": [59750, 39911],
					""time"": 99661
				}, 
				{
					""lap"": 1,
					""car"": 4,
					""sectors"": [50590, 39168],
					""time"": 89758
				}, 
				{
					""lap"": 2,
					""car"": 4,
					""sectors"": [51935, 44118],
					""time"": 96053
				}, 
				{
					""lap"": 0,
					""car"": 5,
					""sectors"": [58886, 41149],
					""time"": 100035
				}, 
				{
					""lap"": 1,
					""car"": 5,
					""sectors"": [50858, 39060],
					""time"": 89918
				}, 
				{
					""lap"": 2,
					""car"": 5,
					""sectors"": [52356, 43285],
					""time"": 95641
				}],
			""lapstotal"": [3, 3, 3, 3, 3, 3],
			""bestLaps"": [
				{
					""car"": 0,
					""time"": 90495,
					""lap"": 1
				}, 
				{
					""car"": 1,
					""time"": 89966,
					""lap"": 1
				}, 
				{
					""car"": 2,
					""time"": 90348,
					""lap"": 1
				}, 
				{
					""car"": 3,
					""time"": 90220,
					""lap"": 1
				}, 
				{
					""car"": 4,
					""time"": 89758,
					""lap"": 1
				}, 
				{
					""car"": 5,
					""time"": 89918,
					""lap"": 1
				}],
			""raceResult"": [1, 0, 3, 2, 4, 5]
		}],
	""extras"": [
		{
			""name"": ""bestlap"",
			""time"": 90495
		}]
}";
    }
}
