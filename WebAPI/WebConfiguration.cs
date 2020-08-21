using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

using EF_DB;
using EF_DB.Repositories;
using EF_DB.Repositories.Lookups;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Repository.Repositories;
using Repository.Repositories.Lookups;

namespace WebAPI
{
	public class WebConfiguration
	{
		private readonly IConfiguration _configuration;



		public WebConfiguration(IConfiguration configuration) => _configuration = configuration;



		// This method gets called by the runtime once. Use this method to add services to the container for dependency injection.
		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddSingleton(_configuration.GetSection("AppSettings").Get<Options>())
				.AddScoped(typeof(IUserAccess), typeof(UserAccess))
				.AddScoped(typeof(ITaskItemAccess), typeof(TaskItemAccess))
				.AddScoped(typeof(IGenderAccess), typeof(GenderAccess))

				.AddSwaggerGen()

				.AddControllers()
				;
		}

		// This method gets called by the runtime once. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Options options)
		{
			Context.ConnectionString = Regex.Replace(options.DbConStr, @"\|DataDirectory\|\\?", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\");

			if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

			app
				.UseHttpsRedirection()
				.UseRouting()
				.UseAuthorization()
				.UseEndpoints(endpoints => endpoints.MapControllers())
				.UseSwagger()
				;

			if (env.IsDevelopment()) app.UseSwaggerUI();
		}
	}
}
