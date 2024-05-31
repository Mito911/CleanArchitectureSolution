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

// Dodaj us�ugi do kontenera
builder.Services.AddControllers(); // Dodaj kontrolery SOAP

// Dodaj zale�no�ci
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ProductService>();

var app = builder.Build();

// Skonfiguruj potok obs�ugi ��da� HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Dodaj middleware obs�uguj�cy nag��wki HTTP
app.UseHttpHeadersMiddleware();

app.MapControllers();

app.Run();

