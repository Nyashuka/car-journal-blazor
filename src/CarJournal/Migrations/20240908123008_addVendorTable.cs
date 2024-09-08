using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarJournal.Migrations
{
    /// <inheritdoc />
    public partial class addVendorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 222, 123, 90, 92, 5, 60, 38, 5, 22, 252, 251, 49, 75, 2, 201, 222, 157, 194, 94, 121, 112, 170, 87, 234, 163, 218, 79, 33, 153, 85, 107, 177, 192, 236, 242, 154, 54, 209, 208, 247, 198, 166, 140, 15, 167, 15, 5, 235, 142, 208, 172, 228, 159, 107, 161, 166, 211, 34, 245, 77, 36, 147, 162, 120 }, new byte[] { 122, 19, 74, 63, 196, 181, 182, 254, 34, 121, 216, 218, 14, 63, 127, 183, 103, 59, 44, 251, 3, 69, 232, 40, 154, 250, 80, 147, 169, 249, 113, 235, 70, 160, 97, 107, 164, 50, 148, 74, 37, 168, 177, 251, 27, 66, 112, 242, 114, 75, 241, 177, 131, 221, 254, 175, 70, 209, 8, 38, 154, 135, 1, 103, 62, 11, 139, 246, 122, 174, 3, 114, 249, 45, 11, 141, 52, 173, 73, 37, 21, 29, 222, 232, 208, 73, 73, 62, 11, 229, 68, 40, 22, 254, 51, 50, 188, 187, 104, 2, 132, 41, 165, 155, 152, 47, 141, 83, 18, 175, 7, 182, 233, 121, 149, 89, 223, 125, 246, 155, 59, 77, 140, 190, 109, 93, 122, 214 } });

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_Name",
                table: "Vendors",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 73, 82, 176, 52, 102, 98, 89, 32, 213, 89, 54, 94, 46, 141, 30, 155, 251, 112, 149, 43, 2, 130, 118, 12, 240, 30, 238, 102, 0, 67, 102, 203, 162, 71, 49, 3, 36, 184, 167, 200, 139, 49, 8, 81, 158, 133, 78, 227, 69, 201, 9, 33, 64, 29, 250, 104, 99, 24, 199, 19, 99, 175, 254, 207 }, new byte[] { 202, 71, 228, 233, 45, 146, 18, 52, 90, 217, 195, 69, 119, 42, 22, 201, 177, 131, 204, 21, 35, 30, 65, 183, 130, 3, 116, 187, 127, 85, 247, 229, 211, 213, 180, 8, 89, 16, 49, 33, 241, 149, 84, 182, 204, 132, 204, 4, 86, 84, 134, 127, 17, 159, 182, 145, 26, 119, 245, 1, 125, 91, 87, 6, 223, 117, 117, 54, 192, 204, 229, 141, 98, 18, 67, 218, 128, 77, 149, 7, 223, 101, 18, 108, 42, 6, 243, 212, 161, 110, 134, 242, 83, 218, 84, 42, 194, 155, 74, 48, 231, 219, 223, 207, 127, 244, 55, 25, 2, 254, 253, 57, 18, 157, 235, 101, 38, 113, 206, 220, 113, 218, 234, 7, 123, 220, 33, 34 } });
        }
    }
}
