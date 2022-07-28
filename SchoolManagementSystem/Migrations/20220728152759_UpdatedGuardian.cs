using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Migrations
{
    public partial class UpdatedGuardian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Guardians_Guardian",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Guardian",
                table: "Students",
                newName: "GuardianID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_Guardian",
                table: "Students",
                newName: "IX_Students_GuardianID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CNIC",
                table: "Students",
                column: "CNIC",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Guardians_GuardianID",
                table: "Students",
                column: "GuardianID",
                principalTable: "Guardians",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Guardians_GuardianID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CNIC",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "GuardianID",
                table: "Students",
                newName: "Guardian");

            migrationBuilder.RenameIndex(
                name: "IX_Students_GuardianID",
                table: "Students",
                newName: "IX_Students_Guardian");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Guardians_Guardian",
                table: "Students",
                column: "Guardian",
                principalTable: "Guardians",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
