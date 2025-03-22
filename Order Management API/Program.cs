using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Order_Management_API.Model;
using Order_Management_API.Repository.Order;
using Order_Management_API.Repository.OrderDetails;
using Order_Management_API.Services.Logs;
using Order_Management_API.Services.OrderDetails;
using Order_Management_API.Services.Orders;

using Serilog;
using Serilog.Formatting.Json;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OrderManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrderManagementDB")));
// add automapper
builder.Services.AddAutoMapper(typeof(AutoMappingOrder));
// add Order Services
builder.Services.AddScoped<IOrderRepository,OrderRepository>();
builder.Services.AddScoped<OrderServices>();
// add OrderDetails Services
builder.Services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
builder.Services.AddScoped<OrderDetailsServices>();

// add serilog
builder.Host.UseSerilog((ctx, config) =>
{
    config
        .MinimumLevel.Information()
        .WriteTo.File(
            formatter: new JsonFormatter(),
            AppDomain.CurrentDomain.BaseDirectory + "Logs/log-.txt",
            rollingInterval: RollingInterval.Day,
            rollOnFileSizeLimit: true
            );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<LogMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
