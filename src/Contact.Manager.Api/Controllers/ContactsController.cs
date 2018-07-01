using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contact.Manager.Data.Access.Layer;

namespace Contact.Manager.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/Contacts")]
	public class ContactsController : Controller
	{
		private readonly ContactDbContext _context;

		public ContactsController(ContactDbContext context)
		{
			_context = context;
		}

		// GET: api/Contacts
		[HttpGet]
		public List<ContactModel> GetContacts()
		{
			return _context.Contacts.ToList();
		}

		// GET: api/Contacts/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetContact([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var contact = await _context.Contacts.SingleOrDefaultAsync(m => m.Id == id);

			if (contact == null)
			{
				return NotFound();
			}

			return Ok(contact);
		}

		// PUT: api/Contacts/5
		[HttpPut("{id}")]
		public IActionResult PutContact([FromRoute] int id, [FromBody] ContactModel contact)
		{
			//if (!ModelState.IsValid)
			//{
			//	return BadRequest(ModelState);
			//}

			//if (id != contact.Id)
			//{
			//	return BadRequest();
			//}

			//_context.Entry(contact).State = EntityState.Modified;

			//try
			//{
			//	await _context.SaveChangesAsync();
			//}
			//catch (DbUpdateConcurrencyException)
			//{
			//	if (!ContactExists(id))
			//	{
			//		return NotFound();
			//	}
			//	else
			//	{
			//		throw;
			//	}
			//}

			//return NoContent();

			if (contact == null || contact.Id != id)
			{
				return BadRequest();
			}

			var singleContact = _context.Contacts.Find(id);
			if (singleContact == null)
			{
				return NotFound();
			}

			singleContact.FirstName = contact.FirstName;
			singleContact.LastName = contact.LastName;
			singleContact.Email = contact.Email;
			singleContact.PhoneNumber = contact.PhoneNumber;
			singleContact.Status = contact.Status;

			_context.Contacts.Update(singleContact);
			_context.SaveChanges();
			return NoContent();
		}

		// POST: api/Contacts
		[HttpPost]
		public IActionResult PostContact([FromBody] ContactModel contactInfo)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_context.Contacts.Add(contactInfo);
			_context.SaveChanges();

			return CreatedAtAction("GetContact", new { contactInfo.Id }, contactInfo);
		}

		// DELETE: api/Contacts/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteContact([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var contact = await _context.Contacts.SingleOrDefaultAsync(m => m.Id == id);
			if (contact == null)
			{
				return NotFound();
			}

			_context.Contacts.Remove(contact);
			await _context.SaveChangesAsync();

			return Ok(contact);
		}

		private bool ContactExists(int id)
		{
			return _context.Contacts.Any(e => e.Id == id);
		}
	}
}