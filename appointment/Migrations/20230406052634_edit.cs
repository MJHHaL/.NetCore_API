using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appointment.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Clinics_ClinicID",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ClinicID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ClinicID",
                table: "Appointments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClinicID",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClinicID",
                table: "Appointments",
                column: "ClinicID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Clinics_ClinicID",
                table: "Appointments",
                column: "ClinicID",
                principalTable: "Clinics",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
