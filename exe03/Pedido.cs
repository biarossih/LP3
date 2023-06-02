namespace exe03.Models;

class Pedido
{
    public int PedidoId { get; set; }
    public int EnderecoId { get; set; }
    public string DataPedido { get; set; }
    public string Peso { get; set; }
    public int CodTransportadora { get; set; }
    public int PedidoClienteId { get; set; }
    
    public Pedido(int pedId, int enderecoId, string dataPedido, string peso, int codigoTransportadora, int pedidoClienteId) {
        PedidoId = pedId;
        EnderecoId  = enderecoId;
        DataPedido = dataPedido;
        Peso = peso;
        CodTransportadora = codigoTransportadora;
        PedidoClienteId = pedidoClienteId;
    }
}
