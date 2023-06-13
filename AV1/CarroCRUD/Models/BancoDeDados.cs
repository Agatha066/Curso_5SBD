using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarroCRUD.Models;
using System.Web.Mvc;


namespace CarroCRUD.Models
{
    public class BancoDeDados : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=CarroCRUD2;Integrated Security=True");
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }
        public DbSet<CarroCRUD.Models.Pagamento> Pagamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            //Clientes

            modelBuilder.Entity<Cliente>()

                .Property(p => p.Nome)

                    .HasMaxLength(150);



            modelBuilder.Entity<Cliente>()

                .Property(p => p.Email)

                    .HasMaxLength(250);



            modelBuilder.Entity<Cliente>()

                .HasData(

                    new Cliente { Id = 1, Nome = "Ana Luiza", Email = "ana@email.com", Password = "123456" },

                    new Cliente { Id = 2, Nome = "Fernanda Mark", Email = "fernanda@email.com", Password = "123456" },

                    new Cliente { Id = 3, Nome = "Matheus Junior", Email = "thues@email.com", Password = "123456" }
                );

            //Carros
            modelBuilder.Entity<Carro>()

                .Property(p => p.Modelo)

                    .HasMaxLength(80);



            modelBuilder.Entity<Carro>()

                .Property(p => p.Preco)

                    .HasPrecision(10, 2);



            modelBuilder.Entity<Carro>()

                .HasData(

                    new Carro { Id = 1, Modelo = "FIESTA", Ano = "2020", Preco = 70.50M, Disponibilidade = true },

                    new Carro { Id = 2, Modelo = "PALIO", Ano = "2022", Preco = 90.00M, Disponibilidade = false },

                    new Carro { Id = 3, Modelo = "GOL", Ano = "1999", Preco = 50.95M, Disponibilidade = true }

                );

            //Alugueis
            Carro carro = new Carro { Id = 2, Modelo = "PALIO", Ano = "2022", Preco = 90.00M, Disponibilidade = false };
            //Cliente cliente = new Cliente { Id = 1, Nome = "Ana Luiza", Email = "ana@email.com", Password = "123456" };

            modelBuilder.Entity<Aluguel>()

               .HasData(
                   new Aluguel { Id = 1, IdCarro = 2, IdCliente = 1, DataAluguel = DateTime.Now, DateReturno = DateTime.Now.AddDays(2), ValorTotal = (carro.Preco * 2), Pagamento = null }
               );

            
        }

        public override int SaveChanges()
        {
            // Obter os aluguéis adicionados
            var alugueisAdicionados = ChangeTracker.Entries<Aluguel>()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity);

            // Executar lógica para cada novo aluguel
            foreach (var aluguel in alugueisAdicionados)
            {
                // Verificar a disponibilidade do carro com base na data do aluguel
                if (aluguel.IdCarro != null)
                {
                    var carro = Carros.Find(aluguel.IdCarro);

                    if (carro != null)
                    {
                        if (aluguel.DataAluguel.Date >= DateTime.Today && aluguel.DataAluguel.Date <= DateTime.Today.AddDays(2))
                        {
                            carro.Disponibilidade = false; // Carro não disponível

                            // Calcular o valor total do aluguel multiplicando o preço do carro pela quantidade de dias de aluguel
                            TimeSpan duracaoAluguel = aluguel.DateReturno.Date - aluguel.DataAluguel.Date;
                            int quantidadeDias = duracaoAluguel.Days;
                            aluguel.ValorTotal = carro.Preco * quantidadeDias;

                            // Processar o pagamento usando as informações fornecidas
                            var informacoesPagamento = new Pagamento
                            {
                                NomeTitular = aluguel.Pagamento.NomeTitular,
                                NumeroCartao = aluguel.Pagamento.NumeroCartao,
                                DataValidade = aluguel.Pagamento.DataValidade,
                                CVV = aluguel.Pagamento.CVV
                            };

                            bool pagamentoProcessado = informacoesPagamento.ProcessarPagamento(aluguel.ValorTotal);

                            if (!pagamentoProcessado)
                            {
                                // Se o pagamento não for bem-sucedido, você pode tratar o erro aqui
                                // Por exemplo, lançar uma exceção, adicionar mensagens de erro ao ModelState, etc.
                                throw new Exception("Erro ao processar o pagamento");
                            }
                        }
                    }
                }
            }

            // Salvar as alterações no banco de dados
            int rowsAffected = base.SaveChanges();

            // Retornar o número de linhas afetadas
            return rowsAffected;
        }
    }
}
