using Microsoft.EntityFrameworkCore;

namespace Contact.Manager.Data.Access.Layer
{
	public class ContactDbContext : DbContext
	{
		public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) {	}

		public DbSet<ContactModel> Contacts { get; set; }
	}
}
