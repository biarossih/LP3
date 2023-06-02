using DBlesson.Database;
using DBlesson.Models;
using Microsoft.Data.Sqlite;

namespace DBlesson.Repositories;

class OrderRepository {
    private readonly DatabaseConfig _databaseConfig;

    public OrderRepository(DatabaseConfig databaseConfig) {
        _databaseConfig = databaseConfig;
    }

    public List<Order> GetAll() {
        var orders = new List<Order>();

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Order_tb";

        var reader = command.ExecuteReader();

        while(reader.Read()) {
            var id = reader.GetInt32(0);
            var address = reader.GetString(1);
            var city =  reader.GetString(2);
            var region = reader.GetString(3);
            var zipcode = reader.GetString(4);
            var country = reader.GetString(5);
            var phone = reader.GetString(6);
            var Order = ReaderToOrder(reader);
            orders.Add(Order);
        }

        connection.Close();
        return orders;
    }

    public Order Save(Order order) {
        var connection =  new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Order_tb VALUES($order_id, $employee_id, $order_date, $order_weigth, $carrier_code, $customer_id)";
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

    public Order GetById(int id) {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Order_tb WHERE (order_id = $order_id)";
        command.Parameters.AddWithValue("$order_id", id);

        var reader = command.ExecuteReader();
        reader.Read();

        var Order = ReaderToOrder(reader);

        connection.Close();
        return Order;
    }

    public Order Update(Order order) {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Order_tb VALUES ($order_id, $employee_id, $order_date, $order_weigth, $carrier_code, $customer_id)";
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
        command.CommandText = "SELECT count(id) FROM Order_tb WHERE (order_id = $order_id)";
        command.Parameters.AddWithValue("$id", id);

        var reader = command.ExecuteReader();
        reader.Read();
        var result = reader.GetBoolean(0);

        return result;
    }

    private Order ReaderToOrder(SqliteDataReader reader) {
        var order = new Order(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5));
        return order;
    }
}