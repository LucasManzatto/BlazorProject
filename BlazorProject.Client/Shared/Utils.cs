using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Client.Shared
{
    public static class Utils
    {
        public static string GetColorHex(string color)
        {
            switch (color)
            {
                case "grass":
                    return "#7c5";
                case "fire":
                    return "#f42";
                case "poison":
                    return "#a59";
                default:
                    return "";
            }
        }
    }
}
