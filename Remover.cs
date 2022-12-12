using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor_de_gastos.Data;

namespace gestor_de_gastos
{
    public class Remover
    {
        public static void RemoverGastosOuPerfil()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1 - Remover Perfil\n2 - Remover Gasto");
                Console.WriteLine("");
                var opcao = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcao)
                {
                    case 1: RemoverPerfil(); break;
                    case 2: RemoverGasto(); break;
                    default: Console.WriteLine("Opção 1 ou 2 APENAS!"); break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERRO]");
                Console.WriteLine("Você passou dados errados, confirme e tente novamente.");
            }
        }

        public static void RemoverPerfil()
        {
            using (var context = new GastosDataContext())
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Qual é o seu nome completo?");
                    var nomeCompleto = Console.ReadLine().ToLower();
                    var pessoa = context.Pessoas.FirstOrDefault(p => p.Nome == nomeCompleto);

                    context.Remove(pessoa);
                    context.SaveChanges();
                    Console.WriteLine("=========================");
                    Console.WriteLine("Perfil Removido com sucesso!");
                    Console.WriteLine("=========================");
                    Console.WriteLine("Aperte [ENTER] para voltar ao menu");
                    Console.ReadLine();
                    Menu.MostrarMenu();
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Não existe esse nome, tente novamente!");
                    Console.WriteLine("Aperte [ENTER] para voltar ao menu");
                    Console.ReadLine();
                    Menu.MostrarMenu();
                }

            }
        }
        public static void RemoverGasto()
        {
            using (var context = new GastosDataContext())
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Qual é o seu nome completo?");
                    var nomeCompleto = Console.ReadLine().ToLower();
                    Console.WriteLine("Qual o [ID] do gasto que você quer remover?");
                    var gastoId = int.Parse(Console.ReadLine());

                    var pessoa = context.Pessoas.FirstOrDefault(p => p.Nome == nomeCompleto);
                    var gasto = context.Gastos.Single(g => g.Id == gastoId); // single traz uma única coisa

                    if (pessoa.Id == gasto.PessoaId) // se existir o id do gasto nessa pessoa
                    {
                        Console.Clear();
                        Console.WriteLine("-- MODO REMOÇÃO --");
                        Console.WriteLine("");
                        Console.WriteLine("Tem certeza que quer remover esse gasto? s ou n");
                        var opcao = Console.ReadLine().ToLower();
                        if (opcao == "s")
                        {
                            context.Remove(gasto);
                            context.SaveChanges();
                            Console.WriteLine("=========================");
                            Console.WriteLine("Gasto Removido com sucesso!");
                            Console.WriteLine("=========================");
                            Console.WriteLine("Aperte [ENTER] para voltar ao menu");
                            Console.ReadLine();
                            Menu.MostrarMenu();
                        }
                        else if (opcao == "n")
                        {
                            Console.WriteLine("Obrigado por utilizar o Gestor de Gastos Mariofneto");
                            Console.WriteLine("Aperte [ENTER] para voltar ao menu");
                            Console.ReadLine();
                            Menu.MostrarMenu();
                        }
                        else
                        {
                            Console.WriteLine("Digite uma opção válida\ns ou n");
                        }
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("[ERRO]");
                    Console.WriteLine("Não existe esse ID de gasto vinculado com essa pessoa!");
                    Console.WriteLine("Aperte [ENTER] para voltar ao menu");
                    Console.ReadLine();
                    Menu.MostrarMenu();
                }
            }
        }


    }
}