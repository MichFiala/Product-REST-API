using Application.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            	services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
			});

			services.AddDbContext<DataContext>(opt =>
			{
				opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
			});

			// Adding versioning
			services.AddApiVersioning(cfg => {
				cfg.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
				cfg.AssumeDefaultVersionWhenUnspecified = true;
				cfg.ReportApiVersions = true;
				cfg.ApiVersionReader = new HeaderApiVersionReader("api-version");
			});

			return services;
		}         
    }
}