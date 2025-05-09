using Microsoft.FeatureManagement;
using HrWebApp.Api.Services;
using HrWebApp.Api.Filters;
using HrWebApp.Api.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add HttpContextAccessor for header-based feature flags
builder.Services.AddHttpContextAccessor();

// Add Feature Management with filters
builder.Services.AddFeatureManagement()
    .AddFeatureFilter<HeaderFeatureFilter>();

// Add our services
builder.Services.AddSingleton<IEmployeeRepository, EmployeeInMemoryRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
