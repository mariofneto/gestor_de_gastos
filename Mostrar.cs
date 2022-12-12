using System.Data;
using System.Net.Http.Headers;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor_de_gastos.Data;
using gestor_de_gastos.Models;

namespace gestor_de_gastos
{
    public class Mostrar
    {
        public static void MostrarGastos()
        {
            Console.Clear();
            using var context = new GastosDataContext();
            {
                try
                {
                    Console.WriteLine("Qual o seu nome completo?");
                    var nomeCompleto = Console.ReadLine().ToLower();
                    Console.Clear();
                    Console.WriteLine("O que deseja fazer?");
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("1 - Ver todos os gastos separados\n2 - Ver soma dos gastos");
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("");
                    var resposta = int.Parse(Console.ReadLine());

                    if (resposta == 1)
                    {
                        Console.Clear();
                        var pessoa = context.Pessoas.FirstOrDefault(p => p.Nome == nomeCompleto);
                        var gastos = context.Gastos.Where(g => g.Pessoa.Nome.Contains(pessoa.Nome));
                        Console.WriteLine($"Olá {pessoa.Nome}!");
                        Console.WriteLine("");
                        foreach (var gasto in gastos)
                        {

                            Console.WriteLine($"ID = {gasto.Id}\nNome = {gasto.Nome}\nPreço = R${gasto.Preco}");
                            Console.WriteLine("=======================================");

                        }
                        Console.WriteLine("");
                        Console.WriteLine("Aperte [ENTER] para voltar ao menu");
                        Console.ReadLine();
                        Menu.MostrarMenu();
                    }
                    else if (resposta == 2)
                    {
                        Console.Clear();
                        var pessoa = context.Pessoas.FirstOrDefault(p => p.Nome == nomeCompleto);
                        var quantosGastos = context.Gastos.Where(g => g.PessoaId == pessoa.Id).Count();
                        var somaGastos = context.Gastos.Where(g => g.PessoaId == pessoa.Id).Sum(g => g.Preco);
                        Console.Clear();
                        Console.WriteLine($"Você tem {quantosGastos} gastos em seu nome.");
                        Console.WriteLine($"E a soma dos seus gastos é igual a: R${somaGastos}");
                        Console.WriteLine($"----------------------------------------------");
                        Console.WriteLine("Aperte [ENTER] para voltar ao menu");
                        Console.ReadLine();
                        Menu.MostrarMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Digite uma opção válida\n1 ou 2");
                        Console.WriteLine("Aperte [ENTER] para voltar ao menu");
                        Console.ReadLine();
                        Menu.MostrarMenu();
                    }
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine("[ERRO]");
                    Console.WriteLine("Você passou dados errados, confirme e tente novamente.");
                }

            }
        }
    }
}