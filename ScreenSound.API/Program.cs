using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//resolve erro de referência cíclica entre Artista e Música
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.MapGet("/Artistas", () => 
{
    var artistaDAL = new DAL<Artista>(new ScreenSoundContext());
    return Results.Ok(artistaDAL.Listar());
});

app.MapGet("/Artistas/{nome}", (string nome) => 
{
    var artistaDAL = new DAL<Artista>(new ScreenSoundContext());
    var artista = artistaDAL.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
    if (artista is null) return Results.NotFound();
    return Results.Ok(artista);
});

app.MapPost("/Artistas",([FromBody]Artista artista) =>
{
    var artistaDAL = new DAL<Artista>(new ScreenSoundContext());
    artistaDAL.Adicionar(artista);
    return Results.Created();
});

app.Run();
