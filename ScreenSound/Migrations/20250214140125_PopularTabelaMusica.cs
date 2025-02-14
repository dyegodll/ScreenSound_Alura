using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Artistas",new string[] {"Nome", "Bio", "FotoPerfil"}, new object[] { "Isadora Pompeo", "Isadora Pompeo é uma influenciadora digital, cantora e compositora de música cristã contemporânea. Ela lançou seu primeiro álbum de estúdio, Pra Te Contar os Meus Segredos, em 2017.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" });     

            migrationBuilder.InsertData("Artistas",new string[] {"Nome", "Bio", "FotoPerfil"}, new object[] { "Aline Barros", "Aline Kistenmacker Barros dos Santos MT MmPE é uma cantora, compositora e pastora brasileira. Considerada uma das maiores cantoras de música cristã do Brasil, sendo certificada pela ABPD com vários discos de ouro, platina e diamante. Ganhou por 8 vezes o Grammy de Melhor Álbum de Música Gospel.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" });     
    
            migrationBuilder.InsertData("Artistas",new string[] {"Nome", "Bio", "FotoPerfil"}, new object[] { "Fernandinho", "Fernando Jerônimo dos Santos Júnior, conhecido popularmente como Fernandinho, é um cantor brasileiro de música cristã contemporânea, compositor e pastor evangélico. É membro da da Igreja Mananciais, na Barra da Tijuca, Rio de Janeiro.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" });

            migrationBuilder.InsertData("Artistas",new string[] {"Nome", "Bio", "FotoPerfil"}, new object[] { "Gabriela Rocha", "Gabriela Rocha Correa Moreira é uma cantora e compositora brasileira de música cristã contemporânea. Gravou com artistas internacionais como Elevation Worship, CeCe Winans e Michael W. Smith. Seu canal no YouTube tem mais de 3 bilhões de visualizações.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" });

            migrationBuilder.InsertData("Artistas",new string[] {"Nome", "Bio", "FotoPerfil"}, new object[] { "Anderson Freire", "Anderson Ricardo Freire é um cantor e compositor brasileiro, conhecido como intérprete de música cristã contemporânea para uma série de artistas. É Membro da Igreja Metodista Wesleyana. Fez parte da banda Vocal Asafe e da banda Giom, e saiu para ingressar em carreira solo.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Artistas");
        }
    }
}
