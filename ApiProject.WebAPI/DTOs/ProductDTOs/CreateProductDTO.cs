﻿using ApiProject.WebAPI.Entities;

namespace ApiProject.WebAPI.DTOs.ProductDTOs
{
	public class CreateProductDTO
	{
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }
		public decimal Price { get; set; }
		public string ImageURL { get; set; }
		public int CategoryId { get; set; } 
	}
}
