using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativaMVC.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal SalarioMensal { get; set; }
        public string CPF { get; set; }
        public decimal LimiteEndividamentoMensal { get; set; }
        public bool NomeLimpoNaPraca { get;  set; }

        public Contrato FinanciarBemDuravel(BemDuravel bem, decimal valorFinanciamento, int prazo)
        {
            // Verificar se a pessoa financiada possui o "nome limpo na praça"
            if (!NomeLimpoNaPraca)
            {
                throw new Exception("A pessoa financiada não possui o nome limpo na praça.");
            }

            // Verificar se o prazo do financiamento está dentro do limite
            if (prazo > 24)
            {
                throw new Exception("O prazo máximo para financiamento é de 24 meses.");
            }
  
            // Criar um novo contrato de financiamento
            var contrato = new Contrato
            {
                
                ValorContrato = valorFinanciamento,
                DataContrato = DateTime.Now,
                Prazo = prazo
               
            };

            return contrato;
        }

        public void RegistrarPagamentoParcela(Contrato contrato, decimal valorPagamento, Funcionario funcionario)
        {
            // Verificar se o pagamento é igual ao valor da parcela
            decimal valorParcela = CalcularValorParcela(contrato.ValorContrato, contrato.Prazo);
            if (valorPagamento != valorParcela)
            {
                throw new Exception("O valor do pagamento da parcela está incorreto.");
            }

            // Registrar o pagamento da parcela
            var pagamento = new Pagamento
            {
                Contrato = contrato,
                ValorPagamento = valorPagamento,
                DataPagamento = DateTime.Now
            };

            contrato.Pagamentos.Add(pagamento);

            // Verificar se houve inadimplência por dois meses consecutivos
            if (contrato.Pagamentos.Count >= 2)
            {
                bool inadimplencia = VerificarInadimplencia(contrato);
                if (inadimplencia)
                {
                    // Registrar no SPC
                    RegistrarNoSPC(funcionario);
                }
            }
        }

        public decimal CalcularValorParcela(decimal valorFinanciamento, int prazo)
        {
            // Implemente a lógica para calcular o valor da parcela do financiamento
            decimal valorParcela = valorFinanciamento / prazo; // Exemplo: Parcelas iguais durante o prazo do financiamento
            return valorParcela;
        }

        public bool VerificarInadimplencia(Contrato contrato)
        {
            // Implemente a lógica para verificar se houve inadimplência por dois meses consecutivos
            var pagamentos = contrato.Pagamentos;
            int count = pagamentos.Count;
            if (count >= 2)
            {
                var ultimoPagamento = pagamentos[count - 1];
                var penultimoPagamento = pagamentos[count - 2];
                if (ultimoPagamento.DataPagamento.AddMonths(-1) == penultimoPagamento.DataPagamento)
                {
                    return false; // Não houve inadimplência por dois meses consecutivos
                }
            }

            return true; // Houve inadimplência por dois meses consecutivos
        }

        public void RegistrarNoSPC(Funcionario funcionario)
        {
            // Implemente a lógica para registrar o funcionário no SPC
            Console.WriteLine($"O funcionário {funcionario.Nome} foi registrado no SPC devido à inadimplência.");
        }
    }
}

