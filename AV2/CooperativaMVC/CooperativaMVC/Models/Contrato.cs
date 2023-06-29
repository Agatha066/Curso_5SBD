using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativaMVC.Models
{
    public class Contrato
    {

        public int Id { get; set; }
        public decimal ValorContrato { get; set; }
        public DateTime DataContrato { get; set; }
        public int Prazo { get; set; }
        public decimal TaxaJuros { get; set; }
        public List<Pagamento> Pagamentos { get; set; }
        public decimal ValorPagamento { get; set; }
        public string Status { get;  set; }
        public int VendedorId { get; internal set; }
        public int BemDuravelId { get; internal set; }

        // Relacionamentos
        public Vendedor Vendedores { get; set; }

        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        public BemDuravel BemDuravel { get; set; }

        public int AssociadoId { get; set; }
        public Associado Associado { get; set; }

        public decimal CalcularComissao()
        {
            int numParcelasPagas = Pagamentos.Count;
            decimal valorParcela = ValorContrato / 12;
            decimal comissao = numParcelasPagas * valorParcela;

            return comissao;
        }



        public bool VerificarPagamentoAtrasado()
        {
            if (Pagamentos.Count >= 2)
            {
                DateTime ultimoPagamento = Pagamentos.OrderByDescending(p => p.DataPagamento).First().DataPagamento;
                DateTime mesAnterior = DateTime.Now.AddMonths(-1);
                if (ultimoPagamento < mesAnterior)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
