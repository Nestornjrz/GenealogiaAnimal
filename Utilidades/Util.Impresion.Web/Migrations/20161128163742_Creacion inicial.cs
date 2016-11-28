using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Util.Impresion.Web.Migrations
{
    public partial class Creacioninicial : Migration
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
                name: "ProveeClientes",
                schema: "guias",
                columns: table => new
                {
                    ProveeClienteID = table.Column<int>(nullable: false),
                    ClienteSn = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false),
                    ProveedorSn = table.Column<bool>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Estancias", x => x.ProveeClienteID);
                });

            migrationBuilder.CreateTable(
                name: "Imagenes",
                schema: "guias",
                columns: table => new
                {
                    ImagenID = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false),
                    ProveedorID = table.Column<int>(nullable: false),
                    VigenteSn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Imagenes", x => x.ImagenID);
                    table.ForeignKey(
                        name: "FK_Imagenes_ProveeClientes_ProveedorID",
                        column: x => x.ProveedorID,
                        principalSchema: "guias",
                        principalTable: "ProveeClientes",
                        principalColumn: "ProveeClienteID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuiasDet",
                schema: "guias",
                columns: table => new
                {
                    GuiaDetID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteID = table.Column<int>(nullable: true),
                    GuiaID = table.Column<long>(nullable: false),
                    ImagenID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_GuiasDet", x => x.GuiaDetID);
                    table.ForeignKey(
                        name: "FK_GuiasDet_ProveeClientes_ClienteID",
                        column: x => x.ClienteID,
                        principalSchema: "guias",
                        principalTable: "ProveeClientes",
                        principalColumn: "ProveeClienteID",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_GuasDet_ClienteID",
                schema: "guias",
                table: "GuiasDet",
                column: "ClienteID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Imagenes_ProveedorID",
                schema: "guias",
                table: "Imagenes",
                column: "ProveedorID");
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

            migrationBuilder.DropTable(
                name: "ProveeClientes",
                schema: "guias");
        }
    }
}
