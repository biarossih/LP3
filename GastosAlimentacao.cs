using Classes;

class GastosAlimentacao : Gastos
{   
    public double desconto;
    public GastosAlimentacao(string nome, double margem = 0.01) : base(nome) =>  desconto = margem;

    public override void AdicionarMargem() {
        decimal porcentagem =  ValorAcumulado * (decimal)desconto;
        base.AdicionarGasto(porcentagem, DateTime.Now, "Margem de Segurança para Alimentação");

    }
}