using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingTickets.DAL.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Users_EmployesId",
                table: "Cinemas");

            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Cinemas_CinemaDtoId",
                table: "Halls");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Sessions_SessionDtoId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserDtoId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Halls_HallDtoId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SessionDtoId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserDtoId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Halls_CinemaDtoId",
                table: "Halls");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_EmployesId",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "HallId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "TimeStart",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "SessionDtoId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserDtoId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CinemaDtoId",
                table: "Halls");

            migrationBuilder.DropColumn(
                name: "EmployesId",
                table: "Cinemas");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HallDtoId",
                table: "Sessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "Halls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CinemaId",
                table: "Users",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SessionId",
                table: "Orders",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Halls_CinemaId",
                table: "Halls",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_Cinemas_CinemaId",
                table: "Halls",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Sessions_SessionId",
                table: "Orders",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Halls_HallDtoId",
                table: "Sessions",
                column: "HallDtoId",
                principalTable: "Halls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cinemas_CinemaId",
                table: "Users",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Cinemas_CinemaId",
                table: "Halls");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Sessions_SessionId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Halls_HallDtoId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cinemas_CinemaId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CinemaId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SessionId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Halls_CinemaId",
                table: "Halls");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "Halls");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "HallDtoId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HallId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStart",
                table: "Sessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SessionDtoId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserDtoId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CinemaDtoId",
                table: "Halls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployesId",
                table: "Cinemas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SessionDtoId",
                table: "Orders",
                column: "SessionDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserDtoId",
                table: "Orders",
                column: "UserDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_Halls_CinemaDtoId",
                table: "Halls",
                column: "CinemaDtoId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_Cinemas_CinemaDtoId",
                table: "Halls",
                column: "CinemaDtoId",
                principalTable: "Cinemas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Sessions_SessionDtoId",
                table: "Orders",
                column: "SessionDtoId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserDtoId",
                table: "Orders",
                column: "UserDtoId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Halls_HallDtoId",
                table: "Sessions",
                column: "HallDtoId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
