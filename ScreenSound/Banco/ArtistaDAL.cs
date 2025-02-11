using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

internal class ArtistaDAL
{
    //SQLConnection - representa a conexão com o banco de dados;
    //SQLComand - representa a instrução SQL que será executada no banco de dados;
    //SQLDataReader - fornece um modo de ler as linhas do banco de dados.
    public IEnumerable<Artista> ListarArtistas()
    {
        var lista = new List<Artista>();
        using var connection = new Connection().GetSqlConnection();
        connection.Open();

        string sql = "SELECT * FROM Artistas";
        SqlCommand command = new SqlCommand(sql, connection);
        using SqlDataReader dataReader = command.ExecuteReader();

        while (dataReader.Read())
        {
            string nomeArtista = Convert.ToString(dataReader["Nome"])!;
            string bioArtista = Convert.ToString(dataReader["Bio"])!;
            int idArtista = Convert.ToInt32(dataReader["Id"])!;
            
            Artista artista = new(nomeArtista, bioArtista) { Id = idArtista };
            lista.Add(artista);

            Console.WriteLine(artista+"\n");
        }

        return lista;
    }

    public Artista? LocalizarArtistaPorId(int id)
    {
        try
        {
            using var connection = new Connection().GetSqlConnection();
            connection.Open();

            string sql = $"SELECT * FROM Artistas WHERE Id = {id}";
            SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader dataReader = command.ExecuteReader();

            string nomeArtista = Convert.ToString(dataReader["Nome"])!;
            string bioArtista = Convert.ToString(dataReader["Bio"])!;
            int idArtista = Convert.ToInt32(dataReader["Id"])!;

            Artista artistaBanco = new(nomeArtista, bioArtista) { Id = idArtista };
            
            Console.WriteLine($"Artista localizado: {artistaBanco} \n");
            return artistaBanco;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message} \n");
            return null;
        }
    }

    public void AdicionarArtista(Artista artista)
    {
        using var connection = new Connection().GetSqlConnection();
        connection.Open();

        string sql = "INSERT INTO Artistas (Nome, FotoPerfil, Bio) VALUES (@nome, @perfilPadrao, @bio)";
        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@nome", artista.Nome);
        command.Parameters.AddWithValue("@perfilPadrao", artista.FotoPerfil);
        command.Parameters.AddWithValue("@bio", artista.Bio);

        Console.WriteLine($"Artista adicionado: {artista}");

        int retorno = command.ExecuteNonQuery();
        Console.WriteLine($"Linhas afetadas: {retorno}  \n");
    }

    public void AtualizarArtista(Artista artista)
    {
        try
        {
            using var connection = new Connection().GetSqlConnection();
            connection.Open();

            string sql = $"UPDATE Artistas SET Nome = @nome, Bio = @bio WHERE Id = @id";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", artista.Id);
            command.Parameters.AddWithValue("@nome", artista.Nome);
            command.Parameters.AddWithValue("@bio", artista.Bio);

            Console.WriteLine($"Artista atualizado: {artista}");

            int retorno = command.ExecuteNonQuery();
            Console.WriteLine($"Linhas afetadas: {retorno}  \n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}  \n");
        }

    }
    
    public void DeletarArtista(Artista artista)
    {
        try
        {
            using var connection = new Connection().GetSqlConnection();
            connection.Open();

            string sql = $"DELETE FROM Artistas WHERE Id = {artista.Id}";
            SqlCommand command = new SqlCommand(sql, connection);

            int retorno = command.ExecuteNonQuery();
            Console.WriteLine($"Linhas afetadas: {retorno}");

            Console.WriteLine($"Artista removido com sucesso! \n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}   \n");
        }

    }

}
