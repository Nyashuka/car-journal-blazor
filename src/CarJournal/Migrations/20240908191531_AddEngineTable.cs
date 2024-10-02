using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarJournal.Migrations
{
    /// <inheritdoc />
    public partial class AddEngineTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Model = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    EngineSize = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 29, 20, 126, 6, 54, 150, 40, 162, 230, 119, 2, 222, 172, 130, 203, 64, 146, 189, 192, 87, 61, 192, 3, 87, 9, 169, 87, 209, 173, 254, 104, 151, 190, 241, 109, 160, 227, 93, 234, 12, 94, 62, 223, 207, 65, 211, 118, 219, 119, 64, 122, 26, 201, 98, 70, 224, 237, 107, 11, 103, 198, 76, 46, 27 }, new byte[] { 229, 102, 123, 90, 125, 33, 138, 253, 141, 124, 88, 210, 87, 246, 241, 201, 113, 63, 166, 179, 154, 249, 12, 25, 100, 110, 132, 162, 240, 8, 67, 238, 54, 225, 196, 2, 121, 255, 68, 71, 220, 166, 166, 215, 158, 221, 231, 83, 29, 66, 243, 224, 177, 26, 205, 179, 74, 197, 57, 223, 183, 90, 251, 55, 70, 213, 165, 153, 145, 37, 175, 255, 20, 137, 194, 156, 116, 204, 85, 202, 150, 248, 109, 193, 49, 18, 134, 184, 41, 155, 49, 122, 67, 96, 242, 18, 93, 40, 252, 92, 2, 191, 101, 203, 189, 155, 193, 96, 202, 63, 76, 22, 126, 204, 19, 24, 201, 83, 187, 44, 11, 55, 57, 214, 23, 180, 129, 72 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 111, 79, 158, 218, 32, 200, 57, 7, 243, 37, 123, 211, 241, 171, 70, 124, 129, 76, 97, 73, 137, 92, 123, 32, 201, 121, 125, 85, 135, 124, 9, 164, 156, 38, 192, 58, 195, 143, 213, 24, 242, 0, 224, 167, 152, 176, 127, 83, 210, 44, 91, 141, 204, 39, 103, 104, 36, 250, 21, 145, 228, 247, 91, 201 }, new byte[] { 11, 82, 28, 26, 36, 93, 245, 180, 250, 126, 201, 150, 160, 7, 124, 173, 163, 103, 224, 49, 110, 172, 218, 170, 110, 111, 237, 223, 45, 94, 102, 119, 120, 252, 8, 68, 43, 66, 0, 255, 169, 223, 247, 217, 7, 230, 254, 44, 241, 248, 193, 22, 17, 239, 216, 74, 172, 26, 185, 155, 38, 134, 93, 133, 23, 208, 109, 238, 102, 140, 240, 187, 4, 98, 226, 42, 167, 143, 40, 137, 149, 44, 113, 203, 194, 83, 242, 3, 48, 32, 85, 69, 12, 183, 61, 145, 69, 1, 53, 242, 125, 212, 2, 121, 237, 174, 77, 91, 125, 120, 254, 150, 172, 69, 223, 240, 69, 49, 203, 225, 146, 228, 198, 215, 215, 233, 188, 78 } });
        }
    }
}
