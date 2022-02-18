using Microsoft.OpenApi.Models;
using Pokemon.Pokemon.Infraestructure;
using Pokemon.Type.Application;
using Pokemon.Type.Domain;
using Pokemon.Type.Infraestucture;

var builder = WebApplication.CreateBuilder(args);
//var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

//// Add services to the container.
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: myAllowSpecificOrigins, builder =>
//        {
//            builder.AllowAnyOrigin()
//                   .AllowAnyHeader()
//                   .AllowAnyMethod();
//        });
//});

builder.Services.AddControllers();

builder.Services.AddApplications();
builder.Services.AddDomains();
builder.Services.AddInfraestructure();

builder.Services.AddHttpClient();


builder.Services.AddTransient<GetTypesByPokemonNameUseCase>();
builder.Services.AddTransient<FindByPokemonName>();
builder.Services.AddHttpClient<PokeApiHttpClient>();
builder.Services.AddScoped<ITypeRepository, PokeApiTypeRepository>();


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Pokemon API",
        Description = "Web API for Pokemon",
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//app.UseCors(myAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
