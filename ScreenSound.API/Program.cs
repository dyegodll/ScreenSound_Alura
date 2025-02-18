using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//resolve erro de referência cíclica entre Artista e Música
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

//lista Artistas
app.MapGet("/", () => 
{
    var artistaDAL = new DAL<Artista>(new ScreenSoundContext());
    return artistaDAL.Listar(); 
});

app.Run();
