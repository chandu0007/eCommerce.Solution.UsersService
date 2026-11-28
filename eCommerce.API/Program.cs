using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add Infrasctrcure services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Controller to the service collection
builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());});
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(RegisterRequestMappingProfile).Assembly);
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
