using ScreenSound.Banco;
using ScreenSound.Menus;
using ScreenSound.Modelos;

/*
 * Criar o banco ScreenSound através do Pesquisador de objetos do SQL Server e a tabela de artistas pelo script disponibilizado na atividade Preparando o ambiente: Scripts do banco de dados;
  * Instalar o pacote System.Data.SqlClient no projeto através do Gerenciador de pacotes do NuGet;
  * Criar a pasta Banco e a classe Connection com os dados de conexão com o banco de dados;
  * Criar a classe ArtistaDAL e os métodos para listar e adicionar artistas;
  * Testar no Program e verificar se tudo ocorreu como o esperado.
*/
try
{
    var artistaDAL = new ArtistaDAL();
  //  artistaDAL.AdicionarArtista(new Artista("Foo Fighters", "Foo Fighters é uma banda de rock alternativo americana formada por Dave Grohl em 1995."));
    
    var listaArtistas = artistaDAL.ListarArtistas();

    artistaDAL.LocalizarArtistaPorId(1);

    var artistaAtualizado = new Artista("Gabriela Rocha", "dsadadaafasdfdajçlkjljçk") { Id = 3 };
    artistaDAL.AtualizarArtista(artistaAtualizado);

    artistaDAL.ListarArtistas();

    artistaDAL.DeletarArtista(artistaAtualizado);

    artistaDAL.ListarArtistas();
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}

return; //somente pra os testes

Artista ira = new Artista("Ira!", "Banda Ira!");
Artista beatles = new("The Beatles", "Banda The Beatles");

Dictionary<string, Artista> artistasRegistrados = new();
artistasRegistrados.Add(ira.Nome, ira);
artistasRegistrados.Add(beatles.Nome, beatles);

Dictionary<int, Menu> opcoes = new();
opcoes.Add(1, new MenuRegistrarArtista());
opcoes.Add(2, new MenuRegistrarMusica());
opcoes.Add(3, new MenuMostrarArtistas());
opcoes.Add(4, new MenuMostrarMusicas());
opcoes.Add(-1, new MenuSair());

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 3.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar um artista");
    Console.WriteLine("Digite 2 para registrar a música de um artista");
    Console.WriteLine("Digite 3 para mostrar todos os artistas");
    Console.WriteLine("Digite 4 para exibir todas as músicas de um artista");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
        menuASerExibido.Executar(artistasRegistrados);
        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    } 
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

ExibirOpcoesDoMenu();