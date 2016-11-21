using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Util.Impresion.Web.Migrations
{
    public partial class CreacionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "guias");

            migrationBuilder.CreateTable(
                name: "Guias",
                schema: "guias",
                columns: table => new
                {
                    GuiaID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Numero = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Key1", x => x.GuiaID);
                });

            migrationBuilder.CreateTable(
                name: "Imagenes",
                schema: "guias",
                columns: table => new
                {
                    ImagenID = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Key_Imagenes", x => x.ImagenID);
                });

            migrationBuilder.CreateTable(
                name: "GuiasDet",
                schema: "guias",
                columns: table => new
                {
                    GuiaDetID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GuiaID = table.Column<long>(nullable: false),
                    ImagenID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_GuiasDet", x => x.GuiaDetID);
                    table.ForeignKey(
                        name: "Fk_Guias-GuiasDet",
                        column: x => x.GuiaID,
                        principalSchema: "guias",
                        principalTable: "Guias",
                        principalColumn: "GuiaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuiasDet_Imagenes_ImagenID",
                        column: x => x.ImagenID,
                        principalSchema: "guias",
                        principalTable: "Imagenes",
                        principalColumn: "ImagenID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuiasDet_GuiaID",
                schema: "guias",
                table: "GuiasDet",
                column: "GuiaID");

            migrationBuilder.CreateIndex(
                name: "IX_GuiasDet_ImagenID",
                schema: "guias",
                table: "GuiasDet",
                column: "ImagenID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuiasDet",
                schema: "guias");

            migrationBuilder.DropTable(
                name: "Guias",
                schema: "guias");

            migrationBuilder.DropTable(
                name: "Imagenes",
                schema: "guias");
        }
    }
}
