using Application.Services;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Presentation.SOAP.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Dodaj DbContext do kontenera DI
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("CleanArchitectureDb"));

// Dodaj us³ugi do kontenera
builder.Services.AddControllers(); // Dodaj kontrolery SOAP

// Dodaj zale¿noœci
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ProductService>();

var app = builder.Build();

// Skonfiguruj potok obs³ugi ¿¹dañ HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Dodaj middleware obs³uguj¹cy nag³ówki HTTP
app.UseHttpHeadersMiddleware();

app.MapControllers();

app.Run();

