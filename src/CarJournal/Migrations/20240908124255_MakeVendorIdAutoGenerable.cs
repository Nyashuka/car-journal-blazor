using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarJournal.Migrations
{
    /// <inheritdoc />
    public partial class MakeVendorIdAutoGenerable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Vendors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 111, 79, 158, 218, 32, 200, 57, 7, 243, 37, 123, 211, 241, 171, 70, 124, 129, 76, 97, 73, 137, 92, 123, 32, 201, 121, 125, 85, 135, 124, 9, 164, 156, 38, 192, 58, 195, 143, 213, 24, 242, 0, 224, 167, 152, 176, 127, 83, 210, 44, 91, 141, 204, 39, 103, 104, 36, 250, 21, 145, 228, 247, 91, 201 }, new byte[] { 11, 82, 28, 26, 36, 93, 245, 180, 250, 126, 201, 150, 160, 7, 124, 173, 163, 103, 224, 49, 110, 172, 218, 170, 110, 111, 237, 223, 45, 94, 102, 119, 120, 252, 8, 68, 43, 66, 0, 255, 169, 223, 247, 217, 7, 230, 254, 44, 241, 248, 193, 22, 17, 239, 216, 74, 172, 26, 185, 155, 38, 134, 93, 133, 23, 208, 109, 238, 102, 140, 240, 187, 4, 98, 226, 42, 167, 143, 40, 137, 149, 44, 113, 203, 194, 83, 242, 3, 48, 32, 85, 69, 12, 183, 61, 145, 69, 1, 53, 242, 125, 212, 2, 121, 237, 174, 77, 91, 125, 120, 254, 150, 172, 69, 223, 240, 69, 49, 203, 225, 146, 228, 198, 215, 215, 233, 188, 78 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Vendors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 222, 123, 90, 92, 5, 60, 38, 5, 22, 252, 251, 49, 75, 2, 201, 222, 157, 194, 94, 121, 112, 170, 87, 234, 163, 218, 79, 33, 153, 85, 107, 177, 192, 236, 242, 154, 54, 209, 208, 247, 198, 166, 140, 15, 167, 15, 5, 235, 142, 208, 172, 228, 159, 107, 161, 166, 211, 34, 245, 77, 36, 147, 162, 120 }, new byte[] { 122, 19, 74, 63, 196, 181, 182, 254, 34, 121, 216, 218, 14, 63, 127, 183, 103, 59, 44, 251, 3, 69, 232, 40, 154, 250, 80, 147, 169, 249, 113, 235, 70, 160, 97, 107, 164, 50, 148, 74, 37, 168, 177, 251, 27, 66, 112, 242, 114, 75, 241, 177, 131, 221, 254, 175, 70, 209, 8, 38, 154, 135, 1, 103, 62, 11, 139, 246, 122, 174, 3, 114, 249, 45, 11, 141, 52, 173, 73, 37, 21, 29, 222, 232, 208, 73, 73, 62, 11, 229, 68, 40, 22, 254, 51, 50, 188, 187, 104, 2, 132, 41, 165, 155, 152, 47, 141, 83, 18, 175, 7, 182, 233, 121, 149, 89, 223, 125, 246, 155, 59, 77, 140, 190, 109, 93, 122, 214 } });
        }
    }
}
