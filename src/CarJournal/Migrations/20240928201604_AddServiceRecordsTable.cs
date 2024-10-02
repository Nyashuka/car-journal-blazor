using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarJournal.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceRecordsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ServiceCategoryId = table.Column<int>(type: "integer", nullable: false),
                    UserCarId = table.Column<int>(type: "integer", nullable: false),
                    Mileage = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DateOfService = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRecords_ServiceCategories_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRecords_UserCars_UserCarId",
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
                values: new object[] { new byte[] { 25, 10, 92, 173, 181, 4, 173, 201, 233, 112, 64, 130, 60, 13, 226, 27, 78, 94, 126, 206, 142, 36, 241, 223, 240, 132, 50, 16, 159, 100, 19, 126, 225, 45, 112, 6, 204, 50, 50, 170, 96, 101, 216, 155, 28, 33, 177, 208, 114, 174, 217, 197, 253, 152, 206, 152, 177, 127, 105, 180, 120, 77, 113, 208 }, new byte[] { 139, 252, 77, 198, 10, 186, 58, 124, 146, 250, 156, 225, 217, 160, 250, 97, 34, 181, 202, 156, 250, 144, 207, 116, 147, 214, 2, 39, 104, 57, 130, 161, 197, 239, 107, 69, 244, 186, 182, 136, 192, 110, 56, 12, 78, 20, 39, 13, 115, 26, 184, 110, 241, 173, 19, 228, 179, 120, 122, 40, 188, 196, 155, 163, 17, 96, 69, 229, 104, 90, 72, 224, 47, 123, 178, 206, 55, 253, 107, 238, 140, 200, 86, 254, 173, 35, 130, 78, 165, 225, 3, 166, 233, 160, 5, 189, 173, 99, 199, 201, 128, 90, 29, 179, 78, 62, 70, 56, 48, 82, 250, 51, 74, 75, 190, 130, 13, 136, 203, 133, 150, 96, 70, 201, 57, 95, 225, 169 } });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRecords_ServiceCategoryId",
                table: "ServiceRecords",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRecords_UserCarId",
                table: "ServiceRecords",
                column: "UserCarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceRecords");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 115, 72, 158, 189, 8, 183, 122, 205, 47, 72, 62, 189, 61, 224, 182, 17, 79, 164, 64, 66, 155, 98, 144, 32, 13, 191, 18, 190, 235, 53, 183, 142, 133, 255, 134, 236, 236, 36, 102, 202, 157, 119, 75, 103, 17, 210, 59, 123, 39, 68, 209, 78, 91, 6, 10, 105, 236, 88, 223, 214, 178, 34, 42, 143 }, new byte[] { 13, 171, 121, 162, 205, 125, 242, 56, 48, 69, 212, 31, 53, 198, 191, 44, 8, 54, 164, 243, 237, 255, 147, 103, 150, 33, 195, 237, 153, 110, 136, 176, 50, 53, 219, 164, 126, 82, 65, 223, 174, 122, 85, 165, 217, 148, 82, 105, 137, 59, 150, 174, 5, 128, 239, 141, 137, 77, 126, 2, 217, 180, 133, 237, 34, 250, 57, 184, 42, 205, 10, 235, 195, 55, 21, 89, 13, 103, 63, 99, 170, 151, 54, 219, 160, 42, 50, 78, 241, 42, 34, 72, 254, 161, 95, 94, 0, 91, 166, 220, 17, 162, 160, 106, 229, 96, 205, 246, 72, 56, 138, 187, 46, 221, 64, 218, 126, 224, 139, 44, 162, 187, 186, 185, 36, 198, 32, 142 } });
        }
    }
}
