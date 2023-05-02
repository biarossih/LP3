using Classes;

class GastosEducacao : Gastos
{   
    public double desconto;
    public GastosEducacao(string nome, double margem = 0.04) : base(nome) =>  desconto = margem;

    public override void AdicionarMargem() {
        decimal porcentagem =  ValorAcumulado * (decimal)desconto;
        base.AdicionarGasto(porcentagem, DateTime.Now, "Margem de Segurança para Educação");
    }
}