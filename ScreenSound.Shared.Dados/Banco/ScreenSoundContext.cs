﻿using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

public class ScreenSoundContext: DbContext
{
    //propriedade ORM que se comunica com o banco relacional. Obs: deve ter o mesmo nome da tabela para que o EF identifique e associe os dois
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Genero> Generos { get; set; }

    // caminho salvo nas propriedades da database em SQL SERVER Object Explorer
    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSoundV0;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    //inicia a conexão com o banco
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {      
        optionsBuilder.
            UseSqlServer(connectionString)
            .UseLazyLoadingProxies(); //carregamento lento das informações e conexão com o banco
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Musica>()
        .HasMany(c => c.Generos)
        .WithMany(c => c.Musicas);
    }

    //CRIAR NOVAS MIGRATIONS
    //Add-Migration (NOME DA MIGRATION) -Project ScreenSound.Shared.Dados -StartupProject ScreenSound.API
}