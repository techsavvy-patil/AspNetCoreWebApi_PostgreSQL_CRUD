using Registration_Page_Task.Business.Interfaces;
using Registration_Page_Task.Business.Services;
using Registration_Page_Task.DataAccess.Interfaces;
using Registration_Page_Task.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Register repository and service dependencies
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();

// Add controller support
builder.Services.AddControllers();

// Add Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect HTTP to HTTPS
app.UseHttpsRedirection();

// Enable authorization middleware
app.UseAuthorization();

// Map API controllers
app.MapControllers();

// Run the application
app.Run();
