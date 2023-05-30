using Microsoft.Data.Sqlite;

namespace exe03.Database;

class DatabaseSetup 
{
    private readonly DatabaseConfig _databaseConfig;

    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
        CreateClienteTable();
        CreatePedidoTable();
    }

    private void CreateClienteTable()
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Cliente (
                id int not null primary key,
                Endereco varchar(100) not null,
                Cidade varchar(50) not null,
                Regiao varchar(50) not null,
                CodigoPostal varchar(20) not null,
                Pais varchar(20) not null,
                Telefone varchar(15) not null
            )
        ";
    }

    private void CreatePedidoTable()
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Cliente (
                id int not null primary key,
                EmpregadoId int not null,
                CodTransportadora int not null,
                PedidoClienteId int not null,
                DataPedido varchar(12) not null,
                Peso varchar(7) not null,
            )
        ";
    }

}
