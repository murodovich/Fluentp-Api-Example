using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faluent_Api.Application.Migrations
{
    /// <inheritdoc />
    public partial class sarva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookCategoryId",
                table: "BookCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookCategoryId",
                table: "BookCategories");
        }
    }
}
