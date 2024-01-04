using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ApplicationDbContext;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
        });

        builder.Services.AddDbContext<ApplicationDbContext.ApplicationDbContext>(options =>
        {
            options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 11)));
        });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });

        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1"));
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
        }

        app.UseRouting();
        app.UseCors("AllowAnyOrigin");

        app.MapGet("/", () => "Hello World!");
        app.MapPut("/world", () => "World! Hello ");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.MapPost("/api/products", async (HttpContext context) =>
        {
            try
            {
                var productRepository = context.RequestServices.GetRequiredService<IProductRepository>();
                var product = await context.Request.ReadFromJsonAsync<Product>();

                if (product != null)
                {
                    productRepository.Create(product);
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Product created successfully");
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid product data");
                }
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync($"Internal Server Error: {ex.Message}");
            }
        });

        app.Run();
    }
}
