using StaffTrackApp.DAL.DataAccess.Abstractions;
using StaffTrackApp.DAL.DataAccess;
using StaffTrackApp.Common.Configurations;
using StaffTrackApp.SAL.Services;
using StaffTrackApp.SAL.Services.Abstractions;
using StaffTrackApp.SAL.Helpers;
using StaffTrackApp.SAL.Helpers.Abstractions;
using Microsoft.EntityFrameworkCore;
using StaffTrackApp.DAL.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("MSSQLConnection");

builder.Services.Configure<ExportConfiguration>(builder.Configuration.GetSection("ExportSettings"));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<ITextFileWriter, TextFileWriter>();

builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<ISalaryService, SalaryService>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IPositionService, PositionService>();

builder.Services.AddTransient<IStoredProceduresHelper>(provider =>
{
    return new StoredProceduresHelper(connectionString);
});

builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<ISalaryRepository, SalaryRepository>();
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<IPositionRepository, PositionRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
