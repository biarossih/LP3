using exe03.Database;
using exe03.Models;
using Microsoft.Data.Sqlite;;
using DBlesson.Repositories;

var dbConfig = new DatabaseConfig();
var dbSetup = new DatabaseSetup(dbConfig);
var clienteRepository = new ClienteRepository(dbConfig);
var pedidoRepository = new PedidoRepository(dbConfig);

var modelName = args[0];
var modelAction = args[1];

if (modelName.ToLower() == "cliente") {
    if (modelAction.ToLower() == "list") {
        Console.WriteLine("Cliente List");
        foreach ( var cliente in clienteRepository.GetAll()) {
            Console.WriteLine($"{cliente.ClienteId}, {cliente.Endereco}, {cliente.Cidade}, {cliente.Regiao}, {cliente.CodigoPostal}, {cliente.Pais},  {cliente.Telefone}");
        }
    }else if (modelAction.ToLower() == "insert") {
        Console.WriteLine("Insert new Cliente");
        var id = Convert.ToInt32(Console.ReadLine());
        string endereco = Console.ReadLine();
        string cidade = Console.ReadLine();
        string regiao = Console.ReadLine();
        string codigoPostal = Console.ReadLine();
        string pais = Console.ReadLine();
        string telefone = Console.ReadLine();
        var cliente = new Cliente(id, endereco, cidade, regiao, codigoPostal, pais, telefone);
        clienteRepository.Save(cliente);

    }
}else if (modelName.ToLower() == "pedido") {
    if(modelAction.ToLower() == "list") {
        Console.WriteLine("Pedidos List");
        foreach (var pedido in pedidoRepository.GetAll()) {
            Console.WriteLine($"{pedido.PedidoId}, {pedido.EnderecoId}, {pedido.DataPedido}, {pedido.Peso}, {pedido.CodTransportadora}, {pedido.PedidoClienteId}");
        }
    }else if (modelAction.ToLower() == "insert") {
        Console.WriteLine("Insert new pedido");
        var pedId = Convert.ToInt32(Console.ReadLine());
        var enderecoId = Convert.ToInt32(Console.ReadLine());
        string dataPedido = Console.ReadLine();
        string peso = Console.ReadLine();
        var codigoTransportadora = Convert.ToInt32(Console.ReadLine());
        var pedidoClienteId = Convert.ToInt32(Console.ReadLine());
        var pedido = new Pedido(pedId, enderecoId, dataPedido, peso, codigoTransportadora, pedidoClienteId);
        pedidoRepository.Save(pedido);
    }
}
