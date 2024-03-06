namespace ProjChoc.Domain.Entities
{
	public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int? CategoriesId { get; set; }
        public Categorie? Categories { get; set; }
    }
}
