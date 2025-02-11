using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

internal class Connection
{
    // caminho salvo nas propriedades da database em SQL SERVER Object Explorer
    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSound;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    //inicia a conexão com o banco
    public SqlConnection GetSqlConnection()
    {
        return new SqlConnection(connectionString);
    }


}