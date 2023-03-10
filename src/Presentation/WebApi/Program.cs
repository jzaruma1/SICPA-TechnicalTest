using Application;
using Application.Middlewares;
using Persistence;
using Microsoft.Extensions.FileProviders;
using WebApi;
using Microsoft.EntityFrameworkCore.Design;
using Persistence.Context;

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

builder.Services.AddPersistenceServices(builder.Configuration);
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
