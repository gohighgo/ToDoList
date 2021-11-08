using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoListLogin.Migrations
{
    public partial class TaskStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbStatus",
                columns: table => new
                {
                    Status_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status_Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbStatus", x => x.Status_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbTask",
                columns: table => new
                {
                    Task_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(nullable: false),
                    Task_Name = table.Column<string>(maxLength: 50, nullable: true),
                    Task_Description = table.Column<string>(maxLength: 250, nullable: true),
                    Status_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTask", x => x.Task_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbStatus");

            migrationBuilder.DropTable(
                name: "tbTask");
        }
    }
}
