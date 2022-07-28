using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Migrations
{
    public partial class UpdatedEnums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Guardians_ParentID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "ParentID",
                table: "Students",
                newName: "Guardian");

            migrationBuilder.RenameIndex(
                name: "IX_Students_ParentID",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Guardians_Guardian",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Guardian",
                table: "Students",
                newName: "ParentID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_Guardian",
                table: "Students",
                newName: "IX_Students_ParentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Guardians_ParentID",
                table: "Students",
                column: "ParentID",
                principalTable: "Guardians",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
