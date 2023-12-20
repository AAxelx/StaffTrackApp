using StaffTrackApp.DAL.DataAccess.Abstractions;
using StaffTrackApp.DAL.DataAccess;
using StaffTrackApp.Common.Configurations;
using StaffTrackApp.SAL.Services;
using StaffTrackApp.SAL.Services.Abstractions;
using StaffTrackApp.SAL.Helpers;
using StaffTrackApp.SAL.Helpers.Abstractions;

var builder = WebApplication.CreateBuilder(args);

var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

var configuration = configurationBuilder.Build();

builder.Services.AddRazorPages();
builder.Services.Configure<CompanyConfiguration>(configuration.GetSection("CompanyConfig"));
builder.Services.Configure<ExportConfiguration>(configuration.GetSection("ExportSettings"));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<ITextFileWriter, TextFileWriter>();

builder.Services.AddTransient<IEmployeeService, EmployeeService>();

builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();

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
