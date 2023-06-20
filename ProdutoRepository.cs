using Aula10DB.Database;
using Aula10DB.Models;
using Microsoft.Data.Sqlite;
namespace Aula10DB.Repositories;
class ProdutoRepository
{
    private readonly DatabaseConfig _databaseConfig;
    public ProdutoRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public List<Produto> GetAll()
    {
        var produtos = new List<Produto>();

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Produtos";

        var reader = command.ExecuteReader();

        while(reader.Read())
        {
             var codproduto = reader.GetInt32(0);
            var descricao = reader.GetString(1);
            var valorunitario = reader.GetFloat(2);
            var produto = ReaderToProduto(reader);
            produtos.Add(produto);
        }

        connection.Close();
        
        return produtos;
    }

    public Produto Save(Produto produto)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Produtos VALUES($codproduto, $descricao, $valorunitario)";
        command.Parameters.AddWithValue("$codproduto", produto.Codproduto);
       command.Parameters.AddWithValue("$descricao", produto.Descricao);
       command.Parameters.AddWithValue("$valorunitario", produto.Valorunitario);

        command.ExecuteNonQuery();
        connection.Close();

        return produto;
    }

    
    public Produto GetById(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Produtos WHERE (id = $id)";
        command.Parameters.AddWithValue("$id", id);

        var reader = command.ExecuteReader();
        reader.Read();

        var produto = ReaderToProduto(reader);

        connection.Close(); 

        return produto;
    }
    public  Produto Update(Produto produto)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Produtos VALUES($codproduto, $descricao, $valorunitario)";
        command.CommandText = "UPDATE Produtos SET descricao = $descricao, valorunitario = $valorunitario  WHERE (codprotudo = $codproduto)";
        command.Parameters.AddWithValue("$codproduto", produto.Codproduto);
        command.Parameters.AddWithValue("$descricao", produto.Descricao);
        command.Parameters.AddWithValue("$valorunitario", produto.Valorunitario);

        command.ExecuteNonQuery();
        connection.Close();

        return produto;
    }

    public bool ExitsById(int codproduto)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT count(codproduto) FROM Produtos WHERE (codproduto = $codproduto)";
        command.Parameters.AddWithValue("$codproduto", codproduto);

        var reader = command.ExecuteReader();
        reader.Read();
        var result = reader.GetBoolean(0);

        return result;
    }
private Produto ReaderToProduto(SqliteDataReader reader)
    {
        var produto = new Produto(reader.GetInt32(0), reader.GetString(1), reader.GetFloat(2));

        return produto;
    }
 }