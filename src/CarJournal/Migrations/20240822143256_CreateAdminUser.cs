using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarJournal.Migrations
{
    /// <inheritdoc />
    public partial class CreateAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "RoleId" },
                values: new object[] { -1, "admin", new byte[] { 73, 82, 176, 52, 102, 98, 89, 32, 213, 89, 54, 94, 46, 141, 30, 155, 251, 112, 149, 43, 2, 130, 118, 12, 240, 30, 238, 102, 0, 67, 102, 203, 162, 71, 49, 3, 36, 184, 167, 200, 139, 49, 8, 81, 158, 133, 78, 227, 69, 201, 9, 33, 64, 29, 250, 104, 99, 24, 199, 19, 99, 175, 254, 207 }, new byte[] { 202, 71, 228, 233, 45, 146, 18, 52, 90, 217, 195, 69, 119, 42, 22, 201, 177, 131, 204, 21, 35, 30, 65, 183, 130, 3, 116, 187, 127, 85, 247, 229, 211, 213, 180, 8, 89, 16, 49, 33, 241, 149, 84, 182, 204, 132, 204, 4, 86, 84, 134, 127, 17, 159, 182, 145, 26, 119, 245, 1, 125, 91, 87, 6, 223, 117, 117, 54, 192, 204, 229, 141, 98, 18, 67, 218, 128, 77, 149, 7, 223, 101, 18, 108, 42, 6, 243, 212, 161, 110, 134, 242, 83, 218, 84, 42, 194, 155, 74, 48, 231, 219, 223, 207, 127, 244, 55, 25, 2, 254, 253, 57, 18, 157, 235, 101, 38, 113, 206, 220, 113, 218, 234, 7, 123, 220, 33, 34 }, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
