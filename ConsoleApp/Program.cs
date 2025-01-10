using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        
        int indice = 13, soma = 0, k = 0;
        while (k < indice)
        {
            k = k + 1;
            soma = soma + k;
        }
        Console.WriteLine($"Soma Progressiva: {soma}");

        
        int numeroFibonacci = 13; 
        bool pertenceFibonacci = VerificarFibonacci(numeroFibonacci);
        Console.WriteLine($"Fibonacci ({numeroFibonacci}): {pertenceFibonacci}");

      
        List<Faturamento> faturamentos = CalcularFaturamentoDiario();

       
        double menorFaturamento = faturamentos.Where(f => f.Valor > 0).Min(f => f.Valor);
        double maiorFaturamento = faturamentos.Where(f => f.Valor > 0).Max(f => f.Valor);
        Console.WriteLine($"Menor Faturamento: {menorFaturamento}");
        Console.WriteLine($"Maior Faturamento: {maiorFaturamento}");

    
        double mediaFaturamento = faturamentos.Where(f => f.Valor > 0).Average(f => f.Valor);
        int diasAcimaDaMedia = faturamentos.Count(f => f.Valor > mediaFaturamento);
        Console.WriteLine($"Dias acima da média: {diasAcimaDaMedia}");

      
        CalcularPercentualEstados();

       
        string palavra = "hello";
        string palavraInvertida = InverterString(palavra);
        Console.WriteLine($"Inversão de string ({palavra}): {palavraInvertida}");

        
        string json = GerarJson(faturamentos);
        File.WriteAllText("dados.json", json);
        Console.WriteLine("JSON gerado com sucesso!");

       
        string jsonLido = File.ReadAllText("dados.json");
        Console.WriteLine("\nConteúdo do JSON gerado:");
        Console.WriteLine(jsonLido);
    }

   
    static bool VerificarFibonacci(int numero)
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

   
    static List<Faturamento> CalcularFaturamentoDiario()
    {
        List<Faturamento> faturamentos = new List<Faturamento>();

       
        Random random = new Random();
        for (int dia = 1; dia <= 30; dia++)
        {
            double valor = dia % 2 == 0 ? random.NextDouble() * 50000 : 0.0; 
            faturamentos.Add(new Faturamento { Dia = dia, Valor = valor });
        }

        return faturamentos;
    }

   
    static void CalcularPercentualEstados()
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

   
    static string InverterString(string str)
    {
        char[] array = str.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }

   
    static string GerarJson(List<Faturamento> faturamentos)
    {
        return JsonConvert.SerializeObject(faturamentos, Formatting.Indented);
    }
}


public class Faturamento
{
    public int Dia { get; set; }
    public double Valor { get; set; }
}
