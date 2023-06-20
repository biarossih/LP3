namespace Aula10DB.Models;

class Pedido
{
    public int Codpedido { get; set; }
    public DateTime Prazoentrega { get; set; }
    public DateTime Datapedido { get; set; }
    public int PedidocodCliente { get; set; }

    public int PedidocodVendedor{ get; set; } 

    public Pedido(int codpedido, DateTime prazoentrega, DateTime datapedido, int pedidocodcliente, int pedidocodvendedor )
    {
        Codpedido = codpedido;
        Prazoentrega = prazoentrega;
        Datapedido = datapedido;
        PedidocodCliente = pedidocodcliente;
        PedidocodVendedor = pedidocodvendedor;

    }
}