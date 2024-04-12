using HomeService.Application.Commands;
using HomeService.Application.Services;
using HomeService.Infrastructure.Extension;
using HomeService.Infrastructure.Persistence.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = new ConfigurationBuilder().SetBasePath(System.IO.Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", reloadOnChange: true, optional: false).AddEnvironmentVariables().Build();

builder.Services.AddDbContext<HomeServiceDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//Services
//builder.Services.AddMediatR(ccfg => ccfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
builder.Services.AddRepositories();
builder.Services.AddApplication();
//builder.Services.AddAu();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
