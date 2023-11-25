using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityRoleAuthorization.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductImageUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Product");
        }
    }
}
