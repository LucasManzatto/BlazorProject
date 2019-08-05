namespace BlazorProject.Server.Models
{
    public class ItemCategories
    {
        public int Id { get; set; }
        public int ItemPocketId { get; set; }
        public string Name { get; set; }
        public virtual ItemPockets ItemPocket { get; set; }
    }
}