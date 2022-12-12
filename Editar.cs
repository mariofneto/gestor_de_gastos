using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor_de_gastos.Data;

namespace gestor_de_gastos
{
    public class Editar
    {
        public static void EditarGastos()
        {
            Console.Clear();
            using (var context = new GastosDataContext())
            {
                Console.Clear();
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1 - Editar Perfil\n2 - Editar Gasto");
                Console.WriteLine("");
                var opcao = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcao)
                {
                    case 1: EditarPerfil(); break;
                    case 2: EditarGasto(); break;
                    default: Console.WriteLine("Opção 1 ou 2 APENAS!"); break;
                }
            }
        }

        public static void EditarPerfil()
        {
            using (var context = new GastosDataContext())
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("-- MODO EDIÇÃO --");
                    Console.WriteLine("");
                    Console.WriteLine("Qual é o seu nome completo antigo?");
                    var nomeCompletoAntigo = Console.ReadLine().ToLower();
                    Console.WriteLine("Qual sera seu nome completo atual?");
                    var nomeCompletoAtual = Console.ReadLine().ToLower();

                    var pessoa = context.Pessoas.FirstOrDefault(p => p.Nome == nomeCompletoAntigo);
                    Console.Clear();

                    pessoa.Nome = nomeCompletoAtual;
                    context.Update(pessoa);
                    context.SaveChanges();

                    Console.WriteLine("=========================");
                    Console.WriteLine("Perfil Atualizado com sucesso!");
                    Console.WriteLine("=========================");
                    Console.WriteLine("Aperte [ENTER] para voltar ao menu");
                    Console.ReadLine();
                    Menu.MostrarMenu();
                }
                catch (Exception e)
                {
                    Console.WriteLine("[ERRO]");
                    Console.WriteLine("Você passou dados errados, confirme e tente novamente.");
                }
            }
        }

        public static void EditarGasto()
        {
            using (var context = new GastosDataContext())
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Qual é o seu nome completo?");
                    var nomeCompleto = Console.ReadLine().ToLower();
                    Console.WriteLine("Qual o [ID] do gasto que você quer editar?");
                    var gastoId = int.Parse(Console.ReadLine());

                    var pessoa = context.Pessoas.FirstOrDefault(p => p.Nome == nomeCompleto);
                    var gasto = context.Gastos.Single(g => g.Id == gastoId); // single traz uma única coisa

                    if (pessoa.Id == gasto.PessoaId)
                    {
                        Console.Clear();
                        Console.WriteLine("-- MODO EDIÇÃO --");
                        Console.WriteLine("");
                        Console.WriteLine("Qual será o nome do gasto?");
                        var updateNomeGasto = Console.ReadLine();
                        Console.WriteLine("Qual será o preço do gasto?");
                        var updatePrecoGasto = decimal.Parse(Console.ReadLine());

                        gasto.Nome = updateNomeGasto;
                        gasto.Preco = updatePrecoGasto;
                        context.Update(gasto);
                        context.SaveChanges();

                        Console.WriteLine("=========================");
                        Console.WriteLine("Gasto Atualizado com sucesso!");
                        Console.WriteLine("=========================");
                        Console.WriteLine("Aperte [ENTER] para voltar ao menu");
                        Console.ReadLine();
                        Menu.MostrarMenu();
                    }
                    else
                    {
                        Console.WriteLine("[ERRO]");
                        Console.WriteLine("Não existe esse ID de gasto vinculado com essa pessoa!");
                        Console.WriteLine("Aperte [ENTER] para voltar ao menu");
                        Console.ReadLine();
                        Menu.MostrarMenu();

                    }
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
