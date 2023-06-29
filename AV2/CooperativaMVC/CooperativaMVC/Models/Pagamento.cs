using CooperativaMVC.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativaMVC.Models
{
    public class Pagamento
    {
        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }
        public decimal ValorPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public string Status { get; set; } // para indicar o status do pagamento, como "Pago", "Em atraso" ou "Pendente"
        public int Id { get; set; }
        public bool RegistroSPC { get; set; }
        public IEnumerable<Pagamento> Parcela { get; set; }
        public bool Pago { get; set; }
        public decimal SaldoDevedor { get; set; }
     
        public bool VerificarPagamentoAtrasado()
        {
             DateTime ultimaParcelaPaga = Parcela.Where(p => p.Pago).OrderByDescending(p => p.DataPagamento).First().DataPagamento;
             DateTime mesAnterior = DateTime.Now.AddMonths(-1);
             if (ultimaParcelaPaga < mesAnterior)
             {
                 return RegistroSPC = true;
             }
           
            return false;
        }
        public bool RegistrarPagamento(decimal valorPagamento, DateTime dataPagamento, Pagamento Pagamentos)
        {
            Pagamento novoPagamento = new Pagamento
            {
                ValorPagamento = valorPagamento,
                DataPagamento = dataPagamento,
                Pago = true
            };

            
            // Atualizar informações do contrato com base no pagamento
            SaldoDevedor -= valorPagamento;

            // Verificar se todas as parcelas foram pagas
            bool todasParcelasPagas = true;
            foreach (var parcel in Parcela)
            {
                if (!Pago)
                {
                    return todasParcelasPagas = false;
                }
            }

            if (todasParcelasPagas)
            {
                Status = "Pago";
                return true;
            }
            return false;
        }

    }

}
