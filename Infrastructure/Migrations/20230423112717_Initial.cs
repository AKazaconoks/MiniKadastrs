using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Year = table.Column<string>(type: "TEXT", nullable: false),
                    AvgPriceRegion1 = table.Column<decimal>(type: "TEXT", nullable: false),
                    TransactionCountRegion1 = table.Column<int>(type: "INTEGER", nullable: false),
                    AvgPriceRegion2 = table.Column<decimal>(type: "TEXT", nullable: false),
                    TransactionCountRegion2 = table.Column<int>(type: "INTEGER", nullable: false),
                    AvgPriceRegion3 = table.Column<decimal>(type: "TEXT", nullable: false),
                    TransactionCountRegion3 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTransactions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyTransactions");
        }
    }
}
