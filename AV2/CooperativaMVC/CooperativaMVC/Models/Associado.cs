using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativaMVC.Models
{
    public class Associado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal SalarioMensal { get; set; }
        public decimal ValorEmprestado { get; private set; }
        public decimal MargemConsignada { get; private set; }

        public bool SolicitarEmprestimo(decimal valorEmprestimo, decimal taxaJuros)
        {
            decimal valorParcela = valorEmprestimo / 12;
            decimal margemDisponivel = SalarioMensal * 0.3m; // 30% do salário mensal

            if (valorEmprestimo <= margemDisponivel)
            {
                ValorEmprestado = valorEmprestimo;
                MargemConsignada = margemDisponivel - valorParcela;
                return true;
            }

            return false;
        }
    }

}
