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

public static class ArtistaExtension
{
    //Método de Extensão
    public static void AddEndPointArtista(this WebApplication app)
    {
        
        app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
        {
            return Results.Ok(dal.Listar());
        });

        app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
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

        app.MapPost("/Artistas", ([FromBody] Artista artista) =>
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
        
    }
}
