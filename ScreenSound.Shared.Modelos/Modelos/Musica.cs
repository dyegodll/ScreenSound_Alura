namespace ScreenSound.Modelos;

public class Musica
{
    public Musica()
    {
        
    }
    public Musica(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; set; }
    public int Id { get; set; }
    public int? AnoLancamento { get; set; }
    public int? ArtistaId { get; set; }
    public virtual Artista? Artista { get; set; } //virtual  para ser modificado pelo EF CORE

    public virtual ICollection<Genero> Generos { get; set; } //virtual  para ser modificado pelo EF CORE

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"\t♦ {Nome} - Ano de Lançamento: {AnoLancamento}");
    }

    public override string ToString()
    {
        return $"♥ Música {Id}: {Nome} - Cantor: {Artista.Nome}";
    }
}