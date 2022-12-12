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
                Console.WriteLine("Qual o seu nome completo?");
                var nomeCompleto = Console.ReadLine().ToLower();
                Console.WriteLine("Deseja que mostre todos os seus gastos? s ou n");
                var resposta = Console.ReadLine().ToLower();

                if (resposta == "s")
                {
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
                else if (resposta == "n")
                {
                    Console.WriteLine("Aperte [ENTER] para voltar ao menu");
                    Console.ReadLine();
                    Menu.MostrarMenu();
                }
                else
                {
                    Console.WriteLine("Digite uma opção válida\ns ou n");
                    Console.WriteLine("Aperte [ENTER] para voltar ao menu");
                    Console.ReadLine();
                    Menu.MostrarMenu();
                }
                context.SaveChanges();
            }
        }
    }
}