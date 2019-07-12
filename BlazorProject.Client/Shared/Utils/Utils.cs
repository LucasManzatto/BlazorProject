using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Client.Shared.Utils
{
    public static class Utils
    {
        public static string GetColorHex(string color) => Colors.TypesList.Find(p => p.Key == color).Value;

        public static int CalculateHpStat(int baseStat, int iv, int ev)
        {
            return (2 * baseStat + iv + (ev / 4)) + 110;
        }
        public static int CalculateOtherStat(int baseStat, int iv, int ev, float natureMultiplier)
        {
            return (int)((((2 * baseStat) + iv + (ev / 4)) + 5) * natureMultiplier);
        }
    }
}
