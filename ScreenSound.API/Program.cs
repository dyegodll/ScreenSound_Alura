using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Injeção de dependências
builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();

//resolve erro de referência cíclica entre Artista e Música
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

/*
    A partir da configuração via builder.Services, falamos que todos os nossos 
    endpoints dependem de um serviço para funcionar, que definimos utilizando o 
    atributo [FromService] para invocar o objeto DAL que vai ser criado pela 
    própria aplicação. 
*/

app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) => 
{
    return Results.Ok(dal.Listar());
});

app.MapGet("/Artistas/{nome}", ([FromServices]DAL<Artista> dal, string nome) => 
{
    try
    {
        var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
        if (artista is null) return Results.NotFound();
        return Results.Ok(artista);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return null;
    }
});

app.MapPost("/Artistas",([FromBody]Artista artista) =>
{
    var artistaDAL = new DAL<Artista>(new ScreenSoundContext());
    artistaDAL.Adicionar(artista);
    return Results.Created();
});

app.MapDelete("/Artistas/{id}", (int id, [FromServices] DAL<Artista> dal) =>
{
    var artista = dal.RecuperarPor(a => a.Id == id);
    if (artista is null) return Results.NotFound();
    dal.Deletar(artista);
    return Results.NoContent();
});

app.MapPut("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] Artista artista) => 
{ 
    try
    {
        var artistaAAtualizar = dal.RecuperarPor(a => a.Id == artista.Id);
        if (artistaAAtualizar is null) return Results.NotFound();
        artistaAAtualizar.Nome = artista.Nome;
        artistaAAtualizar.Bio = artista.Bio;
        artistaAAtualizar.FotoPerfil = artista.FotoPerfil;
        dal.Atualizar(artistaAAtualizar);
        return Results.Ok();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return null;
    }
});

app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) =>
{
    return Results.Ok(dal.Listar());
});

app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
{
    var musica = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
    if (musica is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(musica);

});

app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] Musica musica) =>
{
    dal.Adicionar(musica);
    return Results.Ok();
});

app.MapDelete("/Musicas/{id}", ([FromServices] DAL<Musica> dal, int id) => {
    var musica = dal.RecuperarPor(a => a.Id == id);
    if (musica is null)
    {
        return Results.NotFound();
    }
    dal.Deletar(musica);
    return Results.NoContent();

});

app.MapPut("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] Musica musica) => {
    var musicaAAtualizar = dal.RecuperarPor(a => a.Id == musica.Id);
    if (musicaAAtualizar is null)
    {
        return Results.NotFound();
    }
    musicaAAtualizar.Nome = musica.Nome;
    musicaAAtualizar.AnoLancamento = musica.AnoLancamento;

    dal.Atualizar(musicaAAtualizar);
    return Results.Ok();
});

app.Run();
