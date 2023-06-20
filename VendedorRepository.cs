using Aula10DB.Database;
using Aula10DB.Models;
using Microsoft.Data.Sqlite;
namespace Aula10DB.Repositories;
class VendedorRepository
{
    private readonly DatabaseConfig _databaseConfig;
    public VendedorRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public List<Vendedor> GetAll()
    {
        var vendedores = new List<Vendedor>();
        

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Vendedores";

        var reader = command.ExecuteReader();

        while(reader.Read())
        {
             var codvendedor = reader.GetInt32(0);
            var nome = reader.GetString(2);
            var salariofixo = reader.GetFloat(3);
            var faixacomissao = reader.GetFloat(2);
            var vendedor = ReaderToVendedor(reader);
            vendedores.Add(vendedor);
        }

        connection.Close();
        
        return vendedores;
    }

    public Vendedor Save(Vendedor vendedor)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Vendedores VALUES($codvendedor, $nome, $salariofixo, $faixacomissao)";
        command.Parameters.AddWithValue("$codvendedor", vendedor.Codvendedor);
        command.Parameters.AddWithValue("$nome", vendedor.Nome);
        command.Parameters.AddWithValue("$salariofixo", vendedor.Salariofixo);
        command.Parameters.AddWithValue("$faixacomissao", vendedor.Faixacomissao);
       
        command.ExecuteNonQuery();
        connection.Close();

        return vendedor;
    }

    
    public Vendedor GetById(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Vendedores WHERE (id = $id)";
        command.Parameters.AddWithValue("$id", id);

        var reader = command.ExecuteReader();
        reader.Read();

        var vendedor = ReaderToVendedor(reader);

        connection.Close(); 

        return vendedor;
    }
    public  Vendedor Update(Vendedor vendedor)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Vendedores VALUES($codvendedor, $nome, $salariofixo, $faixacomissao)";
        command.CommandText = "UPDATE Vendedores SET nome = $nome, salariofixo = $salariofixo, faixacomissao = $faixacomissao  WHERE (codvendedor = $codvendedor)";
        command.Parameters.AddWithValue("$codvendedor", vendedor.Codvendedor);
        command.Parameters.AddWithValue("$nome", vendedor.Nome);
        command.Parameters.AddWithValue("$salariofixo", vendedor.Salariofixo);
        command.Parameters.AddWithValue("$faixacomissao", vendedor.Faixacomissao);

        command.ExecuteNonQuery();
        connection.Close();

        return vendedor;
    }

    public bool ExitsById(int codvendedor)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT count(codvendedor) FROM Vendedores WHERE (codvendedor = $codvendedor)";
        command.Parameters.AddWithValue("$codvendedor", codvendedor);

        var reader = command.ExecuteReader();
        reader.Read();
        var result = reader.GetBoolean(0);

        return result;
    }
private Vendedor ReaderToVendedor(SqliteDataReader reader)
    {
        var vendedor = new Vendedor(reader.GetInt32(0), reader.GetString(1), reader.GetFloat(2), reader.GetString(3));

        return vendedor;
    }
 }