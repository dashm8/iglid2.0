using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iglid.Models
{
    public static class MapEnums
    {
        public static Maps GetRandomMap(Modes mode)
        {
            if (mode == Modes.CTF)
            {
                var someDir2 = new List<CTFENUM>();

                foreach (CTFENUM dir in Enum.GetValues(typeof(CTFENUM)))
                {                    
                        someDir2.Add(dir);                    
                }

                Random rnd = new Random();
                return ConvertToMap(someDir2[rnd.Next(someDir2.Count)]);
            }

            if (mode == Modes.HP)
            {
                var someDir2 = new List<HPENUM>();

                foreach (HPENUM dir in Enum.GetValues(typeof(HPENUM)))
                {
                    someDir2.Add(dir);
                }

                Random rnd = new Random();
                return ConvertToMap(someDir2[rnd.Next(someDir2.Count)]);
            }

            if (mode == Modes.SANDD)
            {
                var someDir2 = new List<SNDENUM>();

                foreach (SNDENUM dir in Enum.GetValues(typeof(SNDENUM)))
                {
                    someDir2.Add(dir);
                }

                Random rnd = new Random();
                return ConvertToMap(someDir2[rnd.Next(someDir2.Count)]);
            }

            return Maps.Ardennes_Forest;
        }
        private static Maps ConvertToMap(HPENUM hPENUM)
        {
            switch (hPENUM)
            {
                case HPENUM.Ardennes_Forest:
                    return Maps.Ardennes_Forest;
                case HPENUM.Gibraltar:
                    return Maps.Gibraltar;
                case HPENUM.London_Docks:
                    return Maps.London_Docks;
                case HPENUM.Saint_Marie_Du_Mont:
                    return Maps.Saint_Marie_Du_Mont;
                default:
                    return Maps.Saint_Marie_Du_Mont;
            }
        }

        private static Maps ConvertToMap(CTFENUM hPENUM)
        {
            switch (hPENUM)
            {
                case CTFENUM.Ardennes_Forest:
                    return Maps.Ardennes_Forest;
                case CTFENUM.London_Docks:
                    return Maps.London_Docks;
                case CTFENUM.Saint_Marie_Du_Mont:
                    return Maps.Saint_Marie_Du_Mont;
                case CTFENUM.Flak_Tower:
                    return Maps.Flak_Tower;
                default:
                    return Maps.Flak_Tower;
            }
        }

        private static Maps ConvertToMap(SNDENUM sNDENUM)
        {
            switch (sNDENUM)
            {
                case SNDENUM.Ardennes_Forest:
                    return Maps.Ardennes_Forest;
                case SNDENUM.Gibraltar:
                    return Maps.Gibraltar;
                case SNDENUM.London_Docks:
                    return Maps.London_Docks;
                case SNDENUM.Saint_Marie_Du_Mont:
                    return Maps.Saint_Marie_Du_Mont;
                case SNDENUM.USS_Texas:
                    return Maps.USS_Texas;
                default:
                    return Maps.USS_Texas;
            }
        }

        enum HPENUM
        {
            Ardennes_Forest,
            Gibraltar,
            London_Docks,
            Saint_Marie_Du_Mont
        }

        enum CTFENUM
        {
            Ardennes_Forest,
            London_Docks,
            Saint_Marie_Du_Mont,
            Flak_Tower
        }

        enum SNDENUM
        {
            Ardennes_Forest,
            Gibraltar,
            London_Docks,
            Saint_Marie_Du_Mont,
            USS_Texas
        }
        
    }
}
