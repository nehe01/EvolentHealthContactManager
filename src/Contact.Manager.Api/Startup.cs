using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Contact.Manager.Data.Access.Layer;
using Microsoft.EntityFrameworkCore;

namespace Contact.Manager.Api
{
	public class Startup
	{
		private const string CorsPolicy = "CorsPolicy";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//services.AddDbContext<ContactDbContext>(opt =>
			//					opt.UseInMemoryDatabase("ContactsDatabase"));
			//services.AddDbContext<ContactDbContext>(options =>
			//	options.UseSqlServer(Configuration.GetConnectionString("ContactsDatabase")));
			services.AddDbContext<ContactDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ContactsDatabase"), b => b.MigrationsAssembly("Contact.Manager.Api")));
			services.AddMvc();

			services.AddCors(options =>
			{
				options.AddPolicy(CorsPolicy,
						builder => builder.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials());
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors(CorsPolicy);

			app.UseDefaultFiles();
			app.UseStaticFiles();
			app.UseMvc();
		}
	}
}
