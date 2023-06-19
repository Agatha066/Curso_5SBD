using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarroCRUD.Models
{
    public class Pagamento
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int PagamentoId { get; set; }
            public string NomeTitular { get; set; }
            public string NumeroCartao { get; set; }
            public string DataValidade { get; set; }
            public string CVV { get; set; } //código de segurança presente nos cartões

        // Outras propriedades relevantes para o pagamento

        public bool ProcessarPagamento(decimal valor)
            {
                if (!string.IsNullOrEmpty(NomeTitular) && !string.IsNullOrEmpty(NumeroCartao) && !string.IsNullOrEmpty(CVV))
                {
                    return true;
                }
                return false;
            }

    }
}
