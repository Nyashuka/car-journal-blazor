using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarJournal.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentationURLFieldInCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentationUrl",
                table: "Cars",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 49, 194, 62, 54, 255, 66, 52, 172, 130, 141, 8, 125, 211, 2, 224, 61, 87, 130, 236, 51, 220, 187, 125, 65, 191, 5, 43, 167, 105, 255, 138, 34, 99, 172, 37, 209, 15, 99, 144, 216, 144, 127, 21, 71, 223, 185, 84, 17, 187, 147, 42, 213, 96, 114, 35, 206, 174, 231, 33, 173, 142, 50, 48, 86 }, new byte[] { 49, 38, 92, 120, 121, 60, 216, 152, 204, 196, 156, 91, 235, 78, 203, 234, 111, 1, 131, 111, 168, 132, 71, 135, 199, 66, 118, 87, 5, 207, 69, 186, 252, 127, 36, 70, 81, 236, 252, 151, 9, 214, 169, 196, 2, 12, 86, 217, 213, 142, 178, 94, 113, 61, 163, 4, 161, 220, 68, 58, 79, 18, 232, 132, 72, 154, 8, 133, 212, 222, 204, 40, 184, 56, 65, 242, 183, 23, 67, 249, 139, 15, 23, 11, 111, 245, 47, 48, 68, 9, 34, 144, 32, 177, 98, 177, 23, 174, 250, 7, 49, 196, 225, 22, 44, 102, 94, 84, 49, 204, 88, 97, 111, 103, 244, 163, 234, 58, 223, 103, 192, 163, 236, 170, 209, 80, 9, 141 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentationUrl",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 207, 30, 148, 127, 214, 231, 181, 106, 213, 231, 6, 142, 232, 174, 190, 178, 98, 190, 154, 246, 48, 225, 43, 204, 6, 221, 42, 148, 93, 141, 209, 138, 158, 249, 189, 180, 100, 190, 233, 199, 226, 168, 231, 61, 236, 122, 90, 131, 114, 32, 143, 112, 99, 81, 49, 189, 78, 99, 54, 214, 204, 103, 16, 223 }, new byte[] { 225, 6, 95, 11, 205, 153, 33, 105, 89, 90, 167, 233, 213, 192, 182, 200, 8, 183, 34, 106, 248, 33, 13, 168, 26, 17, 47, 3, 250, 121, 156, 164, 102, 148, 7, 118, 16, 52, 244, 177, 226, 78, 15, 68, 52, 47, 184, 218, 229, 96, 164, 63, 28, 162, 116, 108, 57, 62, 81, 67, 219, 56, 93, 133, 85, 83, 239, 84, 153, 152, 138, 31, 198, 103, 172, 13, 189, 89, 215, 204, 150, 203, 100, 134, 210, 1, 252, 251, 2, 235, 170, 27, 61, 227, 135, 76, 130, 139, 100, 110, 50, 218, 167, 245, 241, 248, 245, 46, 246, 123, 166, 244, 180, 255, 88, 44, 2, 51, 228, 169, 52, 191, 15, 82, 47, 250, 164, 17 } });
        }
    }
}
