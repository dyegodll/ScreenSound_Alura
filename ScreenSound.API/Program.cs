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
/*
    O Lazy Loading (carregamento preguiçoso) é uma técnica onde os dados relacionados não são carregados imediatamente quando você recupera um objeto do banco de dados. Em vez disso, eles são carregados somente quando acessados pela primeira vez.

    No EF Core, isso é feito através de um proxy dinâmico, que adiciona um LazyLoader à entidade para interceptar o acesso a propriedades de navegação e carregar os dados sob demanda.
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