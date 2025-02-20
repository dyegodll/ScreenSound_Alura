using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.EndPoints;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;

/*
 O WebApplication é uma classe fundamental no ASP.NET Core Minimal APIs. Ele representa sua aplicação web e permite configurar rotas, serviços, middleware e outras funcionalidades.

 Na sua API, você usa WebApplication para definir e gerenciar endpoints HTTP, como /artistas e /artistas/{id}.

    - WebApplication é a classe principal que gerencia sua API.
    - Você cria e configura ela com CreateBuilder() e Build().
    - Os endpoints são adicionados via MapGet(), MapPost(), etc.
    - O método Run() inicia o servidor e começa a atender requisições.
*/

var builder = WebApplication.CreateBuilder(args);

//Injeção de dependências
builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//resolve erro de referência cíclica entre Artista e Música
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.AddEndPointArtista();
app.AddEndPointMusica();

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
