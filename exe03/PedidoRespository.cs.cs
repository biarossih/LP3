using DBlesson.Database;
using DBlesson.Models;
using Microsoft.Data.Sqlite;

namespace exe03.Models;

class PedidoRepository {
    private readonly DatabaseConfig _databaseConfig;

    public PedidoRepository(DatabaseConfig databaseConfig) {
        _databaseConfig = databaseConfig;
    }

    public List<Pedido> GetAll() {
        var pedidos = new List<Pedido>();

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Pedidos";

        var reader = command.ExecuteReader();

        while(reader.Read()) {
            var pedId = reader.GetInt32(0);
            var enderecoId = reader.GetString(1);
            var dataPedido =  reader.GetString(2);
            var peso = reader.GetString(3);
            var codigoTransportadora = reader.GetString(4);
            var pedidoClienteId = reader.GetString(5);
            var Pedido = ReaderToPedido(reader);
            pedidos.Add(pedido);
        }

        connection.Close();
        return pedidos;
    }

    public Pedido Save(Pedido pedido) {
        var connection =  new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Pedidos VALUES($pedId, $enderecoId, $dataPedido, $peso, $codigoTransportadora)";
        command.Parameters.AddWithValue("$pedId", pedido.PedidoId);
        command.Parameters.AddWithValue("$enderecoId", pedido.EnderecoId);
        command.Parameters.AddWithValue("$dataPedido", pedido.DataPedido);
        command.Parameters.AddWithValue("$peso", pedido.Peso);
        command.Parameters.AddWithValue("$codigoTransportadora", pedido.CodTransportadora);
        command.Parameters.AddWithValue("$customer_id", pedidoClienteId.PedidoClienteId);

        command.ExecuteNonQuery();
        connection.Close();

        return pedido;
    }

    public Pedido GetById(int id) {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Pedidos WHERE (pedId = $pedId)";
        command.Parameters.AddWithValue("$pedId", id);

        var pedido = command.ExecuteReader();
        reader.Read();

        var Pedido = ReaderToPedido(reader);

        connection.Close();
        return pedido;
    }

    public Pedido Update(Pedido pedido) {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Pedido VALUES ($pedId, $employee_id, $order_date, $order_weigth, $carrier_code, $customer_id)";
        command.CommandText = "UPDATE Orders_tb SET employee_id = $employee_id, order_date = $order_date, order_weigth = $order_weigth,  carrier_code = $carrier_code, customer_id = $customer_id WHERE (order_id = $order_id)";
        command.Parameters.AddWithValue("$order_id", order.OrderId);
        command.Parameters.AddWithValue("$employee_id", order.EmployeeId);
        command.Parameters.AddWithValue("$order_date", order.OrderDate);
        command.Parameters.AddWithValue("$order_weigth", order.Weigth);
        command.Parameters.AddWithValue("$carrier_code", order.CarrierCode);
        command.Parameters.AddWithValue("$customer_id", order.CustomerId);

        command.ExecuteNonQuery();
        connection.Close();

        return order;
    }

    public void Delete( int id ){
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Order_tb WHERE (order_id = $order_id)";
        command.Parameters.AddWithValue("$id", id);

        command.ExecuteNonQuery();
        connection.Close();
    }

    public bool ExitsById( int id ) {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT count(id) FROM Pedido WHERE (Pedido = $pedId)";
        command.Parameters.AddWithValue("$id", id);

        var reader = command.ExecuteReader();
        reader.Read();
        var result = reader.GetBoolean(0);

        return result;
    }

    private Pedido ReaderToPedido(SqliteDataReader reader) {
        var pedido = new Pedido(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5));
        return pedido;
    }
}
