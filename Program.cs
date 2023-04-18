using Classes;

var cartaoDeDebito = new ContaCartaodeDebito("Cartão de Débito", 100, 50);
cartaoDeDebito.EfetuarSaque(20, DateTime.Now, "Café");
cartaoDeDebito.EfetuarSaque(50, DateTime.Now, "Compra de Mantimentos");
cartaoDeDebito.ExecutarTransacoesdeFimdeMes();
cartaoDeDebito.EfetuarDeposito(27.50m, DateTime.Now, "Adicionar algum dinheiro extra para gastar");
Console.WriteLine(cartaoDeDebito.ObterHistoricodeConta());

var poupanca = new ContadeGanhodeJuros("Conta de Poupança", 10000);
poupanca.EfetuarDeposito(750, DateTime.Now, "Economizar dinheiro");
poupanca.EfetuarDeposito(1250, DateTime.Now, "Adicionar mais poupança");
poupanca.EfetuarSaque(250, DateTime.Now, "Necessário para pagar contas mensais");
poupanca.ExecutarTransacoesdeFimdeMes();
Console.WriteLine(poupanca.ObterHistoricodeConta());

var credito = new ContadeLinhadeCredito("Conta de Linha de Crédito", 51000);
credito.EfetuarSaque(50000, DateTime.Now, "Necessário para pagar novo automóvel");
credito.ExecutarTransacoesdeFimdeMes();
Console.WriteLine(credito.ObterHistoricodeConta());