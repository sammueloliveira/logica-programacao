using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        int indice = 13;
        int soma = SomaProgressiva.CalcularSoma(indice);
        Console.WriteLine($"Soma Progressiva: {soma}");

        int numeroFibonacci = 13;
        bool pertenceFibonacci = Fibonacci.Verificar(numeroFibonacci);
        Console.WriteLine($"Fibonacci ({numeroFibonacci}): {pertenceFibonacci}");

        List<Faturamento> faturamentos = FaturamentoService.CalcularFaturamentoDiario();

        double menorFaturamento = FaturamentoService.ObterMenorFaturamento(faturamentos);
        double maiorFaturamento = FaturamentoService.ObterMaiorFaturamento(faturamentos);
        Console.WriteLine($"Menor Faturamento: {menorFaturamento}");
        Console.WriteLine($"Maior Faturamento: {maiorFaturamento}");

        double mediaFaturamento = FaturamentoService.CalcularMediaFaturamento(faturamentos);
        int diasAcimaDaMedia = FaturamentoService.ContarDiasAcimaDaMedia(faturamentos, mediaFaturamento);
        Console.WriteLine($"Dias acima da média: {diasAcimaDaMedia}");

        FaturamentoService.CalcularPercentualEstados();

        string palavra = "hello";
        string palavraInvertida = StringHelper.Inverter(palavra);
        Console.WriteLine($"Inversão de string ({palavra}): {palavraInvertida}");

        string json = JsonHelper.GerarJson(faturamentos);
        File.WriteAllText("dados.json", json);
        Console.WriteLine("JSON gerado com sucesso!");

        string jsonLido = File.ReadAllText("dados.json");
        Console.WriteLine("\nConteúdo do JSON gerado:");
        Console.WriteLine(jsonLido);
    }
}

public static class SomaProgressiva
{
    public static int CalcularSoma(int indice)
    {
        int soma = 0, k = 0;
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
    public static bool Verificar(int numero)
    {
        int a = 0, b = 1;
        while (b < numero)
        {
            int temp = a + b;
            a = b;
            b = temp;
        }
        return b == numero;
    }
}

public static class FaturamentoService
{
    public static List<Faturamento> CalcularFaturamentoDiario()
    {
        var faturamentos = new List<Faturamento>();
        var random = new Random();

        for (int dia = 1; dia <= 30; dia++)
        {
            double valor = dia % 2 == 0 ? random.NextDouble() * 50000 : 0.0;
            faturamentos.Add(new Faturamento { Dia = dia, Valor = valor });
        }

        return faturamentos;
    }

    public static double ObterMenorFaturamento(List<Faturamento> faturamentos)
    {
        return faturamentos.Where(f => f.Valor > 0).Min(f => f.Valor);
    }

    public static double ObterMaiorFaturamento(List<Faturamento> faturamentos)
    {
        return faturamentos.Where(f => f.Valor > 0).Max(f => f.Valor);
    }

    public static double CalcularMediaFaturamento(List<Faturamento> faturamentos)
    {
        return faturamentos.Where(f => f.Valor > 0).Average(f => f.Valor);
    }

    public static int ContarDiasAcimaDaMedia(List<Faturamento> faturamentos, double media)
    {
        return faturamentos.Count(f => f.Valor > media);
    }

    public static void CalcularPercentualEstados()
    {
        var faturamentoEstados = new Dictionary<string, double>
        {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };

        double totalFaturamento = faturamentoEstados.Values.Sum();

        foreach (var estado in faturamentoEstados)
        {
            double percentual = (estado.Value / totalFaturamento) * 100;
            Console.WriteLine($"{estado.Key}: {percentual:F2}%");
        }
    }
}

public static class StringHelper
{
    public static string Inverter(string str)
    {
        char[] array = str.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }
}

public static class JsonHelper
{
    public static string GerarJson(List<Faturamento> faturamentos)
    {
        return JsonConvert.SerializeObject(faturamentos, Formatting.Indented);
    }
}

public class Faturamento
{
    public int Dia { get; set; }
    public double Valor { get; set; }
} 