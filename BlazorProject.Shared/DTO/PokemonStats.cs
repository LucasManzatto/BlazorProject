namespace BlazorProject.Shared.DTO
{
    public partial class PokemonStats
    {
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAttack { get; set; }
        public int SpDefense { get; set; }
        public int Speed { get; set; }

        public int Total
        {
            get { return Hp + Attack + Defense + SpAttack + SpDefense + Speed; }
        }

        public override string ToString()
        {
            return $"HP: {Hp} , Total:{Total}";
        }
    }
}
