namespace Classes;
public class Gastos
{
    public string Cliente { get; }

    private List<Transacao> todasTransacoes = new List<Transacao>();
    public decimal ValorAcumulado
    {
        get
        {
            decimal ValorAcumulado = 0m;
            foreach (var item in todasTransacoes)
            {
                ValorAcumulado += item.Valor;
            }

            return ValorAcumulado;
        }
    }



    public Gastos(string nome)
    {
        this.Cliente = nome;
        AdicionarGasto(0, DateTime.Now, "Valor Inicial");
    }

    public void AdicionarGasto(decimal Valor, DateTime Data, string Descricao)
    {
        Transacao gasto = new Transacao(Valor, Data, Descricao);
        todasTransacoes.Add(gasto);
    }

    public virtual void AdicionarMargem(){}

   public string ObterHistoricoDeGastos()
    {
        var relatorio = new System.Text.StringBuilder();

        decimal valorAcumulado = 0;
        relatorio.AppendLine("Data\t\tValor\tValor Acumulado\t    Descrição");
        foreach (var item in todasTransacoes)
        {
            valorAcumulado +=  item.Valor;
            relatorio.AppendLine($"{item.Data.ToShortDateString(), -10} {item.Valor, 10} {valorAcumulado, 17} {"   "} {item.Descricao}");
        }

        return relatorio.ToString();
    }

}
 