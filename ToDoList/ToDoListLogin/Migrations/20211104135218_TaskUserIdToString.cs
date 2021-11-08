using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoListLogin.Migrations
{
    public partial class TaskUserIdToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "User_Id",
                table: "tbTask",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "User_Id",
                table: "tbTask",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);
        }
    }
}
