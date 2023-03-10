using Application;
using Application.Middlewares;
using Persistence;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var corsOrigin = "corsOrigin";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsOrigin,
                          policy =>
                          {
                              policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                          });
});

IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>(true)
    .Build();
builder.Services.AddPersistenceServices(configuration);
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp";
});
var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();


app.UseCors(corsOrigin);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();
app.UseSpaStaticFiles();
app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "ClientApp")),
    RequestPath = "",
    EnableDefaultFiles = true
});

app.Run();
