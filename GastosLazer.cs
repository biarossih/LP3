using Classes;

class GastosLazer: Gastos
{   
    public double desconto;
    public GastosLazer(string nome, double margem = 0.03) : base(nome) =>  desconto = margem;

    public override void AdicionarMargem() {
        decimal porcentagem =  ValorAcumulado * (decimal)desconto;
        base.AdicionarGasto(porcentagem, DateTime.Now, "Margem de Segurança para Lazer");
        base.AdicionarGasto(-50, DateTime.Now, "Bônus para Lazer");
    }
}