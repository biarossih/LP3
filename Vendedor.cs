namespace Aula10DB.Models;

class Vendedor
{
    public int Codvendedor { get; set; }
    public string Nome { get; set; }
    public float Salariofixo { get; set; }
    public string Faixacomissao { get; set; }

    public Vendedor(int codvendedor, string nome, float salariofixo, string faixacomissao)
    {
        Codvendedor = codvendedor;
        Nome = nome;
        Salariofixo = salariofixo;
        Faixacomissao = faixacomissao;
    }
}