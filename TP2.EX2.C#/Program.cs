
using System;
using System.Globalization;

public class ProximoAniversario
{
    public static void Main(string[] args)
    {
        Console.WriteLine("CALCULADORA DE DIAS PARA O ANIVERSÁRIO");
        Console.WriteLine("Insira sua data de nascimento (formato DD/MM/AAAA):");

        DateTime dataNascimento;
        bool entradaValida = false;

        while (!entradaValida)
        {
            Console.Write("Data de Nascimento: ");
            string input = Console.ReadLine();

            if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNascimento))
            {
                DateTime hoje = DateTime.Today;

                if (dataNascimento > hoje)
                {
                    Console.WriteLine("Erro: A data de nascimento não pode estar no futuro. Tente novamente.");
                }
                else
                {
                    entradaValida = true;

                    DateTime proximoAniversario = new DateTime(hoje.Year, dataNascimento.Month, dataNascimento.Day);

                    if (proximoAniversario < hoje)
                    {
                        proximoAniversario = proximoAniversario.AddYears(1);
                    }

                    TimeSpan diferenca = proximoAniversario.Subtract(hoje);
                    int diasRestantes = (int)diferenca.TotalDays;

                 
                    Console.WriteLine($"Seu próximo aniversário será em: {proximoAniversario.ToString("dd/MM/yyyy")}");
                    
                    Console.WriteLine($"Faltam {diasRestantes} dias para o seu aniversário!");
                }
            }
            else
            {
                Console.WriteLine("Erro: Formato de data inválido. Use DD/MM/AAAA (ex: 25/12/1990).");
            }
        }
    }
}