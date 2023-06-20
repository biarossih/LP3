namespace Aula10DB.Models;

class ItemPedido
{
    public int Coditempedido { get; set; }
    public int Itempedidocodpedido { get; set; }
    public int Itempedidocodproduto { get; set; }

    public int Quantidade { get; set; } 

    public ItemPedido(int coditempedido, int itempedidocodpedido, int itempedidocodproduto, int quantidade)
    {
        Coditempedido = coditempedido;
        Itempedidocodpedido = itempedidocodpedido;
        Itempedidocodproduto = itempedidocodproduto;
        Quantidade = quantidade;

    }
}