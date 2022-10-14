using Api_AngularTestProject.Data;
using Api_AngularTestProject.Interfaces;
using Api_AngularTestProject.Repos;
using Microsoft.EntityFrameworkCore;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inject Db
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});


builder.Services.AddCors(setup => setup.AddPolicy("Default", (options =>
{
    options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();

})));
builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseCors("Default");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints => endpoints.MapControllerRoute(
    name: "Default",
    pattern: "{controller}/{id?}"));

app.Run();
