using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionPermisos.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permisos_TipoPermiso_TipoPermisoId",
                table: "Permisos");

            migrationBuilder.DropColumn(
                name: "TipoPermiso",
                table: "Permisos");

            migrationBuilder.AlterColumn<int>(
                name: "TipoPermisoId",
                table: "Permisos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Permisos_TipoPermiso_TipoPermisoId",
                table: "Permisos",
                column: "TipoPermisoId",
                principalTable: "TipoPermiso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permisos_TipoPermiso_TipoPermisoId",
                table: "Permisos");

            migrationBuilder.AlterColumn<int>(
                name: "TipoPermisoId",
                table: "Permisos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TipoPermiso",
                table: "Permisos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Permisos_TipoPermiso_TipoPermisoId",
                table: "Permisos",
                column: "TipoPermisoId",
                principalTable: "TipoPermiso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
