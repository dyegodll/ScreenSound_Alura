using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicasPorAno : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);

        ExibirTituloDaOpcao("Músicas por Ano de Lançamento");
        Console.Write("\nDigite o Ano para filtrar as Músicas: ");
        int ano = int.Parse(Console.ReadLine()!);

        var musicaDAL = new DAL<Musica>(new ScreenSoundContext());
        var musicas = musicaDAL.ListarPor(m => m.AnoLancamento == ano);

        Console.WriteLine($"\n\tMúsicas registradas Ano {ano}\n");
        if (musicas is not null)
        {
            foreach (var musica in musicas)
            {
                musica.ExibirFichaTecnica();
            }
        }
        else
        {
            Console.WriteLine($"\nNão foram localizadas Músicas!");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
