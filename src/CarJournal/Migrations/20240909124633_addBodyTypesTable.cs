using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarJournal.Migrations
{
    /// <inheritdoc />
    public partial class addBodyTypesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyTypes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 203, 211, 46, 85, 131, 238, 94, 193, 48, 3, 62, 67, 134, 137, 130, 137, 220, 147, 183, 3, 165, 218, 204, 136, 65, 94, 222, 104, 238, 132, 154, 178, 13, 98, 194, 75, 244, 13, 230, 123, 57, 127, 13, 184, 165, 85, 152, 159, 181, 181, 89, 59, 61, 79, 236, 79, 127, 214, 83, 48, 206, 77, 81, 206 }, new byte[] { 208, 125, 27, 87, 138, 202, 178, 15, 230, 202, 77, 191, 6, 116, 20, 89, 125, 59, 75, 104, 143, 119, 39, 141, 87, 215, 207, 184, 84, 21, 198, 33, 55, 109, 196, 42, 21, 217, 152, 128, 60, 72, 81, 233, 79, 167, 223, 252, 103, 23, 123, 26, 218, 55, 143, 52, 18, 214, 40, 223, 69, 63, 38, 192, 141, 214, 201, 225, 91, 116, 152, 184, 133, 101, 45, 52, 114, 152, 225, 125, 202, 235, 75, 244, 198, 236, 66, 176, 43, 74, 83, 74, 82, 92, 175, 221, 129, 81, 56, 235, 45, 156, 200, 208, 239, 210, 172, 230, 243, 12, 101, 51, 153, 190, 76, 241, 84, 3, 60, 95, 59, 171, 199, 113, 150, 48, 106, 162 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyTypes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 15, 18, 165, 109, 120, 131, 99, 224, 0, 195, 230, 138, 49, 157, 220, 240, 218, 19, 223, 211, 121, 153, 112, 165, 130, 97, 80, 62, 164, 97, 138, 245, 55, 33, 251, 200, 243, 85, 96, 31, 57, 250, 57, 237, 21, 63, 105, 50, 176, 133, 15, 100, 99, 243, 181, 23, 240, 243, 61, 45, 176, 199, 166, 149 }, new byte[] { 83, 0, 17, 78, 43, 49, 142, 71, 179, 108, 52, 126, 81, 14, 130, 40, 57, 184, 166, 15, 182, 144, 162, 6, 29, 245, 93, 155, 244, 80, 121, 74, 27, 20, 142, 138, 63, 23, 77, 160, 105, 91, 190, 95, 44, 118, 3, 22, 43, 47, 119, 148, 51, 115, 53, 141, 1, 178, 28, 6, 134, 185, 89, 79, 143, 175, 212, 142, 210, 122, 65, 110, 164, 192, 17, 162, 98, 131, 192, 238, 90, 203, 241, 114, 202, 181, 250, 95, 44, 12, 86, 215, 199, 194, 161, 63, 236, 149, 90, 36, 198, 64, 1, 179, 64, 210, 113, 34, 177, 0, 1, 90, 230, 235, 83, 204, 210, 14, 137, 69, 158, 215, 43, 141, 197, 228, 164, 206 } });
        }
    }
}
