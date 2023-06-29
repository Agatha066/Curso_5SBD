using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativaMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal TaxaComissao { get; set; }
        public List<Contrato> ContratosVendidos { get; set; }
        public string Matricula { get; set; }
        public decimal SalarioBase { get; set; }


        public void CalcularComissoes()
        {
            decimal totalComissao = 0;

            foreach (var contrato in ContratosVendidos)
            {
                int numParcelasPagas = CalcularParcelasPagasPrimeiroAno(contrato);
                decimal comissao = CalcularComissaoContrato(numParcelasPagas, contrato);
                totalComissao += comissao;
            }

            // Aqui você pode fazer o que desejar com o valor total das comissões, como registrá-lo em algum lugar ou exibi-lo.
            Console.WriteLine($"O vendedor {Nome} possui um total de comissões de {totalComissao}.");
        }

        public int CalcularParcelasPagasPrimeiroAno(Contrato contrato)
        {
            DateTime dataInicio = contrato.DataContrato;
            DateTime dataFim = dataInicio.AddYears(1);
            int parcelasPagas = contrato.Pagamentos.Count(p => p.DataPagamento >= dataInicio && p.DataPagamento <= dataFim);
            return parcelasPagas;
        }

        public decimal CalcularComissaoContrato(int numParcelasPagas, Contrato contrato)
        {
            decimal valorParcela = contrato.ValorContrato / contrato.Prazo;
            decimal comissao = numParcelasPagas * valorParcela * TaxaComissao;
            return comissao;
        }
    }
}

