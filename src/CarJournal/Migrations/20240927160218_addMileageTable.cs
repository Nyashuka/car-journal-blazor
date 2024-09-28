using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarJournal.Migrations
{
    /// <inheritdoc />
    public partial class addMileageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MileageRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Mileage = table.Column<int>(type: "integer", nullable: false),
                    IsAutomatic = table.Column<bool>(type: "boolean", nullable: false),
                    UserCarId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MileageRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MileageRecords_UserCars_UserCarId",
                        column: x => x.UserCarId,
                        principalTable: "UserCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 182, 84, 109, 205, 72, 58, 89, 19, 54, 164, 37, 44, 57, 155, 57, 145, 66, 114, 127, 31, 14, 105, 192, 202, 203, 168, 119, 174, 99, 60, 70, 119, 93, 100, 239, 114, 136, 169, 79, 225, 102, 4, 174, 118, 107, 69, 44, 74, 129, 47, 221, 38, 66, 151, 244, 171, 190, 1, 241, 151, 179, 187, 79, 52 }, new byte[] { 231, 249, 0, 201, 254, 38, 189, 203, 21, 164, 153, 43, 223, 50, 44, 116, 199, 254, 174, 206, 78, 229, 95, 95, 43, 88, 251, 182, 31, 231, 89, 255, 120, 158, 63, 52, 121, 166, 99, 117, 190, 230, 201, 43, 72, 10, 223, 46, 218, 51, 181, 56, 49, 248, 33, 27, 61, 120, 250, 144, 151, 181, 132, 246, 223, 173, 252, 16, 199, 193, 98, 55, 23, 98, 226, 142, 216, 5, 147, 110, 145, 106, 117, 27, 74, 193, 164, 79, 175, 28, 71, 73, 11, 177, 140, 194, 87, 102, 205, 160, 235, 57, 10, 141, 226, 81, 85, 246, 214, 174, 68, 168, 155, 79, 145, 63, 2, 131, 58, 106, 184, 29, 160, 17, 104, 208, 200, 13 } });

            migrationBuilder.CreateIndex(
                name: "IX_MileageRecords_UserCarId",
                table: "MileageRecords",
                column: "UserCarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MileageRecords");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 101, 37, 233, 37, 59, 86, 190, 139, 60, 55, 139, 168, 160, 113, 166, 54, 190, 169, 80, 63, 65, 112, 236, 15, 184, 33, 136, 35, 231, 183, 67, 199, 70, 139, 69, 232, 162, 128, 31, 33, 146, 63, 73, 184, 154, 109, 143, 72, 141, 25, 205, 147, 196, 155, 49, 253, 89, 196, 217, 231, 68, 107, 167, 171 }, new byte[] { 60, 133, 164, 126, 136, 90, 184, 77, 182, 34, 66, 234, 93, 221, 170, 195, 100, 163, 13, 250, 209, 14, 168, 82, 53, 27, 213, 129, 176, 173, 87, 138, 124, 130, 78, 23, 179, 160, 224, 164, 231, 95, 46, 127, 40, 162, 102, 23, 206, 64, 33, 42, 219, 142, 20, 205, 243, 227, 12, 255, 179, 96, 130, 200, 198, 122, 144, 149, 218, 134, 209, 93, 220, 217, 11, 71, 169, 239, 65, 167, 67, 255, 235, 202, 166, 21, 13, 146, 170, 192, 198, 244, 1, 24, 178, 156, 64, 32, 66, 72, 88, 211, 239, 110, 139, 179, 97, 62, 202, 54, 57, 64, 151, 246, 145, 204, 248, 142, 204, 130, 216, 133, 29, 156, 120, 183, 63, 216 } });
        }
    }
}
