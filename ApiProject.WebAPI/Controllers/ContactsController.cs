using ApiProject.WebAPI.Context;
using ApiProject.WebAPI.DTOs.ContactDTOs;
using ApiProject.WebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly ApiContext _context;

		public ContactsController(ApiContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult ContactList()
		{
			var values = _context.Contacts.ToList();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateContact(CreateContactDTO createContactDTO)
		{
			Contact contact = new Contact();
			contact.Email = createContactDTO.Email;
			contact.Adress = createContactDTO.Adress;
			contact.Phone = createContactDTO.Phone;
			contact.MapLocation = createContactDTO.MapLocation;
			contact.OpenHours = createContactDTO.OpenHours;
			_context.Contacts.Add(contact);
			_context.SaveChanges();
			return Ok("Ekleme işlemi başarılı");
		}
		[HttpDelete]
		public IActionResult DeleteContact(int id)
		{
			var value = _context.Contacts.Find(id);
			_context.Contacts.Remove(value);
			_context.SaveChanges();
			return Ok("Silme işlemi başarılı");
		}
		[HttpGet("GetContact")]
		public IActionResult GetContact(int id)
		{
			var value = _context.Contacts.Find(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateContact(UpdateContactDTO updateContactDTO)
		{
			Contact contact = new Contact();
			contact.Email = updateContactDTO.Email;
			contact.Adress = updateContactDTO.Adress;
			contact.Phone = updateContactDTO.Phone;
			contact.ContactId = updateContactDTO.ContactId;
			contact.MapLocation = updateContactDTO.MapLocation;
			contact.OpenHours = updateContactDTO.OpenHours;
			_context.Contacts.Update(contact);
			_context.SaveChanges();
			return Ok("Güncelleme işlemi başarılı");
		}

	}
}
