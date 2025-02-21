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
/*
    O Lazy Loading (carregamento pregui�oso) � uma t�cnica onde os dados relacionados n�o s�o carregados imediatamente quando voc� recupera um objeto do banco de dados. Em vez disso, eles s�o carregados somente quando acessados pela primeira vez.

    No EF Core, isso � feito atrav�s de um proxy din�mico, que adiciona um LazyLoader � entidade para interceptar o acesso a propriedades de navega��o e carregar os dados sob demanda.
*/
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.SerializerOptions.WriteIndented = true;
});

var app = builder.Build();

app.AddEndPointsArtista();
app.AddEndPointsMusicas();

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.Run();