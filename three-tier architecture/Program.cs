using Microsoft.EntityFrameworkCore;
using three_tier_architecture.BLL.Interfaces;
using three_tier_architecture.BLL.Services;
using three_tier_architecture.DAL.ApplicaionDbContext;
using three_tier_architecture.DAL.Repositories;
using three_tier_architecture.DAL.Repositories.IRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Connection SQL
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"));
});
// 2. Register Repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// 3. Register Services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

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
