using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarJournal.Migrations
{
    /// <inheritdoc />
    public partial class addFuelTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 15, 18, 165, 109, 120, 131, 99, 224, 0, 195, 230, 138, 49, 157, 220, 240, 218, 19, 223, 211, 121, 153, 112, 165, 130, 97, 80, 62, 164, 97, 138, 245, 55, 33, 251, 200, 243, 85, 96, 31, 57, 250, 57, 237, 21, 63, 105, 50, 176, 133, 15, 100, 99, 243, 181, 23, 240, 243, 61, 45, 176, 199, 166, 149 }, new byte[] { 83, 0, 17, 78, 43, 49, 142, 71, 179, 108, 52, 126, 81, 14, 130, 40, 57, 184, 166, 15, 182, 144, 162, 6, 29, 245, 93, 155, 244, 80, 121, 74, 27, 20, 142, 138, 63, 23, 77, 160, 105, 91, 190, 95, 44, 118, 3, 22, 43, 47, 119, 148, 51, 115, 53, 141, 1, 178, 28, 6, 134, 185, 89, 79, 143, 175, 212, 142, 210, 122, 65, 110, 164, 192, 17, 162, 98, 131, 192, 238, 90, 203, 241, 114, 202, 181, 250, 95, 44, 12, 86, 215, 199, 194, 161, 63, 236, 149, 90, 36, 198, 64, 1, 179, 64, 210, 113, 34, 177, 0, 1, 90, 230, 235, 83, 204, 210, 14, 137, 69, 158, 215, 43, 141, 197, 228, 164, 206 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelTypes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 33, 79, 145, 19, 239, 194, 7, 81, 68, 46, 244, 199, 81, 2, 20, 11, 146, 183, 35, 124, 103, 26, 193, 88, 26, 199, 2, 232, 45, 190, 245, 248, 159, 71, 109, 211, 207, 245, 82, 90, 72, 251, 219, 118, 252, 145, 68, 4, 230, 28, 44, 101, 161, 81, 201, 184, 8, 201, 118, 105, 226, 27, 211, 142 }, new byte[] { 169, 220, 169, 182, 197, 241, 251, 42, 131, 211, 214, 140, 109, 155, 85, 90, 126, 123, 199, 135, 126, 63, 108, 240, 18, 189, 211, 225, 234, 30, 83, 182, 98, 211, 254, 95, 239, 168, 7, 6, 23, 95, 129, 252, 49, 14, 56, 31, 157, 182, 69, 146, 11, 127, 133, 133, 185, 176, 80, 75, 197, 206, 135, 100, 223, 113, 173, 240, 164, 36, 153, 184, 195, 99, 2, 197, 145, 229, 216, 206, 119, 179, 205, 191, 77, 110, 18, 55, 15, 205, 66, 228, 19, 231, 38, 10, 21, 26, 130, 240, 27, 41, 120, 157, 35, 90, 137, 245, 75, 35, 61, 48, 120, 175, 231, 188, 51, 65, 249, 70, 119, 141, 57, 194, 206, 121, 124, 105 } });
        }
    }
}
