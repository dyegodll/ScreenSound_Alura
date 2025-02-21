﻿namespace ScreenSound.Modelos;

public class Artista 
{
    public Artista()
    {
            
    }
    public Artista(string nome, string bio)
    {
        Nome = nome;
        Bio = bio;
        FotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
    }

    public virtual ICollection<Musica> Musicas { get; set; } = new List<Musica>(); //virtual  para ser modificado pelo Proxy

    public string Nome { get; set; }
    public string? FotoPerfil { get; set; }
    public string Bio { get; set; }
    public int Id { get; set; }

    public void AdicionarMusica(Musica musica)
    {
        Musicas.Add(musica);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"\n☺ Discografia de {Nome}:");
        foreach (var musica in Musicas)
        {
            Console.WriteLine($"\t♦ {musica.Nome} - Ano de Lançamento: {musica.AnoLancamento}");
        }
    }

    public override string ToString()
    {
        return $@"Id: {Id}
            Nome: {Nome}
            Foto de Perfil: {FotoPerfil}
            Bio: {Bio}";
    }
}