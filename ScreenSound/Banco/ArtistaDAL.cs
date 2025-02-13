using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System.Linq;

namespace ScreenSound.Banco;

internal class ArtistaDAL: DAL<Artista>
{
    private readonly ScreenSoundContext _context;

    public ArtistaDAL(ScreenSoundContext context)
    {
        this._context = context;
    }

    public override IEnumerable<Artista> Listar()
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

    public override void Adicionar(Artista artista)
    {
        _context.Artistas.Add(artista);
        _context.SaveChanges();
        Console.WriteLine($"Artista adicionado: {artista}\n");
    }

    public override void Atualizar(Artista artista)
    {
        _context.Artistas.Update(artista);
        _context.SaveChanges();
        Console.WriteLine($"Artista atualiizado: {artista}\n");
    }

    public override void Deletar(Artista artista)
    {       
        _context.Artistas.Remove(artista);
        _context.SaveChanges();
        Console.WriteLine("Artista removido com sucesso!\n");
    }

}
