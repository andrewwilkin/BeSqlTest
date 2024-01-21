using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeSql.Client.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculationResults",
                columns: table => new
                {
                    OrganisationNodeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MeasureId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MeasureMetricId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReportMonth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationResults", x => x.OrganisationNodeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculationResults");
        }
    }
}
