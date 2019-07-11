using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Client.Shared.Utils
{
    public static class Colors
    {
        public static KeyValuePair<string, string> Bug = new KeyValuePair<string, string>("bug", "#ab2");
        public static KeyValuePair<string, string> Dark = new KeyValuePair<string, string>("dark", "#754");
        public static KeyValuePair<string, string> Dragon = new KeyValuePair<string, string>("dragon", "#76e");
        public static KeyValuePair<string, string> Electric = new KeyValuePair<string, string>("electric", "#fc3");
        public static KeyValuePair<string, string> Fairy = new KeyValuePair<string, string>("ghost", "#e9e");
        public static KeyValuePair<string, string> Fighting = new KeyValuePair<string, string>("fighting", "#b54");
        public static KeyValuePair<string, string> Fire = new KeyValuePair<string, string>("fire", "#f42");
        public static KeyValuePair<string, string> Flying = new KeyValuePair<string, string>("fire", "#89f");
        public static KeyValuePair<string, string> Ghost = new KeyValuePair<string, string>("ghost", "#66b");
        public static KeyValuePair<string, string> Grass = new KeyValuePair<string, string>("grass", "#7c5");
        public static KeyValuePair<string, string> Ground = new KeyValuePair<string, string>("ground", "#db5");
        public static KeyValuePair<string, string> Normal = new KeyValuePair<string, string>("normal", "#aa9");
        public static KeyValuePair<string, string> Poison = new KeyValuePair<string, string>("poison", "#a59");
        public static KeyValuePair<string, string> Psychic = new KeyValuePair<string, string>("psychic", "#f59");
        public static KeyValuePair<string, string> Rock = new KeyValuePair<string, string>("rock", "#ba6");
        public static KeyValuePair<string, string> Steel = new KeyValuePair<string, string>("rock", "#aab");
        public static KeyValuePair<string, string> Water = new KeyValuePair<string, string>("water", "#39f");

        public static List<KeyValuePair<string, string>> TypesList { get; set; }
            = new List<KeyValuePair<string, string>> {
                Bug,
                Dark,
                Dragon,
                Electric,
                Fairy,
                Fighting,
                Fire,
                Flying,
                Ghost,
                Grass,
                Ground,
                Normal,
                Poison,
                Psychic,
                Rock,
                Steel,
                Water
            };
    }
}
