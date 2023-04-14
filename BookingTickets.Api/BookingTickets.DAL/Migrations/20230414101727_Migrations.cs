using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingTickets.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cinemas_CinemaDtoId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CinemaDtoId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CinemaDtoId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "EmployesId",
                table: "Cinemas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_EmployesId",
                table: "Cinemas",
                column: "EmployesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Users_EmployesId",
                table: "Cinemas",
                column: "EmployesId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Users_EmployesId",
                table: "Cinemas");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_EmployesId",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "EmployesId",
                table: "Cinemas");

            migrationBuilder.AddColumn<int>(
                name: "CinemaDtoId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CinemaDtoId",
                table: "Users",
                column: "CinemaDtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cinemas_CinemaDtoId",
                table: "Users",
                column: "CinemaDtoId",
                principalTable: "Cinemas",
                principalColumn: "Id");
        }
    }
}
