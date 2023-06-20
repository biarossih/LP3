using Aula10DB.Database;
using Aula10DB.Models;
using Microsoft.Data.Sqlite;
namespace Aula10DB.Repositories;
class ItemPedidoRepository
{
    private readonly DatabaseConfig _databaseConfig;
    public ItemPedidoRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }
    public List<ItemPedido> GetAll()
    {
        var itempedidos = new List<ItemPedido>();
       

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Itenspedidos";
        var reader = command.ExecuteReader();
        while(reader.Read())
        {
            var coditempedido = reader.GetInt32(0);
            var itempedidocodpedido = reader.GetInt32(1);
            var itempedidocodproduto = reader.GetInt32(2);
            var quantidade = reader.GetInt32(3);
            var itempedido = new ItemPedido(coditempedido, itempedidocodpedido, itempedidocodpedido, quantidade);
            itempedidos.Add(itempedido);
        }
        connection.Close();
       
        return itempedidos;
    }
    public ItemPedido Save(ItemPedido itempedido)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Itenspedidos VALUES($coditempedido, $itempedidocodpedido,$itempedidocodproduto, $quantidade)";
        command.Parameters.AddWithValue("$coditempedido", itempedido.Coditempedido);
        command.Parameters.AddWithValue("$itempedidocodpedido", itempedido.Itempedidocodpedido);
        command.Parameters.AddWithValue("$itempedidocodproduto", itempedido.Itempedidocodproduto);
        command.Parameters.AddWithValue("$quantidade", itempedido.Quantidade);
       
        command.ExecuteNonQuery();
        connection.Close();
        return itempedido;
    }

    public ItemPedido GetById(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Itenspedidos WHERE (id = $id)";
        command.Parameters.AddWithValue("$id", id);
        var reader = command.ExecuteReader();
        reader.Read();
        var itenspedido = ReaderToItemPedido(reader);
        connection.Close();
        return itenspedido;
    }
   
    public bool ExitsById(int coditempedido)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "SELECT count(coditempedido) FROM Itenspedidos WHERE (coditempedido = $coditempedido)";

        command.Parameters.AddWithValue("coditempedido", coditempedido);
        var reader = command.ExecuteReader();
        reader.Read();
        var result = reader.GetBoolean(0);
        return result;
    }
    private ItemPedido ReaderToItemPedido(SqliteDataReader reader)
    {
        var itenspedido = new ItemPedido(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
        return itenspedido;
    }
}