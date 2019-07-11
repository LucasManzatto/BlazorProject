using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Client.Shared.Utils
{
    public static class Utils
    {
        public static string GetColorHex(string color) => Colors.TypesList.Find(p => p.Key == color).Value;
    }
}
