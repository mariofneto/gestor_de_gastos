using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestor_de_gastos.Models
{
    public class Gasto
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public Pessoa Pessoa { get; set; }
    }
}