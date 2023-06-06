using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Este campo é preenchimento obrigatório")]
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Telefone { get; set; }
    }
}
