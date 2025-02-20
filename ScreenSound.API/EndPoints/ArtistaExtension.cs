using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.EndPoints;

public static class ArtistaExtension
{
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

        app.MapPost("/Artistas", ([FromServices] DAL<Artista> artistaDAL, [FromBody] ArtistaRequest artistaRequest) =>
        {
            var artista = new Artista(artistaRequest.nome, artistaRequest.bio);
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
