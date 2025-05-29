using ApiProject.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.WebAPI.Context
{
	public class ApiContext : DbContext
	{
		//bağlantı adresimizi yazmak için ihtiyacımız olan metot
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=KADIRAKIPEK\\SQLEXPRESS; initial catalog = ApiYummyDb; integrated security = true");
		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Chef> Chefs { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Feature> Features { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<Testimonial> Testimonials { get; set; }
	}
}
