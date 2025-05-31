using ApiProject.WebAPI.Context;
using ApiProject.WebAPI.DTOs.ProductDTOs;
using ApiProject.WebAPI.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IValidator<Product> _validator;
		private readonly ApiContext _context;
		private readonly IMapper _mapper;

		public ProductsController(IValidator<Product> validator, ApiContext context, IMapper mapper)
		{
			_validator = validator;
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ProductList()
		{
			var values = _context.Products.ToList();
			return Ok(values);
		}

		[HttpPost]	
		public IActionResult CreateProduct(Product product)
		{
			//product'dan göndermiş olduğumuz durumları kontrol et
			var validationResult = _validator.Validate(product);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
			}
			else
			{
				_context.Products.Add(product);
				_context.SaveChanges();
				return Ok("Ürün ekleme işlemi başarılı");
			}
		}

		[HttpDelete]
		public IActionResult DeleteProduct(int id)
		{
			var value = _context.Products.Find(id);
			_context.Products.Remove(value);
			_context.SaveChanges();
			return Ok("Silme işlemi başarıyla tamamlandı");
		}
		[HttpGet("GetProduct")]
		public IActionResult GetProduct(int id)
		{
			var value = _context.Products.Find(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateProduct(Product product)
		{
			var validationResult = _validator.Validate(product);
			if(!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
			}
			else
			{
				_context.Products.Update(product);
				_context.SaveChanges();
				return Ok("Güncelleme işlemi başarılı");
			}
		}
		[HttpPost("CreateProductWithCategory")]
		public IActionResult CreateProductWithCategory(CreateProductDTO createProductDTO)
		{
			var value = _mapper.Map<Product>(createProductDTO);
			_context.Products.Add(value);
			_context.SaveChanges();
			return Ok("Ekleme işlemi başarılı");
		}

	}
}
