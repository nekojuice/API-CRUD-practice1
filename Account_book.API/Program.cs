using Account_book.API.Infrastructures.DependencyInjection;
using Account_book.API.Infrastructures.Logging;
using Account_book.API.Infrastructures.NSwag;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var env = builder.Environment;
SerilLogHelper.ConfigureSerilLogger(config);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// NSwag
builder.Services.NSwagConfigSetting(env);
// �ۭq DI
builder.Services.CustomDIConfigurator();
// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// SerilLog 
builder.Services.AddSerilog();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

// Logging
// https://stackoverflow.com/questions/60076922/serilog-logging-web-api-methods-adding-context-properties-inside-middleware
app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseSerilogRequestLogging(opts => opts.EnrichDiagnosticContext = SerilLogHelper.EnrichFromRequest);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
