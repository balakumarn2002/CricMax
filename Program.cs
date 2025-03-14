using IPL.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models; // Change based on your project namespace

var builder = WebApplication.CreateBuilder(args);

#region Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CustomPolicy", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
#endregion 

#region Configure Database Connection
var connectionString = builder.Configuration.GetConnectionString("CricketDB");
builder.Services.AddDbContext<CricketContext>(options =>
    options.UseSqlServer(connectionString));
#endregion

// Add services to the container.
#region Register Services
builder.Services.AddTransient<IEmployee, EmployeeService>();
builder.Services.AddTransient<ISalary, SalaryService>();
builder.Services.AddTransient<IDepartment, DepartmentService>();
#endregion

builder.Services.AddControllers();

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CustomPolicy");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
