using ScreenSound.Banco;
using ScreenSound.Menus;
using ScreenSound.Modelos;

/*
- Como ainda não temos uma tabela de músicas, você pode criar uma nova tabela executando o script abaixo onde fazemos as consultas ao banco utilizando o Pesquisador de Objetos do SQLServer, como fizemos anteriormente para a tabela de músicas:
    
    create table Musicas(
            Id INT PRIMARY KEY IDENTITY(1,1),
            Nome NVARCHAR(255) NOT NULL
    );

- Criada a tabela, você deverá identificá-la na classe de contexto para que o Entity consiga relacionar a tabela a um objeto existente na aplicação;

- Feito isso, é preciso criar o MusicaDAL com todos os métodos relacionados à tabela de músicas;

- Testar o funcionamento dos métodos e da nova tabela.

Na hora de testar os métodos relacionados à tabela de músicas, você vai perceber que as manipulações na tabela Musicas ainda não estão funcionando através do menu. Mas não se preocupe! Os recursos que precisamos para fazer esse vínculo serão abordados nas aulas seguintes. Então, para testar esta atividade, você pode utilizar o mesmo recurso que estávamos usando anteriormente e realizar os testes diretamente no Program, fora do menu.
*/

try
{
    var _context = new ScreenSoundContext();
    var musicaDAL = new MusicaDAL(_context);

    //musicaDAL.AdicionarMusica(m1);
    //musicaDAL.AdicionarMusica(m2);
    //musicaDAL.AdicionarMusica(m3);
    
    musicaDAL.ListarMusicas();

    Musica m1 = musicaDAL.LocalizarMusicaPorNome("Lugar Secreto")!;
    m1.Nome = ("A Ele a Glória");
    
    //Musica m2 = musicaDAL.LocalizarMusicaPorNome("Diz")!;
    
    //Musica m3 = musicaDAL.LocalizarMusicaPorNome("Me Atraiu")!;
    //m3.Nome = ("Eu Navegarei");


    //musicaDAL.ListarMusicas();

    //musicaDAL.DeletarMusica(m2);

    musicaDAL.AtualizarMusica(m1);

    musicaDAL.ListarMusicas();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
return;

var context = new ScreenSoundContext();
var artistaDAL = new ArtistaDAL(context);

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
        menuASerExibido.Executar(artistaDAL);
        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    } 
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

ExibirOpcoesDoMenu();