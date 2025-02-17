﻿using ScreenSound.Banco;
using ScreenSound.Menus;
using ScreenSound.Modelos;

/*
  <PackageReference Include="Microsoft.EntityFrameworkCore.Proxies" Version="7.0.14" />
    Utilizamos o pacote Proxies para utilizar o carregamento lento de informações na aplicação. 
    Ele permite que os recursos sejam utilizados realmente quando forem necessários, otimizando 
    o processo e sendo bastante útil quando temos recursos mais custosos na aplicação.

    O carregamento lento é uma técnica que carrega dados apenas quando eles são necessários, 
    o que é ideal para otimizar o desempenho e o uso de recursos.
*/

var _context = new ScreenSoundContext();
var artistaDAL = new DAL<Artista>(_context);
var musicaDAL = new DAL<Musica>(_context);
  

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
ExibirOpcoesDoMenu();

void ExibirOpcoesDoMenu()
{
    try
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
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }
}