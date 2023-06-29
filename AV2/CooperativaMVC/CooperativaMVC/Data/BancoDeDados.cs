using CooperativaMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativaMVC.Data
{
    public class BancoDeDados : DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=CooperDB7;Integrated Security=True");
        }

        public DbSet<Associado> Associados { get; set; }
        public DbSet<BemDuravel> Bens { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // BemDuravel
            modelBuilder.Entity<BemDuravel>()
                .HasData(
                    new BemDuravel
                    {
                        Id = 1,
                        Nome = "TV",
                        Valor = 1500
                    },
                    new BemDuravel
                    {
                        Id = 2,
                        Nome = "Geladeira",
                        Valor = 2500
                    },
                    new BemDuravel
                    {
                        Id = 3,
                        Nome = "Notebook",
                        Valor = 3000
                    }
                );

            // Empresa
            modelBuilder.Entity<Empresa>()
                .HasData(
                    new Empresa
                    {
                        Id = 1,
                        Nome = "Empresa A",
                        TaxaComissao = 0.05m
                    },
                    new Empresa
                    {
                        Id = 2,
                        Nome = "Empresa B",
                        TaxaComissao = 0.07m
                    },
                    new Empresa
                    {
                        Id = 3,
                        Nome = "Empresa C",
                        TaxaComissao = 0.1m
                    }
                );

            // Associado
            modelBuilder.Entity<Associado>()
                .HasData(
                    new Associado { Id = 1, Nome = "João", SalarioMensal = 3000 },
                    new Associado { Id = 2, Nome = "Maria", SalarioMensal = 4000 },
                    new Associado { Id = 3, Nome = "Pedro", SalarioMensal = 2500 }
                );

            // Pagamento
            modelBuilder.Entity<Pagamento>()
                .HasData(
                    new Pagamento
                    {
                        Id = 1,
                        ContratoId = 1, // ID do contrato associado
                ValorPagamento = 1000,
                        DataPagamento = new DateTime(2023, 1, 15),
                        Status = "Pago",
                        RegistroSPC = false,
                        Pago = true,
                        SaldoDevedor = 4000
                    },
                    new Pagamento
                    {
                        Id = 2,
                        ContratoId = 1, // ID do contrato associado
                ValorPagamento = 1000,
                        DataPagamento = new DateTime(2023, 2, 15),
                        Status = "Pago",
                        RegistroSPC = false,
                        Pago = true,
                        SaldoDevedor = 3000
                    },
                    new Pagamento
                    {
                        Id = 3,
                        ContratoId = 2, // ID do contrato associado
                ValorPagamento = 800,
                        DataPagamento = new DateTime(2023, 1, 10),
                        Status = "Pago",
                        RegistroSPC = false,
                        Pago = true,
                        SaldoDevedor = 7200
                    }
                );

            // Vendedor
            modelBuilder.Entity<Vendedor>()
                .HasData(
                    new Vendedor
                    {
                        Id = 1,
                        Nome = "João",
                        TaxaComissao = 0.1m,
                        Matricula = "VND001",
                        SalarioBase = 2000
                    },
                    new Vendedor
                    {
                        Id = 2,
                        Nome = "Maria",
                        TaxaComissao = 0.15m,
                        Matricula = "VND002",
                        SalarioBase = 2500
                    }
                );

            // Contrato
            modelBuilder.Entity<Contrato>()
                .HasData(
                    new Contrato
                    {
                        Id = 1,
                        VendedorId = 1, // ID do vendedor associado
                        ValorContrato = 5000,
                        DataContrato = new DateTime(2023, 1, 1),
                        Prazo = 12,
                        TaxaJuros = 0.05m,
                        BemDuravelId = 1, // ID do bem durável associado
                        Pagamentos = new List<Pagamento>(), // Inclua os pagamentos relacionados
                        FuncionarioId = 1, // ID do funcionário associado
                        EmpresaId = 1, // ID da empresa associada
                        AssociadoId = 1 // ID do associado associado
        },
                    new Contrato
                    {
                        Id = 2,
                        VendedorId = 1, // ID do vendedor associado
                        ValorContrato = 8000,
                        DataContrato = new DateTime(2023, 2, 1),
                        Prazo = 24,
                        TaxaJuros = 0.08m,
                        BemDuravelId = 1, // ID do bem durável associado
                        Pagamentos = new List<Pagamento>(), // Inclua os pagamentos relacionados
                        FuncionarioId = 2, // ID do funcionário associado
                        EmpresaId = 2, // ID da empresa associada
                        AssociadoId = 2 // ID do associado associado
        },
                    new Contrato
                    {
                        Id = 3,
                        VendedorId = 2, // ID do vendedor associado
                        ValorContrato = 6000,
                        DataContrato = new DateTime(2023, 3, 1),
                        Prazo = 18,
                        TaxaJuros = 0.06m,
                        BemDuravelId = 2, // ID do bem durável associado
                        Pagamentos = new List<Pagamento>(), // Inclua os pagamentos relacionados
                        FuncionarioId = 3, // ID do funcionário associado
                        EmpresaId = 3, // ID da empresa associada
                        AssociadoId = 3 // ID do associado associado
        }
                );

            // Funcionario
            modelBuilder.Entity<Funcionario>()
                .HasData(
                    new Funcionario
                    {
                        Id = 1,
                        Nome = "João Silva",
                        SalarioMensal = 3000,
                        CPF = "123.456.789-00",
                        LimiteEndividamentoMensal = 900,
                        NomeLimpoNaPraca = true
                    },
                    new Funcionario
                    {
                        Id = 2,
                        Nome = "Maria Santos",
                        SalarioMensal = 4000,
                        CPF = "987.654.321-00",
                        LimiteEndividamentoMensal = 1200,
                        NomeLimpoNaPraca = true
                    },
                    new Funcionario
                    {
                        Id = 3,
                        Nome = "Pedro Oliveira",
                        SalarioMensal = 2500,
                        CPF = "567.890.123-00",
                        LimiteEndividamentoMensal = 750,
                        NomeLimpoNaPraca = false
                    }
                );
        }

        public override int SaveChanges()
        {
            decimal taxaJuros = 0.1M;
            int prazo = 10;
            decimal valorEmprestimo = 1000;
            decimal valorPagamento = 1000.00m;
            decimal valorFinanciamento = 10000.00m;

            Contrato contrato = new Contrato
            {
                Id = 3,
                ValorContrato = 6000,
                DataContrato = new DateTime(2023, 3, 1),
                Prazo = 18,
                TaxaJuros = 0.06m,
                Pagamentos = new List<Pagamento>(),
                Status = "Ativo"
            };

            BemDuravel bemD = new BemDuravel
            {
                Id = 2,
                Nome = "Geladeira",
                Valor = 2500
            };

            var bemDuraveis = ChangeTracker.Entries<BemDuravel>()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity);

            var empresas = ChangeTracker.Entries<Empresa>()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity);

            var associados = ChangeTracker.Entries<Associado>()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity);

            var funcionarios = ChangeTracker.Entries<Funcionario>()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity);

            var pagamentos = ChangeTracker.Entries<Pagamento>()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity);

            var vendedores = ChangeTracker.Entries<Vendedor>()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity);

            var contratos = ChangeTracker.Entries<Contrato>()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity);


          
            // Exemplo de uso dos dados de Empresa
            foreach (var empres in empresas)
            {
                empres.ConcederEmprestimo(valorEmprestimo, taxaJuros, prazo);
                empres.RegistrarPagamentoEmprestimo(contrato, valorPagamento);
                empres.RegistrarNoSPC();
            }

            // Exemplo de uso dos dados de Associado
            foreach (var associado in associados)
            {
                associado.SolicitarEmprestimo(associado.ValorEmprestado, taxaJuros);
            }

            foreach (var contrat in contratos)
            {
                var comissao = contrat.CalcularComissao();
                var Atrasados = contrat.VerificarPagamentoAtrasado();
            }

            foreach (var funcio in funcionarios)
            {
                funcio.FinanciarBemDuravel(bemD, valorFinanciamento, prazo);
                funcio.RegistrarPagamentoParcela(contrato, valorPagamento, funcio);
                funcio.CalcularValorParcela(valorFinanciamento, prazo);
                funcio.VerificarInadimplencia(contrato);
                var inadimplencia = contrato.VerificarPagamentoAtrasado();
                funcio.RegistrarNoSPC(funcio);
            }

            foreach (var pagament in pagamentos)
            {
                var pagamentosAtrasados = pagament.VerificarPagamentoAtrasado();
                var registroPG = pagament.RegistrarPagamento(pagament.ValorPagamento, pagament.DataPagamento, pagament);
            }

            foreach (var vended in vendedores)
            {
                vended.CalcularComissoes();
                var parcelasPagas = vended.CalcularParcelasPagasPrimeiroAno(contrato);
            }

            // Salvar as alterações no banco de dados
            return base.SaveChanges();

        }
        //public IEnumerable<Vendedor> ObterDados()
        //{
        //    var vendedores = this.Set<Vendedor>().ToList();
        //    return vendedores;
        //}

        public IEnumerable<Contrato> ObterDados()
        {
            return this.Set<Contrato>()
                .Include(c => c.Pagamentos)
                .Include(c => c.Vendedores)
                .Include(c => c.Funcionario)
                .Include(c => c.Empresa)
                .Include(c => c.BemDuravel)
                .Include(c => c.Associado)
                .ToList();
        }

    }
}