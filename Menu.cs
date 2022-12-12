using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestor_de_gastos
{
    public class Menu
    {
        public static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("Seja Bem-Vindo ao Gestor De Gastos Mariofneto");
            Console.WriteLine("");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1 - Mostrar os Gastos\n2 - Inserir Gasto\n3 - Editar Gasto\n4 - Remover Gasto");
            Console.WriteLine("---------------------------");
            var esc = int.Parse(Console.ReadLine());
            EEscolha escolha = (EEscolha)esc;

            switch (escolha)
            {
                case EEscolha.Mostrar: Mostrar.MostrarGastos(); break;
                case EEscolha.Inserir: Inserir.InserirGastos(); break;
                case EEscolha.Editar: Editar.EditarGastos(); break;
                case EEscolha.Remover: Remover.RemoverGastosOuPerfil(); break;
                default: Console.WriteLine("Opção inválida!\nDigite um número de 1 a 4"); break;
            }

        }
    }


}