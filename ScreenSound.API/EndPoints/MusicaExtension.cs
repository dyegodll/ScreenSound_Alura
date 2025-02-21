using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.EndPoints;

/*
O que é um Método de Extensão?
Um método de extensão é uma forma de adicionar novas funcionalidades a uma classe existente sem precisar modificar o código original dessa classe.

No seu caso, o método AddEndPointsArtista estende a classe WebApplication, permitindo que você adicione endpoints de forma organizada e modular.

Como Funciona?
Precisa ser um método static dentro de uma classe static

Isso porque métodos de extensão não pertencem diretamente à classe original, mas sim a uma classe auxiliar.
O primeiro parâmetro deve ter a palavra-chave this

O this indica qual classe está sendo estendida. No seu código, a classe WebApplication está sendo estendida.

Vantagens dos Métodos de Extensão
✅ Código mais organizado – Mantém os endpoints separados, facilitando a manutenção.
✅ Reutilizável – Pode ser chamado em diferentes partes do código sem precisar repetir lógica.
✅ Facilidade na leitura – Você pode estruturar sua API melhor, separando endpoints por tipo.

Resumo: Você está "ensinando" a classe WebApplication a fazer algo novo (AddEndPointsArtista), sem precisar modificar o código original dela. 🚀
*/


public static class MusicasExtensions
{
    public static void AddEndPointsMusicas(this WebApplication app)
    {
        #region Endpoint Músicas
        app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) =>
        {
            var musicaList = dal.Listar();
            if (musicaList is null)
            {
                return Results.NotFound();
            }
            var musicaListResponse = EntityListToResponseList(musicaList);
            return Results.Ok(musicaListResponse);
        });

        app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
        {
            var musica = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (musica is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(EntityToResponse(musica));

        });

        app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] MusicaRequest musicaRequest) =>
        {
            var musica = new Musica(musicaRequest.nome)
            {
                ArtistaId = musicaRequest.ArtistaId,
                AnoLancamento = musicaRequest.anoLancamento,
                Generos = musicaRequest.Generos is not null ? GeneroRequestConverter(musicaRequest.Generos) :
                new List<Genero>()

            };
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

        app.MapPut("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] MusicaRequestEdit musicaRequestEdit) => {
            var musicaAAtualizar = dal.RecuperarPor(a => a.Id == musicaRequestEdit.Id);
            if (musicaAAtualizar is null)
            {
                return Results.NotFound();
            }
            musicaAAtualizar.Nome = musicaRequestEdit.nome;
            musicaAAtualizar.AnoLancamento = musicaRequestEdit.anoLancamento;

            dal.Atualizar(musicaAAtualizar);
            return Results.Ok();
        });
        #endregion

    }

    private static ICollection<Genero> GeneroRequestConverter(ICollection<GeneroRequest> generos)
    {
        return generos.Select(a => RequestToEntity(a)).ToList();
    }

    private static Genero RequestToEntity(GeneroRequest genero)
    {
        return new Genero() { Nome = genero.Nome, Descricao = genero.Descricao };
    }

    private static ICollection<MusicaResponse> EntityListToResponseList(IEnumerable<Musica> musicaList)
    {
        return musicaList.Select(a => EntityToResponse(a)).ToList();
    }

    private static MusicaResponse EntityToResponse(Musica musica)
    {
        return new MusicaResponse(musica.Id, musica.Nome!, musica.Artista!.Id, musica.Artista.Nome);
    }
}