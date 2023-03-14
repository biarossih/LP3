class Calculadora
{
  public static double Operacao(double num1, double num2, string opcao) {
    double resultado = double.NaN;
    switch (opcao) {
      case "a":
        resultado = num1 + num2;
        break;
      case "s":
        resultado = num1 - num2;
        break;
      case "m":
        resultado = num1 * num2;
        break;
      case "d":
        resultado = num1 / num2;
        break;
      default:
        Console.WriteLine("Opção inválida");
        break;
    }
    return resultado;
  }
}