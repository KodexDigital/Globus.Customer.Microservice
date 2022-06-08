using Globus.DAL.Data;
using Globus.DAL.Repositories.Declarations;
using Globus.DAL.Repositories.Implementations;
using Globus.External.Service.Services;
using Globus.Service.Declarations;
using Globus.Service.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("Dbcon");
builder.Services.AddDbContextPool<CustomerDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Globus Customer Onboarding Service",
        Version = "1.0",
        Description = "This is a standardized microservice for onboarding customers.",
    });
    c.IncludeXmlComments(Path.ChangeExtension(Assembly.GetEntryAssembly().Location, "xml"));
});

//Dependency injections
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IOneTimePasswordRepository, OneTimePasswordRepository>();
builder.Services.AddTransient<IOneTimePasswordService, OneTimePasswordService>();
builder.Services.AddTransient<IGoldService, GoldService>();

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
