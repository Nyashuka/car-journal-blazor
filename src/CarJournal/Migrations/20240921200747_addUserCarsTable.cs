using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarJournal.Migrations
{
    /// <inheritdoc />
    public partial class addUserCarsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StartMileage = table.Column<int>(type: "integer", nullable: false),
                    CurrentMileage = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CarId = table.Column<int>(type: "integer", nullable: true),
                    DateOfAdd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UserCars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 101, 37, 233, 37, 59, 86, 190, 139, 60, 55, 139, 168, 160, 113, 166, 54, 190, 169, 80, 63, 65, 112, 236, 15, 184, 33, 136, 35, 231, 183, 67, 199, 70, 139, 69, 232, 162, 128, 31, 33, 146, 63, 73, 184, 154, 109, 143, 72, 141, 25, 205, 147, 196, 155, 49, 253, 89, 196, 217, 231, 68, 107, 167, 171 }, new byte[] { 60, 133, 164, 126, 136, 90, 184, 77, 182, 34, 66, 234, 93, 221, 170, 195, 100, 163, 13, 250, 209, 14, 168, 82, 53, 27, 213, 129, 176, 173, 87, 138, 124, 130, 78, 23, 179, 160, 224, 164, 231, 95, 46, 127, 40, 162, 102, 23, 206, 64, 33, 42, 219, 142, 20, 205, 243, 227, 12, 255, 179, 96, 130, 200, 198, 122, 144, 149, 218, 134, 209, 93, 220, 217, 11, 71, 169, 239, 65, 167, 67, 255, 235, 202, 166, 21, 13, 146, 170, 192, 198, 244, 1, 24, 178, 156, 64, 32, 66, 72, 88, 211, 239, 110, 139, 179, 97, 62, 202, 54, 57, 64, 151, 246, 145, 204, 248, 142, 204, 130, 216, 133, 29, 156, 120, 183, 63, 216 } });

            migrationBuilder.CreateIndex(
                name: "IX_UserCars_CarId",
                table: "UserCars",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCars_UserId",
                table: "UserCars",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCars");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 200, 101, 96, 160, 64, 196, 14, 171, 85, 186, 233, 100, 134, 202, 203, 65, 86, 172, 90, 95, 138, 125, 43, 69, 221, 145, 217, 170, 229, 3, 34, 155, 249, 229, 217, 193, 197, 226, 1, 104, 139, 174, 20, 202, 133, 52, 176, 64, 241, 61, 199, 114, 64, 199, 59, 106, 173, 48, 155, 227, 131, 119, 130, 162 }, new byte[] { 216, 36, 71, 104, 69, 118, 4, 74, 215, 66, 197, 130, 136, 244, 62, 96, 112, 78, 107, 254, 234, 57, 132, 189, 226, 213, 53, 226, 214, 63, 53, 85, 230, 132, 62, 68, 138, 37, 0, 41, 218, 122, 97, 183, 165, 105, 228, 42, 149, 78, 80, 150, 59, 220, 179, 198, 181, 129, 172, 76, 97, 41, 109, 75, 34, 230, 115, 223, 74, 181, 185, 194, 238, 4, 171, 164, 209, 18, 185, 33, 30, 88, 94, 40, 236, 125, 94, 28, 223, 162, 92, 126, 57, 206, 37, 193, 108, 17, 102, 130, 225, 121, 136, 55, 245, 212, 27, 152, 180, 76, 98, 147, 153, 95, 38, 164, 208, 49, 162, 213, 120, 11, 184, 96, 70, 229, 207, 119 } });
        }
    }
}
