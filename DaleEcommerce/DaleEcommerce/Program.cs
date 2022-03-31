using Dale.Persistence.Database;
using Dale.Persistence.Database.Imple;
using Dale.Persistence.Database.Interfaces;
using Dale.Service;
using Dale.Services;
using Dale.Services.Contract;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsHistoryTable("_EFMigrationsHistory", "Catalog"))
            );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerInfrastructure, CustomerInfrastructure>();
builder.Services.AddScoped<IProductsInfrastructure, ProductsInfrastructure>();
builder.Services.AddScoped<IOrderInfrastructure, OrderInfrastructure>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
