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
            FriendlyName= "Brands Hatch Indy",
            Name = "indy"
        };

        public static LayoutData BrandsGp = new LayoutData()
        {
            FriendlyName = "Brands Hatch GP",
            Name = "gp"
        };

        public static LayoutData RedBullNational = new LayoutData()
        {
            FriendlyName = "Red Bull Ring National",
            Name = "layout_national"
        };

        public static LayoutData RedBullGp = new LayoutData()
        {
            FriendlyName = "Red Bull Ring GP",
            Name = "layout_gp"
        };

        public static LayoutData VallelungaClub = new LayoutData()
        {
            FriendlyName = "Vallelunga Club",
            Name = "club_circuit"
        };

        public static LayoutData VallelungaExtended = new LayoutData()
        {
            FriendlyName = "Vallelunga Extended",
            Name = "extended_circuit"
        };

        public static LayoutData VallelungaClassic = new LayoutData()
        {
            FriendlyName = "Vallelunga Classic",
            Name = "classic_circuit"
        };
    }

}
