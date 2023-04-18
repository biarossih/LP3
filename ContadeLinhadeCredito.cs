using Classes;

public class ContadeLinhadeCredito : ContaBancaria
{
    public ContadeLinhadeCredito(string nome, decimal saldoInicial) : base(nome, saldoInicial)
    {

    }
    public override void ExecutarTransacoesdeFimdeMes()
    {
    if (Saldo < 0)
    {
        decimal juros = -Saldo * 0.07m;
        EfetuarSaque(juros, DateTime.Now, "Alterar juros mensais");
    }
    }
}


