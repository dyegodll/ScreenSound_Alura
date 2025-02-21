namespace ScreenSound.API.Requests
{
    using System.ComponentModel.DataAnnotations;

    public record MusicaRequest([Required] string nome, [Required] int ArtistaId, int anoLancamento, ICollection<GeneroRequest> Generos = null);
}
