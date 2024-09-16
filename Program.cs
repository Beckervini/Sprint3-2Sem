using Microsoft.EntityFrameworkCore;
using Sprint1_2semestre.Data;
using Sprint1_2semestre.Services; // Adicionando o ConfigManager

var builder = WebApplication.CreateBuilder(args);

// Configura a string de conex�o (use sua string de conex�o real aqui)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Adiciona o ApplicationDbContext ao cont�iner de inje��o de depend�ncias
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(connectionString));  // Certifique-se de ter o pacote Oracle.EntityFrameworkCore instalado

// Adiciona o ConfigManager como Singleton no cont�iner de servi�os
builder.Services.AddSingleton<ConfigManager>();

// Adiciona servi�os de controladores e configura JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.WriteIndented = true;
    });

// Configura o CORS para permitir requisi��es de qualquer origem
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Adiciona o Swagger para a documenta��o da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura��es de desenvolvimento (Swagger e SwaggerUI)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilita o CORS com a pol�tica definida
app.UseCors("AllowAll");

// Adiciona middleware para autoriza��o
app.UseAuthorization();

// Mapeia os controladores da API
app.MapControllers();

// Executa a aplica��o
app.Run();
