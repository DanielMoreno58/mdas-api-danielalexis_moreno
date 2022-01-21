using Microsoft.OpenApi.Models;
using Pokemon.Type.application;
using Pokemon.Type.domain;
using Pokemon.Type.infraestucture;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<GetTypesByPokemonNameUseCase>();
builder.Services.AddTransient<FindByPokemonName>();
builder.Services.AddScoped<ITypeRepository, PokeApiTypeRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Pokemon Type API",
        Description = "Web API for Pokemon Type",
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
