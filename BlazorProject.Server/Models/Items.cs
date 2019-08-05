namespace BlazorProject.Server.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemCategoryId { get; set; }
        public int Cost { get; set; }
        public int? FlingPower { get; set; }
        public int? ItemFlingEffectId { get; set; }

        public virtual ItemCategories ItemCategory { get; set; }
        public virtual ItemFlingEffects ItemFlingEffect { get; set; }
    }
}