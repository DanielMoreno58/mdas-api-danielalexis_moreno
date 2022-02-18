using Microsoft.OpenApi.Models;
using Pokemon.Pokemon.Infraestructure;
using Pokemon.Type.Infraestucture;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddPokemonApplication();
builder.Services.AddPokemonDomain();
builder.Services.AddPokemonInfraestructure();

builder.Services.AddHttpClient();

builder.Services.AddTypeApplication();
builder.Services.AddTypeDomain();
builder.Services.AddTypeInfraestructure();

builder.Services.AddHttpClient<PokeApiHttpClient>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
