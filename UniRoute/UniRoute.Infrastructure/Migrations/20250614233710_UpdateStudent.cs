using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniRoute.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_Mail",
                table: "Students",
                column: "Mail",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_Mail",
                table: "Students");
        }
    }
}
