using catalog_disciplines.Models;
using catalog_disciplines.Repositories;
using catalog_disciplines.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DisciplineContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DisciplineContext")));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDisciplineRepository, DisciplineRepository>();
builder.Services.AddScoped<IDisciplineService,DisciplineService>();
builder.Services.AddSingleton(new RabbitMQPublisher("localhost", "catalog-net-java-queue"));

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
