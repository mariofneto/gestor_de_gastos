using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestor_de_gastos.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<Gasto> Gastos { get; set; }
    }
}