using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Benchmark.Migrations
{
    /// <inheritdoc />
    public partial class Benchmark_Migration_0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BenchmarkRecords",
                columns: table => new
                {
                    BenchmarkDbId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenchmarkRecords", x => x.BenchmarkDbId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenchmarkRecords");
        }
    }
}
