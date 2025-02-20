using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.EndPoints;

/*
O que é um Método de Extensão?
Um método de extensão é uma forma de adicionar novas funcionalidades a uma classe existente sem precisar modificar o código original dessa classe.

No seu caso, o método AddEndPointArtista estende a classe WebApplication, permitindo que você adicione endpoints de forma organizada e modular.

Como Funciona?
Precisa ser um método static dentro de uma classe static

Isso porque métodos de extensão não pertencem diretamente à classe original, mas sim a uma classe auxiliar.
O primeiro parâmetro deve ter a palavra-chave this

O this indica qual classe está sendo estendida. No seu código, a classe WebApplication está sendo estendida.

Vantagens dos Métodos de Extensão
✅ Código mais organizado – Mantém os endpoints separados, facilitando a manutenção.
✅ Reutilizável – Pode ser chamado em diferentes partes do código sem precisar repetir lógica.
✅ Facilidade na leitura – Você pode estruturar sua API melhor, separando endpoints por tipo.

Resumo: Você está "ensinando" a classe WebApplication a fazer algo novo (AddEndPointArtista), sem precisar modificar o código original dela. 🚀
*/

public static class MusicaExtension
{
    //Método de Extensão
    public static void AddEndPointMusica(this WebApplication app)
    {
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

    }
}
