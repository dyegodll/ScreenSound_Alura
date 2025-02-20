using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.EndPoints;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;

/*
 O WebApplication � uma classe fundamental no ASP.NET Core Minimal APIs. Ele representa sua aplica��o web e permite configurar rotas, servi�os, middleware e outras funcionalidades.

 Na sua API, voc� usa WebApplication para definir e gerenciar endpoints HTTP, como /artistas e /artistas/{id}.

    - WebApplication � a classe principal que gerencia sua API.
    - Voc� cria e configura ela com CreateBuilder() e Build().
    - Os endpoints s�o adicionados via MapGet(), MapPost(), etc.
    - O m�todo Run() inicia o servidor e come�a a atender requisi��es.
*/

var builder = WebApplication.CreateBuilder(args);

//Inje��o de depend�ncias
builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//resolve erro de refer�ncia c�clica entre Artista e M�sica
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.AddEndPointArtista();
app.AddEndPointMusica();

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
