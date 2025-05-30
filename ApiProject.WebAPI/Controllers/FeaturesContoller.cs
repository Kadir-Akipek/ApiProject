using ApiProject.WebAPI.Context;
using ApiProject.WebAPI.DTOs.FearuteDTOs;
using ApiProject.WebAPI.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeaturesContoller : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ApiContext _context;

		public FeaturesContoller(IMapper mapper, ApiContext context)
		{
			_mapper = mapper;
			_context = context;
		}

		[HttpGet]
		public IActionResult FeatureList()
		{
			var values = _context.Features.ToList();
			return Ok(_mapper.Map<List<ResultFeatureDTO>>(values));
		}

		[HttpPost]
		public IActionResult CreateFeature(CreateFeatureDTO createFeatureDTO)
		{
			var value = _mapper.Map<Feature>(createFeatureDTO);
			_context.Features.Add(value);
			_context.SaveChanges();
			return Ok("Ekleme işlemi başarılı");
		}
		[HttpDelete]
		public IActionResult DeleteFeature(int id)
		{
			var value = _context.Features.Find(id);
			_context.Features.Remove(value);
			_context.SaveChanges();
			return Ok("Silme işlemi başarılı");
		}
		[HttpGet("GetFeature")]
		public IActionResult GetFeature(int id)
		{
			var value = _context.Features.Find(id);
			return Ok(_mapper.Map<GetByIdFeatureDTO>(value));
		}
		[HttpPut]
		public IActionResult UpdateFeature(UpdateFeatureDTO updateFeatureDTO)
		{
			var value = _mapper.Map<Feature>(updateFeatureDTO);
			_context.Features.Update(value);
			_context.SaveChanges();
			return Ok("Güncelleme işlemi başarılı");
		}
	}
}
