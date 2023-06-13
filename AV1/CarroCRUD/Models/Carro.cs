using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarroCRUD.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public decimal Preco { get; set; }
        public bool Disponibilidade { get; set; }

    }
}
