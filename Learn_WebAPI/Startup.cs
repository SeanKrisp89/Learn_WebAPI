using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn_WebAPI
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

		// This method gets called by the runtime. This method is used to add services to the container (and to configure those services). But, what are exactly services in the .NET Core world? Services should 
		// be seen as a broad concept. A service is a component that is intended for common consumption in an application. There are framework services like Identity, MVC, Entity Framework Core services.
		// But, there are also application services which are application specific, for example a component to send mail.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc() //Here we're adding our ASP.NET MVC middleware. We then have to add this to the request pipeline... see line 41
			.AddMvcOptions(o =>
			{
				o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()); //Added support for returning XML content type/format in HttpResponses
			});
			services.AddControllers(options => options.EnableEndpointRouting = false);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline...
		//Whenever an HTTP request comes in, something must handle that request and provide an HTTP response.
		//The code that handles requests and provides responses make up the request pipeline.
		//WHAT WE CAN DO IS CONFIGURE THAT REQUEST PIPELINE BY ADDING MIDDLEWARE WHICH IS SOFTWARE COMPONENTS (code) THAT ARE ASSEMBLED INTO AN APPLICATION PIPELINE TO HANDLE REQUESTS AND RESPONSES
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage(); //This statement configures the request pipeline by adding the DeveloperExceptionPage to it. So now when an exception is thrown this piece of middleware will handle it
			}
			else
			{
				app.UseExceptionHandler("/"); //So we manually added the else statement code block with UseExceptionHandler();. This is saying "if we're not in the dev environment, don't use the Developer Exception Page, instead use an exception page more suitable to end-user. 
			}                              //We then change the environment by going to the properties of the project, debug tab, and change the value for ASPNETCORE_ENVIRONMENT key to Production (or just anything that isn't dev).

			app.UseMvc();

			app.UseRouting();

			app.UseStatusCodePages();

			//app.UseEndpoints(endpoints =>
			//{
			//	endpoints.MapGet("/", async context =>
			//	{
			//		/*await context.Response.WriteAsync("Hello World!");*/ //So right now this app just prints out "Hello World" on screen. This is currently how our "HTTP request pipeline" is set up to handle HTTP requests...
			//		throw new Exception("Sample exception");
			//	});
			//});
		}
	}
}
