using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Inje��o de depend�ncias
builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();

//resolve erro de refer�ncia c�clica entre Artista e M�sica
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

/*
    A partir da configura��o via builder.Services, falamos que todos os nossos 
    endpoints dependem de um servi�o para funcionar, que definimos utilizando o 
    atributo [FromService] para invocar o objeto DAL que vai ser criado pela 
    pr�pria aplica��o. 
*/

app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) => 
{
    return Results.Ok(dal.Listar());
});

app.MapGet("/Artistas/{nome}", ([FromServices]DAL<Artista> dal, string nome) => 
{
    var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
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
