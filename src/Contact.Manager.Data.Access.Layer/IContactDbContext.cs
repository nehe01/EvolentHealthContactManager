using Microsoft.EntityFrameworkCore;

namespace Contact.Manager.Data.Access.Layer
{
	public interface IContactDbContext
	{
		DbSet<ContactModel> Contacts { get; set; }
	}
}
