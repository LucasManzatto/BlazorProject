namespace BlazorProject.Shared.DTO
{
    public class PokemonStats
    {
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAttack { get; set; }
        public int SpDefense { get; set; }
        public int Speed { get; set; }

        public int Total => Hp + Attack + Defense + SpAttack + SpDefense + Speed;

        public override string ToString()
        {
            return $"HP: {Hp} , Total:{Total}";
        }
    }
}
