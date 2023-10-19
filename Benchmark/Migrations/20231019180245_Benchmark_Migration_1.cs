using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Benchmark.Migrations
{
    /// <inheritdoc />
    public partial class Benchmark_Migration_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BenchmarkRecordNoBases",
                columns: table => new
                {
                    BenchmarkDbId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenchmarkRecordNoBases", x => x.BenchmarkDbId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenchmarkRecordNoBases");
        }
    }
}
