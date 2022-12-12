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
                Console.WriteLine("Qual o seu nome completo?");
                var nomeCompleto = Console.ReadLine().ToLower();
                Console.WriteLine("Digite o nome do Gasto que queira adicionar: ");
                var nomeGasto = Console.ReadLine().ToLower();
                Console.WriteLine("Digite o preço do Gasto que queira adicionar R$: ");
                var precoGasto = decimal.Parse(Console.ReadLine());
                var pessoaExistente = context.Pessoas.FirstOrDefault(p => p.Nome == nomeCompleto);

                if (nomeCompleto == pessoaExistente.Nome)
                {
                    var gasto = new Gasto
                    {
                        Pessoa = pessoaExistente,
                        Nome = nomeGasto,
                        Preco = precoGasto
                    };


                    context.Gastos.Add(gasto);
                    context.SaveChanges();
                }
                else
                {
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
                }

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
                }
                else
                {
                    Console.WriteLine("Digite uma opção válida\ns ou n");
                }
            }

        }
    }
}