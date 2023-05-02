using Classes;

Gastos alimentos = new GastosAlimentacao("BEATRIZ ROSSI DUARTE");
alimentos.AdicionarGasto(20, DateTime.Now, "Café");
alimentos.AdicionarGasto(50, DateTime.Now, "Compra de mantimentos");
alimentos.AdicionarMargem();
Console.WriteLine(alimentos.ObterHistoricoDeGastos());

Gastos vestuarios = new GastosVestuario("BEATRIZ ROSSI DUARTE");
vestuarios.AdicionarGasto(100, DateTime.Now, "Agasalho");
vestuarios.AdicionarGasto(50, DateTime.Now, "Calça");
vestuarios.AdicionarGasto(250, DateTime.Now, "Terno");
vestuarios.AdicionarMargem();
Console.WriteLine(vestuarios.ObterHistoricoDeGastos());

Gastos lazer = new GastosLazer("BEATRIZ ROSSI DUARTE");
lazer.AdicionarGasto(200, DateTime.Now, "Cinema");
lazer.AdicionarMargem();
Console.WriteLine(lazer.ObterHistoricoDeGastos());

Gastos educacao = new GastosEducacao("BEATRIZ ROSSI DUARTE");
educacao.AdicionarGasto(1000, DateTime.Now, "Linguagem C#");
educacao.AdicionarMargem();
Console.WriteLine(educacao.ObterHistoricoDeGastos());