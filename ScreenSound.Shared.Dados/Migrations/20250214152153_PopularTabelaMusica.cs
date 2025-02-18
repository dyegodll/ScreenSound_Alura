using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabelaMusica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Isadora Pompeo
            migrationBuilder.InsertData("Musicas", new string[] {"Nome", "AnoLancamento"}, new object[] {"Ovelhinha", 2023});
            migrationBuilder.InsertData("Musicas", new string[] {"Nome", "AnoLancamento"}, new object[] {"Benção Que Não Tem Fim", 2023});
            //Aline Barros
            migrationBuilder.InsertData("Musicas", new string[] {"Nome", "AnoLancamento"}, new object[] {"Soube Que Me Amava", 2007});
            migrationBuilder.InsertData("Musicas", new string[] {"Nome", "AnoLancamento"}, new object[] {"Jeová Jireh", 2022});
            //Fernandinho
            migrationBuilder.InsertData("Musicas", new string[] {"Nome", "AnoLancamento"}, new object[] {"Todas As Coisas", 2009});
            migrationBuilder.InsertData("Musicas", new string[] {"Nome", "AnoLancamento"}, new object[] {"Yeshua", 2021});
            migrationBuilder.InsertData("Musicas", new string[] {"Nome", "AnoLancamento"}, new object[] {"Galileu", 2015});
            //Gabriela Rocha
            migrationBuilder.InsertData("Musicas", new string[] {"Nome", "AnoLancamento"}, new object[] {"Me Atraiu", 2023});
            migrationBuilder.InsertData("Musicas", new string[] {"Nome", "AnoLancamento"}, new object[] {"Lugar Secreto", 2018});
            //Anderson Freire
            migrationBuilder.InsertData("Musicas", new string[] {"Nome", "AnoLancamento"}, new object[] {"Raridade", 2013});
            migrationBuilder.InsertData("Musicas", new string[] {"Nome", "AnoLancamento"}, new object[] {"Efésios 6", 2023});
            migrationBuilder.InsertData("Musicas", new string[] {"Nome", "AnoLancamento"}, new object[] {"Coração Valente", 2010});
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Musicas");
        }
    }
}
