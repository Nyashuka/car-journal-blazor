using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarJournal.Migrations
{
    /// <inheritdoc />
    public partial class addTrackingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AverageMileage",
                table: "UserCars",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Trackings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MessageForReminder = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    UserCarId = table.Column<int>(type: "integer", nullable: false),
                    TrackingType = table.Column<int>(type: "integer", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MileageAtStart = table.Column<int>(type: "integer", nullable: true),
                    TotalMileage = table.Column<int>(type: "integer", nullable: true),
                    LimitMileage = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trackings_UserCars_UserCarId",
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
                values: new object[] { new byte[] { 238, 223, 148, 71, 13, 120, 170, 245, 31, 156, 9, 45, 71, 39, 57, 255, 59, 243, 236, 240, 45, 65, 142, 20, 227, 79, 58, 56, 54, 40, 10, 107, 166, 196, 232, 204, 139, 65, 64, 133, 148, 183, 178, 174, 117, 237, 115, 201, 216, 135, 199, 132, 122, 116, 38, 60, 40, 44, 128, 139, 29, 200, 83, 20 }, new byte[] { 65, 129, 205, 114, 9, 116, 53, 122, 231, 46, 38, 22, 242, 249, 63, 221, 42, 217, 173, 187, 245, 231, 222, 69, 121, 85, 187, 230, 136, 0, 149, 112, 93, 235, 223, 144, 202, 197, 88, 110, 198, 229, 99, 110, 110, 13, 64, 8, 49, 179, 154, 186, 64, 88, 174, 136, 148, 112, 116, 205, 202, 54, 107, 219, 233, 23, 104, 223, 197, 235, 77, 19, 253, 21, 232, 14, 48, 41, 11, 109, 155, 105, 172, 127, 141, 24, 170, 7, 193, 189, 190, 179, 190, 109, 183, 139, 134, 234, 231, 42, 210, 5, 225, 68, 196, 201, 171, 146, 223, 38, 210, 66, 61, 157, 115, 49, 34, 81, 121, 118, 245, 158, 161, 36, 227, 96, 97, 215 } });

            migrationBuilder.CreateIndex(
                name: "IX_Trackings_UserCarId",
                table: "Trackings",
                column: "UserCarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trackings");

            migrationBuilder.DropColumn(
                name: "AverageMileage",
                table: "UserCars");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 25, 10, 92, 173, 181, 4, 173, 201, 233, 112, 64, 130, 60, 13, 226, 27, 78, 94, 126, 206, 142, 36, 241, 223, 240, 132, 50, 16, 159, 100, 19, 126, 225, 45, 112, 6, 204, 50, 50, 170, 96, 101, 216, 155, 28, 33, 177, 208, 114, 174, 217, 197, 253, 152, 206, 152, 177, 127, 105, 180, 120, 77, 113, 208 }, new byte[] { 139, 252, 77, 198, 10, 186, 58, 124, 146, 250, 156, 225, 217, 160, 250, 97, 34, 181, 202, 156, 250, 144, 207, 116, 147, 214, 2, 39, 104, 57, 130, 161, 197, 239, 107, 69, 244, 186, 182, 136, 192, 110, 56, 12, 78, 20, 39, 13, 115, 26, 184, 110, 241, 173, 19, 228, 179, 120, 122, 40, 188, 196, 155, 163, 17, 96, 69, 229, 104, 90, 72, 224, 47, 123, 178, 206, 55, 253, 107, 238, 140, 200, 86, 254, 173, 35, 130, 78, 165, 225, 3, 166, 233, 160, 5, 189, 173, 99, 199, 201, 128, 90, 29, 179, 78, 62, 70, 56, 48, 82, 250, 51, 74, 75, 190, 130, 13, 136, 203, 133, 150, 96, 70, 201, 57, 95, 225, 169 } });
        }
    }
}
