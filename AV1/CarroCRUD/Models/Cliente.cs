using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarroCRUD.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo de login é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo de senha é obrigatório.")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 10 caracteres.")]
        public string Password { get; set; }
    }

}
