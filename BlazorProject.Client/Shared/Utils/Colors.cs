using System.Collections.Generic;

namespace BlazorProject.Client.Shared.Utils
{
    public static class Colors
    {
        public static IDictionary<string, string> TypesDict { get; set; }
            = new Dictionary<string, string>
            {
                {"normal", "#aa9" },
                {"fire", "#f42" },
                {"water", "#39f" },
                { "electric", "#fc3"},
                {"grass", "#7c5" },
                {"ice", "#6cf" },
                {"fighting", "#b54" },
                {"poison", "#a59" },
                {"ground", "#db5" },
                {"flying", "#89f" },
                {"psychic", "#f59" },
                {"bug", "#ab2" },
                {"rock", "#ba6" },
                {"ghost", "#66b" },
                {"dragon", "#76e" },
                {"dark", "#754" },
                {"steel", "#aab" },
                {"fairy", "#e9e" }
            };
    }
}
