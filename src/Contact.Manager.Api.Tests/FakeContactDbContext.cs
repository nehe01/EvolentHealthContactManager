using Contact.Manager.Data.Access.Layer;
using Microsoft.EntityFrameworkCore;

namespace Contact.Manager.Api.Tests
{
	public class FakeContactDbContext : ContactDbContext
	{
		//public FakeContactDbContext(DbContextOptions<FakeContactDbContext> options)  { }

		//public DbSet<ContactModel> Contacts { get; set; }
		public FakeContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
		{
		}
	}
}
