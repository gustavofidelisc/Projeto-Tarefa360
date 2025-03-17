using DataAccess.Contexto;
using DataAccess.Repositorio;
using Microsoft.EntityFrameworkCore;
using Projeto.Aplicacao;
using Projeto360.Aplicacao;
using Projeto360.Dominio;
using Projeto360.Servicos.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add aplications.
builder.Services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
builder.Services.AddScoped<ITarefaAplicacao, TarefaAplicacao>();

// add interfaces db
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

//adicione os servicos
builder.Services.AddScoped<IJsonPlaceHolderServico, JsonPlaceHolderServico>();

builder.Services.AddControllers();

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(builder => {
        builder.WithOrigins("http://localhost:5173")
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


// Add db service

builder.Services.AddDbContext<Projeto360Contexto>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));  

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
