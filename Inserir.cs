using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor_de_gastos.Data;
using gestor_de_gastos.Models;

namespace gestor_de_gastos
{
    public class Inserir
    {
        public static void InserirGastos()
        {
            Console.Clear();
            using (var context = new GastosDataContext())
            {
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1 - Inserir Perfil(se não tiver)\n2 - Inserir Gasto(se ja tiver o perfil)");
                Console.WriteLine("");
                var opcao = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcao)
                {
                    case 1: InserirPerfil(); break;
                    case 2: InserirGasto(); break;
                    default: Console.WriteLine("Opção 1 ou 2 APENAS!"); Console.ReadLine(); break;
                }
            }

        }

        public static void InserirPerfil()
        {
            using (var context = new GastosDataContext())
            {
                Console.WriteLine("Qual o seu nome completo?");
                var nomeCompleto = Console.ReadLine().ToLower();
                Console.WriteLine("Digite o nome do Gasto que queira adicionar: ");
                var nomeGasto = Console.ReadLine().ToLower();
                Console.WriteLine("Digite o preço do Gasto que queira adicionar R$: ");
                var precoGasto = decimal.Parse(Console.ReadLine());
                var pessoaExistente = context.Pessoas.FirstOrDefault(p => p.Nome == nomeCompleto);

                var pessoa = new Pessoa
                {
                    Nome = nomeCompleto
                };

                var gasto = new Gasto
                {
                    Pessoa = pessoa,
                    Nome = nomeGasto,
                    Preco = precoGasto
                };

                context.Pessoas.Add(pessoa);
                context.Gastos.Add(gasto);
                context.SaveChanges();

                Console.WriteLine("----------------------------------");
                Console.WriteLine("Perfil & Gasto adicionado com sucesso!");
                Console.WriteLine("Deseja voltar para o Menu? s ou n");
                var respostaMenu = Console.ReadLine();
                if (respostaMenu.ToLower() == "s")
                {
                    Menu.MostrarMenu();
                }
                else if (respostaMenu.ToLower() == "n")
                {
                    Console.WriteLine("Obrigado por utilizar o Gestor de Gastos Mariofneto");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Digite uma opção válida\ns ou n");
                    Console.ReadLine();
                }
            }
        }

        public static void InserirGasto()
        {
            using (var context = new GastosDataContext())
            {
                Console.WriteLine("Qual o seu nome completo?");
                var nomeCompleto = Console.ReadLine().ToLower();
                Console.WriteLine("Digite o nome do Gasto que queira adicionar: ");
                var nomeGasto = Console.ReadLine().ToLower();
                Console.WriteLine("Digite o preço do Gasto que queira adicionar R$: ");
                var precoGasto = decimal.Parse(Console.ReadLine());
                var pessoaExistente = context.Pessoas.FirstOrDefault(p => p.Nome == nomeCompleto);

                var gasto = new Gasto
                {
                    Pessoa = pessoaExistente,
                    Nome = nomeGasto,
                    Preco = precoGasto
                };


                context.Gastos.Add(gasto);
                context.SaveChanges();

                Console.WriteLine("----------------------------------");
                Console.WriteLine("Gasto adicionado com sucesso!");
                Console.WriteLine("Deseja voltar para o Menu? s ou n");
                var respostaMenu = Console.ReadLine();
                if (respostaMenu.ToLower() == "s")
                {
                    Menu.MostrarMenu();
                }
                else if (respostaMenu.ToLower() == "n")
                {
                    Console.WriteLine("Obrigado por utilizar o Gestor de Gastos Mariofneto");
                    Console.ReadLine();
                }   

                else
                {
                    Console.WriteLine("Digite uma opção válida\ns ou n");
                    Console.ReadLine();
                }
            }
        }
    }
}