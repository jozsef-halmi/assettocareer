using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Data
{
    public static class SupportedLayouts
    {
        public static LayoutData BrandsIndy = new LayoutData()
        {
            FriendlyName= "Indy",
            Name = "indy"
        };

        public static LayoutData BrandsGp = new LayoutData()
        {
            FriendlyName = "GP",
            Name = "gp"
        };

        public static LayoutData RedBullNational = new LayoutData()
        {
            FriendlyName = "National",
            Name = "layout_national"
        };

        public static LayoutData RedBullGp = new LayoutData()
        {
            FriendlyName = "GP",
            Name = "layout_gp"
        };

        public static LayoutData VallelungaClub = new LayoutData()
        {
            FriendlyName = "Club",
            Name = "club_circuit"
        };

        public static LayoutData VallelungaExtended = new LayoutData()
        {
            FriendlyName = "Extended",
            Name = "extended_circuit"
        };

        public static LayoutData VallelungaClassic = new LayoutData()
        {
            FriendlyName = "Classic",
            Name = "classic_circuit"
        };

        public static LayoutData PaulRicardWtcc = new LayoutData()
        {
            FriendlyName = "WTCC",
            Name = "wtcc"
        };

        public static LayoutData TorPoznanLaser = new LayoutData()
        {
            FriendlyName = "Laser",
            Name = "laser"
        };

        public static LayoutData TorPoznanWinter = new LayoutData()
        {
            FriendlyName = "Winter",
            Name = "zima"
        };
    }

}
