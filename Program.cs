using Microsoft.Data.Sqlite;
using Aula10DB.Database;
using Aula10DB.Repositories;
using Aula10DB.Models;

var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);
var clienteRepository = new ClienteRepository(databaseConfig);
var pedidoRepository = new PedidoRepository(databaseConfig);
var itempedidoRepository = new ItemPedidoRepository(databaseConfig);
var vendedorRepository = new VendedorRepository(databaseConfig);
var produtoRepository = new ProdutoRepository(databaseConfig);


var modelName = args[0];
var modelAction = args[1];

if (modelName == "Cliente")
{
    if (modelAction == "Listar")
    {
        Console.WriteLine("Cliente Listar");
        Console.WriteLine("Codigo Cliente   Nome do Cliente         Endereco                        Cidade        Cep            Uf       Ie");
        foreach (var cliente in clienteRepository.GetAll())
        {
            Console.WriteLine($"{cliente.Codcliente,-16} {cliente.Nome,-23} {cliente.Endereco,-31} {cliente.Cidade,-13} {cliente.Cep,-14} {cliente.Uf,-8} {cliente.Ie}");
        }
    }else if (modelAction == "Apresentar")
    {
        Console.WriteLine("Apresentar cliente");

        int idCliente;
        Console.Write("Digite o código do cliente : ");
        var idcliente = Console.ReadLine();
        while (!Int32.TryParse(idcliente, out idCliente))
        {
            Console.WriteLine("Id inválido digitado, tente novamente: ");
            idcliente = Console.ReadLine();
        }

        if (clienteRepository.ExitsById(idCliente) == true)
        {
            foreach (var cliente in clienteRepository.GetAll())
            {
                if (idCliente == cliente.Codcliente)
                {
                    Console.WriteLine($"{cliente.Codcliente}, {cliente.Nome}, {cliente.Endereco}, {cliente.Cidade}, {cliente.Cep}, {cliente.Uf}, {cliente.Ie}");
                }
            }
        }
        else
        {
            Console.WriteLine($"O Pedido com Id {idCliente} não existe.");
        }
    }else if (modelAction == "Inserir")
    {
        Console.WriteLine("Inserir Cliente");
        int codcliente;

        Console.Write("Digite o codigo do cliente  : ");
        codcliente = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite o nome do cliente    : ");
        var nome = Console.ReadLine();
        Console.Write("Digite o endereço do cliente: ");
        var endereco = Console.ReadLine();
        Console.Write("Digite a cidade do cliente  : ");
        var cidade = Console.ReadLine();
        Console.Write("Digite o CEP do cliente     : ");
        var cep = Console.ReadLine();
        Console.Write("Digite o UF do cliente      : ");
        var uf = Console.ReadLine();
        Console.Write("Digite a Inscrição Estadual : ");
        var ie = Console.ReadLine();

        var cliente = new Cliente(codcliente, nome, endereco, cidade, cep, uf, ie);
        clienteRepository.Save(cliente);

    }

}else if (modelName == "Pedido")
{
    if (modelAction == "Listar")
    {
        Console.WriteLine("Listar Pedido");
        Console.WriteLine("Cod Pedido   Prazo Entrega            Data Pedido             Pedido Cod Cliente       Pedido Cod Vendedor");
        foreach (var pedido in pedidoRepository.GetAll())
        {
            Console.WriteLine($"{pedido.Codpedido,-12} {pedido.Prazoentrega,-24} {pedido.Datapedido,-23} {pedido.PedidocodCliente,-24} {pedido.PedidocodVendedor}");
        }
    }else if (modelAction == "Inserir")
    {
        Console.WriteLine("Pedido Inserir");
        int codpedido;
        DateTime prazoentrega;
        DateTime datapedido = DateTime.Now;
        int pedidocodcliente;
        int pedidocodvendedor;

        Console.Write("Digite o código do pedido             : ");
        codpedido = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite o prazo de entrega do pedido   : ");
        prazoentrega = Convert.ToDateTime(Console.ReadLine());
        Console.Write("Digite o código do cliente do pedido  : ");
        pedidocodcliente = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite o código do vendedor do pedido : ");
        pedidocodvendedor = Convert.ToInt32(Console.ReadLine());
        var pedido = new Pedido(codpedido, prazoentrega, datapedido, pedidocodcliente, pedidocodvendedor);
        pedidoRepository.Save(pedido);

    }else if (modelAction == "Apresentar")
    {
        Console.WriteLine("Apresentar pedido");

        int codPED;
        Console.Write("Digite o código do pedido: ");
        var codped = Console.ReadLine();
        while (!Int32.TryParse(codped, out codPED))
        {
            Console.WriteLine("Id inválido digitado, tente novamente: ");
            codped = Console.ReadLine();
        }

        if (pedidoRepository.ExitsById(codPED) == true)
        {
            foreach (var pedido in pedidoRepository.GetAll())
            {
                if (codPED == pedido.Codpedido)
                {
                    Console.WriteLine($"{pedido.Codpedido}, {pedido.Datapedido}, {pedido.Prazoentrega}, {pedido.PedidocodCliente}, {pedido.PedidocodVendedor}");
                }
            }
        }
        else
        {
            Console.WriteLine($"O Pedido com Id {codPED} não existe.");
        }
    }else if (modelAction == "MostrarPedidosCliente")
    {
        Console.WriteLine("Mostrar Pedidos do Cliente");

        int codC;
        Console.Write("Digite o codigo do cliente: ");
        var codc = Console.ReadLine();
        while (!Int32.TryParse(codc, out codC))
        {
            Console.WriteLine("Id inválido digitado, tente novamente: ");
            codc = Console.ReadLine();
        }

        if (clienteRepository.ExitsById(codC) == true)
        {
            Console.WriteLine("Código Pedido      Prazo Entrega             Data Pedido");
            foreach (var pedido in pedidoRepository.GetAll())
            {
                if (codC == pedido.PedidocodCliente)
                {

                    Console.WriteLine($"{pedido.Codpedido,-16} {pedido.Prazoentrega,-23} {pedido.Datapedido}");
                }
            }

        }
        else
        {
            Console.WriteLine($"O Cliente com Id {codC} não existe.");
        }

    }else if (modelAction == "MostrarPedidosVendedor")
    {
        Console.WriteLine("Mostrar Pedidos do Vendedor");

        int codV;
        Console.Write("Digite o codigo do vendedor: ");
        var codv = Console.ReadLine();
        while (!Int32.TryParse(codv, out codV))
        {
            Console.WriteLine("código inválido digitado, tente novamente: ");
            codv = Console.ReadLine();
        }

        if (vendedorRepository.ExitsById(codV) == true)
        {
        Console.WriteLine("Código Vendedor      Código Pedido          Data Pedido");
            foreach (var pedido in pedidoRepository.GetAll())
            {
                if (codV == pedido.PedidocodVendedor)
                {
        
                    Console.WriteLine($"{pedido.PedidocodVendedor,-24} {pedido.Codpedido,-16} {pedido.Datapedido}");
        }
            }

        }
        else
        {
            Console.WriteLine($"O Vendedor com código {codV} não existe.");
        }

    }
}else if (modelName == "ItensPedido")
{
    if (modelAction == "Listar")
    {
        Console.WriteLine("Listar ItemPedido");
        Console.WriteLine("Cod item pedido  Cod pedido     Cod produto       Quantidade");
        foreach (var itempedido in itempedidoRepository.GetAll())
        {
            Console.WriteLine($"{itempedido.Coditempedido,-17} {itempedido.Itempedidocodpedido,-13} {itempedido.Itempedidocodproduto,-17} {itempedido.Quantidade,-9}");
        }
    }

    if (modelAction == "Inserir")
    {
        Console.WriteLine("ItemPedido Inserir");
        int coditempedido;
        int itempedidocodpedido;
        int itempedidocodproduto;
        int quantidade;

        Console.Write("Digite o codigo do item pedido            : ");
        coditempedido = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite o codigo do pedido do item pedido  : ");
        itempedidocodpedido = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite o codigo do produto do item pedido : ");
        itempedidocodproduto = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite a quantidade item do pedido        : ");
        quantidade = Convert.ToInt32(Console.ReadLine());

        var itempedido = new ItemPedido(coditempedido, itempedidocodpedido, itempedidocodproduto, quantidade);
        itempedidoRepository.Save(itempedido);

    }

    if (modelAction == "Apresentar")
    {
        Console.WriteLine("Apresentar item pedido");

        int codI;
        Console.Write("Digite o código do pedido: ");
        var codi = Console.ReadLine();
        while (!Int32.TryParse(codi, out codI))
        {
            Console.WriteLine("Id inválido digitado, tente novamente: ");
            codi = Console.ReadLine();
        }

        if (itempedidoRepository.ExitsById(codI) == true)
        {
            foreach (var itemp in itempedidoRepository.GetAll())
            {
                if (codI == itemp.Coditempedido)
                {
                    Console.WriteLine($"{itemp.Coditempedido}, {itemp.Itempedidocodpedido}, {itemp.Itempedidocodproduto}, {itemp.Quantidade}");
                }
            }
        }
        else
        {
            Console.WriteLine($"O Pedido com Id {codI} não existe.");
        }
    }else if (modelAction == "MostrarQuantidadesPedido")
    {
        Console.WriteLine("Mostrar Quantidades de Pedidos do Cliente");

        int codIT;
        Console.Write("Digite o código do item do pedido: ");
        var codit = Console.ReadLine();
        while (!Int32.TryParse(codit, out codIT))
        {
            Console.WriteLine("Código inválido digitado, tente novamente: ");
            codit = Console.ReadLine();
        }

        if (itempedidoRepository.ExitsById(codIT) == true)
        {
            Console.WriteLine("Código do Item Pedido      Código Pedido         Código Produto        Quantidade");
            foreach (var itemp in itempedidoRepository.GetAll())
            {
                if (codIT == itemp.Coditempedido)
                {

                    Console.WriteLine($"{itemp.Coditempedido,-30} {itemp.Itempedidocodpedido,-23} {itemp.Itempedidocodproduto, -20} {itemp.Quantidade}");
                }
            }

        }
        else
        {
            Console.WriteLine($"O Item com o código {codIT} não existe.");
        }

    }
}else if (modelName == "Vendedores")
{
    if (modelAction == "Listar")
    {
        Console.WriteLine("Listar Vendedor");
        Console.WriteLine("Cod Vendedor     Nome             Salario Fixo   Faixa Comissao");
        foreach (var vendedor in vendedorRepository.GetAll())
        {
            Console.WriteLine($"{vendedor.Codvendedor,-16} {vendedor.Nome,-16} {vendedor.Salariofixo,-14} {vendedor.Faixacomissao,-9}");
        }
    }else if (modelAction == "Inserir")
    {
        Console.WriteLine("Vendedor Inserir");
        int codvendedor;
        float salariofixo;

        Console.Write("Digite o Código do vendedor            : ");
        codvendedor = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite o Nome do vendedor              : ");
        var nome = Console.ReadLine();
        Console.Write("Digite o Salário Fixo do vendedor      : ");
        salariofixo = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite a Faixa de Comissão do vendedor : ");
        var faixacomissao = Console.ReadLine();

        var vendedor = new Vendedor(codvendedor, nome, salariofixo, faixacomissao);
        vendedorRepository.Save(vendedor);
    }else if (modelAction == "Apresentar")
    {
        Console.WriteLine("Apresentar vendedor");

        int codV;
        Console.Write("Digite o codigo do vendedor: ");
        var codv = Console.ReadLine();
        while (!Int32.TryParse(codv, out codV))
        {
            Console.WriteLine("Id inválido digitado, tente novamente: ");
            codv = Console.ReadLine();
        }

        if (vendedorRepository.ExitsById(codV))
        {
            foreach (var vendedor in vendedorRepository.GetAll())
            {
                if (codV == vendedor.Codvendedor)
                {
                    Console.WriteLine($" {vendedor.Codvendedor}, {vendedor.Nome}, {vendedor.Salariofixo}, {vendedor.Faixacomissao}");
                }
            }
        }
        else
        {
            Console.WriteLine($"O Pedido com Id {codv} não existe.");
        }
    }

}else if (modelName == "Produtos")
{
    if (modelAction == "Listar")
    {
        Console.WriteLine("Listar Produto");
        Console.WriteLine("Cod Produto  Descricao        Valor Unitario");
        foreach (var produto in produtoRepository.GetAll())
        {
            Console.WriteLine($"{produto.Codproduto,-12} {produto.Descricao,-16} {produto.Valorunitario,-19}");
        }
    }else if (modelAction == "Inserir")
    {
        Console.WriteLine("Produto Inserir");
        int codproduto;
        float valorunitario;

        Console.Write("Digite o Código do produto         : ");
        codproduto = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite a Descrição do produto      : ");
        var descricao = Console.ReadLine();
        Console.Write("Digite o Valor unitário do produto : ");
        valorunitario = Convert.ToInt32(Console.ReadLine());


        var produto = new Produto(codproduto, descricao, valorunitario);
        produtoRepository.Save(produto);
    }else if (modelAction == "Apresentar")
    {
        Console.WriteLine("Apresentar produto");

        int codP;
        Console.Write("Digite o código do produto: ");
        var codp = Console.ReadLine();
        while (!Int32.TryParse(codp, out codP))
        {
            Console.WriteLine("Id inválido digitado, tente novamente: ");
            codp = Console.ReadLine();
        }

        if (produtoRepository.ExitsById(codP) == true)
        {
            foreach (var produto in produtoRepository.GetAll())
            {
                if (codP == produto.Codproduto)
                {
                    Console.WriteLine($"{produto.Codproduto}, {produto.Descricao}, {produto.Valorunitario}");
                }
            }
        }
        else
        {
            Console.WriteLine($"O Pedido com Id {codp} não existe.");
        }
    }
}
else{
    Console.WriteLine("Digite uma opção válida!!!");
}