using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarroCRUD.Models
{
    public class Aluguel
    {
        public int Id { get; set; }
        public int IdCarro { get; set; }
        public int IdCliente { get; set; }
        public DateTime DataAluguel { get; set; }
        public DateTime DateReturno { get; set; }
        public decimal ValorTotal { get; set; }
        public Pagamento Pagamento { get; set; }
      
    }
}
