using Play.Catalog.Service.Entities;
using Play.Common.MongoDB;
using Play.Common.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// Configuration
var serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

builder.Services.AddMongo().AddMongoRepository<Item>("items");

var app = builder.Build();
app.MapControllers();

app.UseHttpsRedirection();

app.Run();