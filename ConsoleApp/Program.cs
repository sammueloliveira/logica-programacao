public static class SomaProgressiva
{
    public static int CalcularSoma()
    {
        int indice = 13, soma = 0, k = 0;
        while (k < indice)
        {
            k++;
            soma += k;
        }
        return soma;
    }
}

public static class Fibonacci
{
    public static bool PertenceAoFibonacci(int numero)
    {
        int a = 0, b = 1;
        while (b < numero)
        {
            int temp = b;
            b = a + b;
            a = temp;
        }
        return b == numero || numero == 0;
    }
}

public static class FaturamentoDiario
{
    public static (double menor, double maior, int diasAcimaDaMedia) AnalisarFaturamento(List<double> faturamentos)
    {
        var valoresFiltrados = faturamentos.Where(f => f > 0).ToList();
        double menor = valoresFiltrados.Min();
        double maior = valoresFiltrados.Max();
        double media = valoresFiltrados.Average();
        int diasAcimaDaMedia = valoresFiltrados.Count(f => f > media);

        return (menor, maior, diasAcimaDaMedia);
    }
}

public static class FaturamentoPorEstado
{
    public static Dictionary<string, double> CalcularPercentuais(Dictionary<string, double> faturamento)
    {
        double total = faturamento.Values.Sum();
        return faturamento.ToDictionary(kvp => kvp.Key, kvp => (kvp.Value / total) * 100);
    }
}

public static class InversorDeString
{
    public static string Inverter(string texto)
    {
        string resultado = string.Empty;
        for (int i = texto.Length - 1; i >= 0; i--)
        {
            resultado += texto[i];
        }
        return resultado;
    }
}

class Program
{
    static void Main(string[] args)
    {
      
        Console.WriteLine("Soma Progressiva: " + SomaProgressiva.CalcularSoma());

        Console.WriteLine("Fibonacci (13): " + Fibonacci.PertenceAoFibonacci(13));
        Console.WriteLine("Fibonacci (15): " + Fibonacci.PertenceAoFibonacci(15));

        var faturamentos = new List<double> { 200, 300, 0, 500, 0, 100, 800 };
        var resultadoFaturamento = FaturamentoDiario.AnalisarFaturamento(faturamentos);
        Console.WriteLine($"Menor: {resultadoFaturamento.menor}, Maior: {resultadoFaturamento.maior}, Dias acima da média: {resultadoFaturamento.diasAcimaDaMedia}");

        var faturamentoPorEstado = new Dictionary<string, double>
        {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };
        var resultadoPercentuais = FaturamentoPorEstado.CalcularPercentuais(faturamentoPorEstado);
        foreach (var item in resultadoPercentuais)
        {
            Console.WriteLine($"{item.Key}: {item.Value}%");
        }

        Console.WriteLine("Inversão de string (hello): " + InversorDeString.Inverter("hello"));
    }
}
