using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add Infrasctrcure services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Controller to the service collection
builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());});

var app = builder.Build();

app.UseExceptionHandlingMiddleware();
//Routing
app.UseRouting();
//Auth
app.UseAuthentication();
app.UseAuthorization();

//Routing for Controllers
app.MapControllers();
app.Run();
