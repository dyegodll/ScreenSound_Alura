using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class IncluirArtistaEmMusica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 1 WHERE Id IN (1,2)");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 2 WHERE Id IN (3,4)");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 3 WHERE Id IN (5,6,7)");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 4 WHERE Id IN (8,9)");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 5 WHERE Id IN (10,11,12)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Musicas");
        }
    }
}
