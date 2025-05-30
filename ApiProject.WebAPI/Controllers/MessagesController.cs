using ApiProject.WebAPI.Context;
using ApiProject.WebAPI.DTOs.MessageDTOs;
using ApiProject.WebAPI.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ApiContext _context;

		public MessagesController(IMapper mapper, ApiContext context)
		{
			_mapper = mapper;
			_context = context;
		}
		[HttpGet]
		public IActionResult MessageList()
		{
			var values = _context.Messages.ToList();
			return Ok(_mapper.Map<List<ResultMessageDTO>>(values));
		}

		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDTO createmessageDTO)
		{
			var value = _mapper.Map<Message>(createmessageDTO);
			_context.Messages.Add(value);
			_context.SaveChanges();
			return Ok("Mesaj ekleme işlemi başarılı");
		}
		[HttpDelete]
		public IActionResult DeleteMessage(int id)
		{
			var value = _context.Messages.Find(id);
			_context.Messages.Remove(value);
			_context.SaveChanges();
			return Ok("Silme işlemi başarılı");
		}
		[HttpGet("GetMessage")]
		public IActionResult GetMessages(int id)
		{
			var value = _context.Messages.Find(id);
			return Ok(_mapper.Map<GetByIdMessageDTO>(value));
		}
		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDTO updatemessageDTO)
		{
			var value = _mapper.Map<Message>(updatemessageDTO);
			_context.Messages.Update(value);
			_context.SaveChanges();
			return Ok("Mesaj güncelleme işlemi başarılı");
		}
	}
}
