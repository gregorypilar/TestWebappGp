using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionPermisos.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoPermiso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPermiso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreEmpleado = table.Column<string>(nullable: true),
                    ApellidoEmpleado = table.Column<string>(nullable: true),
                    TipoPermiso = table.Column<int>(nullable: false),
                    FechaPermiso = table.Column<DateTime>(nullable: false),
                    TipoPermisoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permisos_TipoPermiso_TipoPermisoId",
                        column: x => x.TipoPermisoId,
                        principalTable: "TipoPermiso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_TipoPermisoId",
                table: "Permisos",
                column: "TipoPermisoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "TipoPermiso");
        }
    }
}
