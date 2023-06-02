using Microsoft.Data.Sqlite;
using DBlesson.Database;
using DBlesson.Repositories;
using DBlesson.Models;

var dbConfig = new DatabaseConfig();
var dbSetup = new DatabaseSetup(dbConfig);
var customerRepository = new CustomerRepository(dbConfig);
var orderRepository = new OrderRepository(dbConfig);

var modelName = args[0];
var modelAction = args[1];

if (modelName.ToLower() == "customer") {
    if (modelAction.ToLower() == "list") {
        Console.WriteLine("Customer List");
        foreach ( var customer in customerRepository.GetAll()) {
            Console.WriteLine($"{customer.Id}, {customer.Address}, {customer.City}, {customer.Region}, {customer.ZipCode}, {customer.Country},  {customer.Phone}");
        }
    }else if (modelAction.ToLower() == "insert") {
        Console.WriteLine("Insert new Customer");
        var id = Convert.ToInt32(Console.ReadLine());
        string address = Console.ReadLine();
        string city = Console.ReadLine();
        string region = Console.ReadLine();
        string zipcode = Console.ReadLine();
        string country = Console.ReadLine();
        string phone = Console.ReadLine();
        var customer = new Customer(id, address, city, region, zipcode, country, phone);
        customerRepository.Save(customer);

    }
}else if (modelName.ToLower() == "order") {
    if(modelAction.ToLower() == "list") {
        Console.WriteLine("Orders List");
        foreach (var order in orderRepository.GetAll()) {
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
