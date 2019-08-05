namespace BlazorProject.Client.Shared.Utils
{
    public static class Utils
    {
        public static string GetColorHex(string color) => Colors.TypesDict[color];

        public static int CalculateHpStat(int baseStat, int iv, int ev) => (2 * baseStat + iv + (ev / 4)) + 110;

        public static int CalculateOtherStat(int baseStat, int iv, int ev, float natureMultiplier) =>
            (int) ((((2 * baseStat) + iv + (ev / 4)) + 5) * natureMultiplier);
    }
}