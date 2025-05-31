namespace ApiProject.WebAPI.Entities
{
	public class Product
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }
		public decimal Price { get; set; }
		public string ImageURL { get; set; }
		public int? CategoryId { get; set; } //Id boş olursa hata vermesin
		public Category Category { get; set; } 
	}
}
