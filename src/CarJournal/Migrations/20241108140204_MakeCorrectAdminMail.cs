﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarJournal.Migrations
{
    /// <inheritdoc />
    public partial class MakeCorrectAdminMail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 0, 24, 240, 172, 6, 229, 229, 157, 188, 59, 216, 0, 94, 65, 121, 73, 18, 89, 161, 167, 15, 230, 44, 79, 174, 133, 251, 249, 255, 174, 91, 199, 243, 204, 157, 26, 196, 131, 166, 35, 247, 116, 31, 169, 109, 200, 97, 41, 38, 53, 127, 149, 236, 175, 198, 246, 97, 186, 94, 200, 46, 71, 44, 216 }, new byte[] { 5, 243, 229, 181, 245, 214, 205, 218, 114, 242, 183, 141, 185, 228, 70, 81, 158, 72, 209, 226, 72, 212, 0, 165, 81, 230, 186, 79, 252, 118, 109, 68, 160, 107, 82, 100, 187, 178, 234, 11, 9, 1, 171, 65, 30, 81, 186, 183, 221, 20, 200, 142, 99, 179, 62, 158, 25, 228, 119, 7, 80, 143, 75, 156, 176, 115, 14, 237, 227, 147, 120, 57, 57, 76, 168, 195, 34, 26, 90, 104, 146, 126, 114, 45, 28, 202, 208, 194, 132, 109, 64, 120, 230, 83, 171, 105, 8, 185, 25, 73, 220, 8, 222, 198, 86, 67, 69, 47, 130, 169, 147, 178, 26, 128, 27, 90, 191, 198, 199, 4, 100, 65, 111, 237, 198, 220, 9, 46 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 49, 194, 62, 54, 255, 66, 52, 172, 130, 141, 8, 125, 211, 2, 224, 61, 87, 130, 236, 51, 220, 187, 125, 65, 191, 5, 43, 167, 105, 255, 138, 34, 99, 172, 37, 209, 15, 99, 144, 216, 144, 127, 21, 71, 223, 185, 84, 17, 187, 147, 42, 213, 96, 114, 35, 206, 174, 231, 33, 173, 142, 50, 48, 86 }, new byte[] { 49, 38, 92, 120, 121, 60, 216, 152, 204, 196, 156, 91, 235, 78, 203, 234, 111, 1, 131, 111, 168, 132, 71, 135, 199, 66, 118, 87, 5, 207, 69, 186, 252, 127, 36, 70, 81, 236, 252, 151, 9, 214, 169, 196, 2, 12, 86, 217, 213, 142, 178, 94, 113, 61, 163, 4, 161, 220, 68, 58, 79, 18, 232, 132, 72, 154, 8, 133, 212, 222, 204, 40, 184, 56, 65, 242, 183, 23, 67, 249, 139, 15, 23, 11, 111, 245, 47, 48, 68, 9, 34, 144, 32, 177, 98, 177, 23, 174, 250, 7, 49, 196, 225, 22, 44, 102, 94, 84, 49, 204, 88, 97, 111, 103, 244, 163, 234, 58, 223, 103, 192, 163, 236, 170, 209, 80, 9, 141 } });
        }
    }
}
