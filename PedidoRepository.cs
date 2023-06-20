using Aula10DB.Database;
using Aula10DB.Models;
using Microsoft.Data.Sqlite;
namespace Aula10DB.Repositories;
class PedidoRepository
{
    private readonly DatabaseConfig _databaseConfig;
    public PedidoRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public List<Pedido> GetAll()
    {
        var pedidos = new List<Pedido>();
        

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Pedidos";

        var reader = command.ExecuteReader();

        while(reader.Read())
        {
            var codpedido = reader.GetInt32(0);
            var prazoentrega = reader.GetDateTime(1);
            var datapedido = reader.GetDateTime(2);
            var pedidocodcliente = reader.GetInt32(3);
            var pedidocodvendedor = reader.GetInt32(4);
            var pedido = ReaderToPedido(reader);
            pedidos.Add(pedido);
        }

        connection.Close();
        
        return pedidos;
    }

    public Pedido Save(Pedido pedido)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Pedidos VALUES($codpedido, $prazoentrega, $datapedido, $pedidocodcliente, $pedidocodvendedor)";
        command.Parameters.AddWithValue("$codpedido", pedido.Codpedido);
        command.Parameters.AddWithValue("$prazoentrega", pedido.Prazoentrega);
        command.Parameters.AddWithValue("$datapedido", pedido.Datapedido);
        command.Parameters.AddWithValue("$pedidocodcliente", pedido.PedidocodCliente);
        command.Parameters.AddWithValue("$pedidocodvendedor", pedido.PedidocodVendedor);
        

        command.ExecuteNonQuery();
        connection.Close();

        return pedido;
    }

    
    public Pedido GetById(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Pedidos WHERE (id = $id)";
        command.Parameters.AddWithValue("$id", id);

        var reader = command.ExecuteReader();
        reader.Read();

        var pedido = ReaderToPedido(reader);

        connection.Close(); 

        return pedido;
    }
    public  Pedido Update(Pedido pedido)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Pedidos VALUES($codpedido, $prazoentrega, $datapedido, $pedidocodcliente, $pedidocodvendedor)";
        command.CommandText = "UPDATE Pedidos SET prazoentrega = $prazoentrega, datapedido = $datapedido, pedidocodcliente = $pedidocodcliente, pedidocodvendedor = $pedidocodvendedor  WHERE (codpedido = $codpedido)";
        command.Parameters.AddWithValue("$codpedido", pedido.Codpedido);
        command.Parameters.AddWithValue("$prazoentrega", pedido.Prazoentrega);
        command.Parameters.AddWithValue("$datapedido", pedido.Datapedido);
        command.Parameters.AddWithValue("$pedidocodcliente", pedido.PedidocodCliente);
        command.Parameters.AddWithValue("$pedidocodvendedor", pedido.PedidocodVendedor);
        
        command.ExecuteNonQuery();
        connection.Close();

        return pedido;
    }

    public bool ExitsById(int codpedido)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT count(codpedido) FROM Pedidos WHERE (codpedido = $codpedido)";
        command.Parameters.AddWithValue("$codpedido", codpedido);

        var reader = command.ExecuteReader();
        reader.Read();
        var result = reader.GetBoolean(0);

        return result;
    }
private Pedido ReaderToPedido(SqliteDataReader reader)
    {
        var pedido = new Pedido(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetInt32(4));

        return pedido;
    }
 }