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

if (modelName.ToLower() == "customer") {
    if (modelAction.ToLower() == "list") {
        Console.WriteLine("Customer List");
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
            Console.WriteLine($"{order.OrderId}, {order.EmployeeId}, {order.OrderDate}, {order.Weigth}, {order.CarrierCode}, {order.CustomerId}");
        }
    }else if (modelAction.ToLower() == "insert") {
        Console.WriteLine("Insert new order");
        var id = Convert.ToInt32(Console.ReadLine());
        var employeeId = Convert.ToInt32(Console.ReadLine());
        string orderDate = Console.ReadLine();
        string weigth = Console.ReadLine();
        var carrierCode = Convert.ToInt32(Console.ReadLine());
        var customerId = Convert.ToInt32(Console.ReadLine());
        var order = new Order(id, employeeId, orderDate, weigth, carrierCode, customerId);
        orderRepository.Save(order);
    }
}
