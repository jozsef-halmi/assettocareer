using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Comparers
{
    public class LapTimeComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x == y) return 0;

            if (x == 0) return 1;
            if (y == 0) return -1;

            return x > y ? 1 : -1;
        }
    }
}
