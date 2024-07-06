using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RicckyStore.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    marque = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    categorie = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    prix = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageFichierNom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dateAjout = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produits");
        }
    }
}
