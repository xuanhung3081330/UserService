using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallProject.UserService.Infrastructure.Migrations
{
    public partial class AddIsDeletedPropertyToRetailer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Retailers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Retailers");
        }
    }
}
