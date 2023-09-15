using Microsoft.EntityFrameworkCore;
using SimpleProductCRUD.API.ComCopilot.Context;
using SimpleProductCRUD.API.ComCopilot.Interfaces;
using SimpleProductCRUD.API.ComCopilot.Mappings;
using SimpleProductCRUD.API.ComCopilot.Repositories;
using SimpleProductCRUD.API.ComCopilot.Services;

namespace SimpleProductCRUD.API.ComCopilot.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();

        services.AddAutoMapper(typeof(EntityToDTOMappingProfile));

        return services;
    }
}