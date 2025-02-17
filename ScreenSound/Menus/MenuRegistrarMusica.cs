using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarMusica : Menu
{
    public DAL<Musica> musicaDAL = new DAL<Musica>(new ScreenSoundContext());
    public override void Executar(DAL<Artista> artistaDAL)
    {
		try
		{
            base.Executar(artistaDAL);
            ExibirTituloDaOpcao("Registro de Músicas");
            artistaDAL.Listar();
            Console.Write("♦ Digite o artista cuja música deseja registrar: \n");
            string nomeDoArtista = Console.ReadLine()!;
            var artistaRecuperado = artistaDAL.RecuperarPor(a => a.Nome.Equals(nomeDoArtista));
            if (artistaRecuperado is not null)
            {
                musicaDAL.Listar();
                Console.Write("\n♦ Digite o título da música: ");
                string tituloMusica = Console.ReadLine()!;
                Musica musica = musicaDAL.RecuperarPor(m => m.Nome.Equals(tituloMusica))!;
                Console.Write("♦ Digite o ano de Lançamento da música: \n");
                musica.AnoLancamento = int.Parse(Console.ReadLine()!);
                artistaRecuperado.AdicionarMusica(musica!);
                Console.WriteLine($"A música {musica.Nome} de {nomeDoArtista} foi registrada com sucesso!");
                Thread.Sleep(2000);
                Console.WriteLine("\n• Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"\nO artista {nomeDoArtista} não foi encontrado!\n");
                Console.WriteLine("\n• Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
            }
        }
		catch (Exception ex)
		{
            Console.WriteLine($"\nErro: {ex.Message}");
		}
    }
}
