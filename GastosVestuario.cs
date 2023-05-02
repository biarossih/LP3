using Classes;

class GastosVestuario : Gastos
{   
    public double desconto;
    public GastosVestuario(string nome, double margem = 0.02) : base(nome) =>  desconto = margem;

    public override void AdicionarMargem() {
        decimal porcentagem =  ValorAcumulado * (decimal)desconto;
        base.AdicionarGasto(porcentagem, DateTime.Now, "Margem de Segurança para Vestuário");
    }
}