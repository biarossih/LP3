namespace Aula10DB.Models;

class Produto
{
    public int Codproduto { get; set; }
    public string Descricao { get; set; }
    public float Valorunitario { get; set; }

    public Produto(int codproduto, string descricao, float valorunitario)
    {
        Codproduto = codproduto;
        Descricao = descricao;
        Valorunitario = valorunitario;
    }
}