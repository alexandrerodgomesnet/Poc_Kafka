using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poc_Kafka.ORM.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Disciplina = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Nota = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");
        }
    }
}
