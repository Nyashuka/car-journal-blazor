using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarJournal.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 115, 72, 158, 189, 8, 183, 122, 205, 47, 72, 62, 189, 61, 224, 182, 17, 79, 164, 64, 66, 155, 98, 144, 32, 13, 191, 18, 190, 235, 53, 183, 142, 133, 255, 134, 236, 236, 36, 102, 202, 157, 119, 75, 103, 17, 210, 59, 123, 39, 68, 209, 78, 91, 6, 10, 105, 236, 88, 223, 214, 178, 34, 42, 143 }, new byte[] { 13, 171, 121, 162, 205, 125, 242, 56, 48, 69, 212, 31, 53, 198, 191, 44, 8, 54, 164, 243, 237, 255, 147, 103, 150, 33, 195, 237, 153, 110, 136, 176, 50, 53, 219, 164, 126, 82, 65, 223, 174, 122, 85, 165, 217, 148, 82, 105, 137, 59, 150, 174, 5, 128, 239, 141, 137, 77, 126, 2, 217, 180, 133, 237, 34, 250, 57, 184, 42, 205, 10, 235, 195, 55, 21, 89, 13, 103, 63, 99, 170, 151, 54, 219, 160, 42, 50, 78, 241, 42, 34, 72, 254, 161, 95, 94, 0, 91, 166, 220, 17, 162, 160, 106, 229, 96, 205, 246, 72, 56, 138, 187, 46, 221, 64, 218, 126, 224, 139, 44, 162, 187, 186, 185, 36, 198, 32, 142 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceCategories");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 182, 84, 109, 205, 72, 58, 89, 19, 54, 164, 37, 44, 57, 155, 57, 145, 66, 114, 127, 31, 14, 105, 192, 202, 203, 168, 119, 174, 99, 60, 70, 119, 93, 100, 239, 114, 136, 169, 79, 225, 102, 4, 174, 118, 107, 69, 44, 74, 129, 47, 221, 38, 66, 151, 244, 171, 190, 1, 241, 151, 179, 187, 79, 52 }, new byte[] { 231, 249, 0, 201, 254, 38, 189, 203, 21, 164, 153, 43, 223, 50, 44, 116, 199, 254, 174, 206, 78, 229, 95, 95, 43, 88, 251, 182, 31, 231, 89, 255, 120, 158, 63, 52, 121, 166, 99, 117, 190, 230, 201, 43, 72, 10, 223, 46, 218, 51, 181, 56, 49, 248, 33, 27, 61, 120, 250, 144, 151, 181, 132, 246, 223, 173, 252, 16, 199, 193, 98, 55, 23, 98, 226, 142, 216, 5, 147, 110, 145, 106, 117, 27, 74, 193, 164, 79, 175, 28, 71, 73, 11, 177, 140, 194, 87, 102, 205, 160, 235, 57, 10, 141, 226, 81, 85, 246, 214, 174, 68, 168, 155, 79, 145, 63, 2, 131, 58, 106, 184, 29, 160, 17, 104, 208, 200, 13 } });
        }
    }
}
