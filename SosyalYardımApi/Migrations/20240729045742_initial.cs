using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SosyalYardimApi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SosyalYardimlar",
                columns: table => new
                {
                    OdemeNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TcKimlikNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    MusteriAd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MusteriSoyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OdemeKd = table.Column<int>(type: "int", nullable: false),
                    OdenecekTtr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OdemeTr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OdemeAck = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SosyalYardimlar", x => x.OdemeNo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SosyalYardimlar");
        }
    }
}
