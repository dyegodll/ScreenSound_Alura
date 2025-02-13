using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System.Linq;

namespace ScreenSound.Banco;

internal class ArtistaDAL
{
    private readonly ScreenSoundContext _context;

    public ArtistaDAL(ScreenSoundContext context)
    {
        this._context = context;
    }

    public IEnumerable<Artista> ListarArtistas()
    {
        var lista = _context.Artistas.ToList();
        lista.ForEach(a => Console.WriteLine(a + "\n"));
        return lista;
    }

    public Artista? LocalizarArtistaPorId(int id)
    {
        return _context.Artistas.Find(id);
    }

    public Artista? RecuperarPeloNome(string nome)
    {
        return _context.Artistas.FirstOrDefault(artista => artista.Nome.Equals(nome));
    }

    public void AdicionarArtista(Artista artista)
    {
        _context.Artistas.Add(artista);
        _context.SaveChanges();
        Console.WriteLine($"Artista adicionado: {artista}\n");
    }

    public void AtualizarArtista(Artista artista)
    {
        _context.Artistas.Update(artista);
        _context.SaveChanges();
        Console.WriteLine($"Artista atualiizado: {artista}\n");
    }

    public void DeletarArtista(Artista artista)
    {       
        _context.Artistas.Remove(artista);
        _context.SaveChanges();
        Console.WriteLine("Artista removido com sucesso!\n");
    }

}
