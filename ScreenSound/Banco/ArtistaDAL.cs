using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

internal class ArtistaDAL
{
    private readonly ScreenSoundContext context;

    public ArtistaDAL(ScreenSoundContext _context)
    {
        context = _context;
    }

    public IEnumerable<Artista> ListarArtistas()
    {
        var list = context.Artistas.ToList();

        foreach (var artista in list)
        {
            Console.WriteLine(artista+"\n");
        }

        return list;
    }

    public Artista? LocalizarArtistaPorId(int id)
    {
        var artista = context.Artistas.Find(id);
        Console.WriteLine($"Artista localizado: {artista}\n");
        return artista;
    }

    public Artista? RecuperarPeloNome(string nome)
    {
        return context.Artistas.FirstOrDefault(artista => artista.Nome.Equals(nome));
    }

    public void AdicionarArtista(Artista artista)
    {
        context.Artistas.Add(artista);
        context.SaveChanges();
        Console.WriteLine($"Artista adicionado: {artista}\n");
    }

    public void AtualizarArtista(Artista artista)
    {
        context.Artistas.Update(artista);
        context.SaveChanges();
        Console.WriteLine($"Artista atualiizado: {artista}\n");
    }

    public void DeletarArtista(Artista artista)
    {       
        context.Artistas.Remove(artista);
        context.SaveChanges();
        Console.WriteLine("Artista removido com sucesso!\n");
    }

}
