using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarJournal.Migrations
{
    /// <inheritdoc />
    public partial class addGearboxesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gearboxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gearboxes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 33, 79, 145, 19, 239, 194, 7, 81, 68, 46, 244, 199, 81, 2, 20, 11, 146, 183, 35, 124, 103, 26, 193, 88, 26, 199, 2, 232, 45, 190, 245, 248, 159, 71, 109, 211, 207, 245, 82, 90, 72, 251, 219, 118, 252, 145, 68, 4, 230, 28, 44, 101, 161, 81, 201, 184, 8, 201, 118, 105, 226, 27, 211, 142 }, new byte[] { 169, 220, 169, 182, 197, 241, 251, 42, 131, 211, 214, 140, 109, 155, 85, 90, 126, 123, 199, 135, 126, 63, 108, 240, 18, 189, 211, 225, 234, 30, 83, 182, 98, 211, 254, 95, 239, 168, 7, 6, 23, 95, 129, 252, 49, 14, 56, 31, 157, 182, 69, 146, 11, 127, 133, 133, 185, 176, 80, 75, 197, 206, 135, 100, 223, 113, 173, 240, 164, 36, 153, 184, 195, 99, 2, 197, 145, 229, 216, 206, 119, 179, 205, 191, 77, 110, 18, 55, 15, 205, 66, 228, 19, 231, 38, 10, 21, 26, 130, 240, 27, 41, 120, 157, 35, 90, 137, 245, 75, 35, 61, 48, 120, 175, 231, 188, 51, 65, 249, 70, 119, 141, 57, 194, 206, 121, 124, 105 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gearboxes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 29, 20, 126, 6, 54, 150, 40, 162, 230, 119, 2, 222, 172, 130, 203, 64, 146, 189, 192, 87, 61, 192, 3, 87, 9, 169, 87, 209, 173, 254, 104, 151, 190, 241, 109, 160, 227, 93, 234, 12, 94, 62, 223, 207, 65, 211, 118, 219, 119, 64, 122, 26, 201, 98, 70, 224, 237, 107, 11, 103, 198, 76, 46, 27 }, new byte[] { 229, 102, 123, 90, 125, 33, 138, 253, 141, 124, 88, 210, 87, 246, 241, 201, 113, 63, 166, 179, 154, 249, 12, 25, 100, 110, 132, 162, 240, 8, 67, 238, 54, 225, 196, 2, 121, 255, 68, 71, 220, 166, 166, 215, 158, 221, 231, 83, 29, 66, 243, 224, 177, 26, 205, 179, 74, 197, 57, 223, 183, 90, 251, 55, 70, 213, 165, 153, 145, 37, 175, 255, 20, 137, 194, 156, 116, 204, 85, 202, 150, 248, 109, 193, 49, 18, 134, 184, 41, 155, 49, 122, 67, 96, 242, 18, 93, 40, 252, 92, 2, 191, 101, 203, 189, 155, 193, 96, 202, 63, 76, 22, 126, 204, 19, 24, 201, 83, 187, 44, 11, 55, 57, 214, 23, 180, 129, 72 } });
        }
    }
}
