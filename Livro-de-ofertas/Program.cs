using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class Program
{
    static List<Oferta> livroOfertas = new List<Oferta>(); // Lista global para armazenar as ofertas

    static void Main()
    {
        do
        {
            Console.WriteLine("Informe o número de notificações:");
            int numNotificacoes = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe as notificações no formato 'posicao,acao,valor,quantidade':");
            Console.WriteLine("Ação: 0 = INSERIR, 1 = MODIFICAR, 2 = DELETAR");
            Console.WriteLine("Exemplo: 1,0,15.40,50");

            for (int i = 0; i < numNotificacoes; i++)
            {
                Console.Write($"Notificação {i + 1}: ");
                string[] notificacao = Console.ReadLine().Split(',');

                int posicao = int.Parse(notificacao[0]);
                int acao = int.Parse(notificacao[1]);
                decimal valor = decimal.Parse(notificacao[2], CultureInfo.InvariantCulture);
                int quantidade = int.Parse(notificacao[3]);

                ProcessarNotificacao(posicao, acao, valor, quantidade);
            }

            Console.WriteLine("\nResultado do Livro de Ofertas Atualizado:");
            ImprimirLivroOfertas();

            Console.Write("\nDeseja atualizar o livro de ofertas novamente? (S/N): ");
        } while (Console.ReadLine().ToUpper() == "S");
    }

    static void ProcessarNotificacao(int posicao, int acao, decimal valor, int quantidade)
    {
        if (acao == 0) // INSERIR
        {
            livroOfertas.Add(new Oferta { Posicao = posicao, Valor = valor, Quantidade = quantidade });
        }
        else if (acao == 1) // MODIFICAR
        {
            var oferta = livroOfertas.FirstOrDefault(o => o.Posicao == posicao);
            if (oferta != null)
            {
                oferta.Valor = valor;
                oferta.Quantidade = quantidade;
            }
        }
        else if (acao == 2) // DELETAR
        {
            livroOfertas.RemoveAll(o => o.Posicao == posicao);
        }
    }

    static void ImprimirLivroOfertas()
    {
        Console.WriteLine("POSICAO\tVALOR\tQUANTIDADE");
        foreach (var oferta in livroOfertas.OrderBy(o => o.Posicao))
        {
            Console.WriteLine($"{oferta.Posicao}\t{oferta.Valor.ToString("C", CultureInfo.CurrentCulture)}\t{oferta.Quantidade}");
        }
    }
}

class Oferta
{
    public int Posicao { get; set; }
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }
}



