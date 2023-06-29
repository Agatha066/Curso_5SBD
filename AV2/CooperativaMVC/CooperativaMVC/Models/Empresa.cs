using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativaMVC.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal TaxaComissao { get; set; }
        public decimal ComissaoRecebida { get; set; }
        public List<Contrato> Contratos { get; set; }


        public void ConcederEmprestimo(decimal valorEmprestimo, decimal taxaJuros, int prazo)
        {
            // Lógica para conceder um empréstimo ao associado
            decimal valorTotal = valorEmprestimo + (valorEmprestimo * taxaJuros);
            decimal valorParcela = valorTotal / prazo;

            // Exemplo de impressão dos valores calculados
            Console.WriteLine($"Valor total do empréstimo: {valorTotal}");
            Console.WriteLine($"Valor da parcela mensal: {valorParcela}");
        }

        public void RegistrarPagamentoEmprestimo(Contrato contrato, decimal valorPagamento)
        {
            // Lógica para registrar o pagamento de uma parcela do empréstimo
            contrato.ValorPagamento += valorPagamento;

            // Exemplo de verificação do status do contrato
            if (contrato.ValorPagamento >= contrato.ValorContrato)
            {
                contrato.Status = "Quitado";
                Console.WriteLine("Contrato quitado!");
            }
            else
            {
                Console.WriteLine("Pagamento registrado.");
            }
        }

        public void RegistrarNoSPC()
        {
            // Lógica para registrar o associado no SPC
            Console.WriteLine("Associado registrado no SPC.");
        }

    }

}
