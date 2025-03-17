using IPL.Models;
using IPL.Common.Interfaces;
using IPL.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CustomPolicy", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
#endregion 

#region Configure Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CricketContext>(options =>
    options.UseSqlServer(connectionString));
#endregion

// Add services to the container.
#region Register Services
builder.Services.AddTransient<ITeamApi, TeamApi>();
//builder.Services.AddTransient<ISalary, SalaryService>();
//builder.Services.AddTransient<IDepartment, DepartmentService>();
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
