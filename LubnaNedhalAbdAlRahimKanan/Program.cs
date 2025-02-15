using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using LubnaNedhalAbdAlRahimKanan.Data;
using LubnaNedhalAbdAlRahimKanan.Repositories;
using LubnaNedhalAbdAlRahimKanan.Services;

var builder = WebApplication.CreateBuilder(args);

// ✅ Configure Database (Replace "YourConnectionString" with the actual one)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Register Repositories (D — Dependency Injection in SOLID)
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IVacationRepository, VacationRepository>();

// ✅ Register Services (S — Single Responsibility: Business Logic in Services)
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IVacationService, VacationService>();

// ✅ Register Controllers (Explicitly enabling MVC Controllers)
builder.Services.AddControllers();

// ✅ Enable Swagger for API Documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee Management API", Version = "v1" });
});

var app = builder.Build();

// ✅ Configure Middleware (O — Open/Closed Principle: Separate concerns)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee Management API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// ✅ Initialize the Database with Code-First Migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate(); // This will apply any pending migrations to the database
}

app.Run();
