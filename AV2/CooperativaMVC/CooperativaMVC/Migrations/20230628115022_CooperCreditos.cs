using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CooperativaMVC.Migrations
{
    public partial class CooperCreditos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Associados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalarioMensal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorEmprestado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MargemConsignada = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxaComissao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComissaoRecebida = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalarioMensal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LimiteEndividamentoMensal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NomeLimpoNaPraca = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxaComissao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalarioBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorContrato = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataContrato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prazo = table.Column<int>(type: "int", nullable: false),
                    TaxaJuros = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPagamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendedorId = table.Column<int>(type: "int", nullable: false),
                    BemDuravelId = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    AssociadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Associados_AssociadoId",
                        column: x => x.AssociadoId,
                        principalTable: "Associados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_Bens_BemDuravelId",
                        column: x => x.BemDuravelId,
                        principalTable: "Bens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_Vendedores_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    ValorPagamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistroSPC = table.Column<bool>(type: "bit", nullable: false),
                    Pago = table.Column<bool>(type: "bit", nullable: false),
                    SaldoDevedor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PagamentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Pagamentos_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "Pagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Associados",
                columns: new[] { "Id", "MargemConsignada", "Nome", "SalarioMensal", "ValorEmprestado" },
                values: new object[,]
                {
                    { 1, 0m, "João", 3000m, 0m },
                    { 2, 0m, "Maria", 4000m, 0m },
                    { 3, 0m, "Pedro", 2500m, 0m }
                });

            migrationBuilder.InsertData(
                table: "Bens",
                columns: new[] { "Id", "Nome", "Valor" },
                values: new object[,]
                {
                    { 1, "TV", 1500m },
                    { 2, "Geladeira", 2500m },
                    { 3, "Notebook", 3000m }
                });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "Id", "ComissaoRecebida", "Nome", "TaxaComissao" },
                values: new object[,]
                {
                    { 1, 0m, "Empresa A", 0.05m },
                    { 2, 0m, "Empresa B", 0.07m },
                    { 3, 0m, "Empresa C", 0.1m }
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "CPF", "LimiteEndividamentoMensal", "Nome", "NomeLimpoNaPraca", "SalarioMensal" },
                values: new object[,]
                {
                    { 1, "123.456.789-00", 900m, "João Silva", true, 3000m },
                    { 2, "987.654.321-00", 1200m, "Maria Santos", true, 4000m },
                    { 3, "567.890.123-00", 750m, "Pedro Oliveira", false, 2500m }
                });

            migrationBuilder.InsertData(
                table: "Vendedores",
                columns: new[] { "Id", "Matricula", "Nome", "SalarioBase", "TaxaComissao" },
                values: new object[,]
                {
                    { 1, "VND001", "João", 2000m, 0.1m },
                    { 2, "VND002", "Maria", 2500m, 0.15m }
                });

            migrationBuilder.InsertData(
                table: "Contratos",
                columns: new[] { "Id", "AssociadoId", "BemDuravelId", "DataContrato", "EmpresaId", "FuncionarioId", "Prazo", "Status", "TaxaJuros", "ValorContrato", "ValorPagamento", "VendedorId" },
                values: new object[] { 1, 1, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 12, null, 0.05m, 5000m, 0m, 1 });

            migrationBuilder.InsertData(
                table: "Contratos",
                columns: new[] { "Id", "AssociadoId", "BemDuravelId", "DataContrato", "EmpresaId", "FuncionarioId", "Prazo", "Status", "TaxaJuros", "ValorContrato", "ValorPagamento", "VendedorId" },
                values: new object[] { 2, 2, 1, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 24, null, 0.08m, 8000m, 0m, 1 });

            migrationBuilder.InsertData(
                table: "Contratos",
                columns: new[] { "Id", "AssociadoId", "BemDuravelId", "DataContrato", "EmpresaId", "FuncionarioId", "Prazo", "Status", "TaxaJuros", "ValorContrato", "ValorPagamento", "VendedorId" },
                values: new object[] { 3, 3, 2, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 18, null, 0.06m, 6000m, 0m, 2 });

            migrationBuilder.InsertData(
                table: "Pagamentos",
                columns: new[] { "Id", "ContratoId", "DataPagamento", "PagamentoId", "Pago", "RegistroSPC", "SaldoDevedor", "Status", "ValorPagamento" },
                values: new object[] { 1, 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 4000m, "Pago", 1000m });

            migrationBuilder.InsertData(
                table: "Pagamentos",
                columns: new[] { "Id", "ContratoId", "DataPagamento", "PagamentoId", "Pago", "RegistroSPC", "SaldoDevedor", "Status", "ValorPagamento" },
                values: new object[] { 2, 1, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 3000m, "Pago", 1000m });

            migrationBuilder.InsertData(
                table: "Pagamentos",
                columns: new[] { "Id", "ContratoId", "DataPagamento", "PagamentoId", "Pago", "RegistroSPC", "SaldoDevedor", "Status", "ValorPagamento" },
                values: new object[] { 3, 2, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 7200m, "Pago", 800m });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_AssociadoId",
                table: "Contratos",
                column: "AssociadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_BemDuravelId",
                table: "Contratos",
                column: "BemDuravelId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_EmpresaId",
                table: "Contratos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_FuncionarioId",
                table: "Contratos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_VendedorId",
                table: "Contratos",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_ContratoId",
                table: "Pagamentos",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_PagamentoId",
                table: "Pagamentos",
                column: "PagamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Associados");

            migrationBuilder.DropTable(
                name: "Bens");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Vendedores");
        }
    }
}
