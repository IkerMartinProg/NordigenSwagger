using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Información que se muestra en la interfaz del usuario.
builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v3",
            Title = "Lista de APIs",
            Description = "Lista completa de funciones con APIs.",
            TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "Contacto",
                Url = new Uri("https://example.com/contact")
            },
            License = new OpenApiLicense
            { 
                Name = "Licencia",
                Url = new Uri("https://example.com/license") 
            }
        });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
