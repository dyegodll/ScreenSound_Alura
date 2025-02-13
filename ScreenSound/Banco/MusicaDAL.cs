using ScreenSound.Modelos;
using System.Linq;

namespace ScreenSound.Banco;

class MusicaDAL
{
    public MusicaDAL(ScreenSoundContext context)
    {
        _context = context;
    }

    private readonly ScreenSoundContext _context;

    public IEnumerable<Musica> ListarMusicas()
    {
        var lista = _context.Musicas.ToList();
        lista.ForEach(m => Console.WriteLine(m + "\n"));
        return lista;
    }

    public void AdicionarMusica(Musica musica)
    {
        _context.Musicas.Add(musica);
        _context.SaveChanges();
        Console.WriteLine($"Música '{musica.Nome}' adicionada com sucesso!\n");
    }

    public Musica? LocalizarArtistaPorId(int id)
    {
        return _context.Musicas.Find(id);
    }

    public Musica? LocalizarMusicaPorNome(string nome)
    {
        var musica = _context.Musicas.FirstOrDefault(m => m.Nome.Equals(nome));
        if (musica is not null)
        {
            Console.WriteLine($"Música '{musica.Nome}' localizada no Banco de Dados.\n");
            return musica;
        }
        else Console.WriteLine($"Música '{nome}' não localizada!\n");
        
        return musica;
    }

    public void AtualizarMusica(Musica musica)
    {
        if (musica is not null)
        {
            _context.Musicas.Update(musica);
            _context.SaveChanges();
            Console.WriteLine($"Música {musica.Id} atualizada com sucesso para '{musica.Nome}'!\n");
        }
        else Console.WriteLine($"Música não localizada!\n");
    }

    public void DeletarMusica(Musica musica)
    {
        _context.Musicas.Remove(musica);
        _context.SaveChanges();
        Console.WriteLine($"Música '{musica.Nome}' removida do Banco de Dados!\n");
    }

}
