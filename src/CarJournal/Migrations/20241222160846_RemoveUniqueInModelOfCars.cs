﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarJournal.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUniqueInModelOfCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cars_Model",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 197, 45, 113, 203, 212, 62, 174, 45, 229, 53, 201, 229, 214, 106, 114, 0, 2, 36, 198, 125, 50, 217, 212, 246, 252, 102, 71, 165, 76, 214, 44, 207, 254, 55, 25, 216, 162, 62, 106, 70, 120, 118, 25, 99, 221, 67, 225, 190, 9, 65, 156, 122, 83, 89, 241, 200, 50, 59, 225, 122, 70, 244, 142, 157 }, new byte[] { 135, 131, 221, 188, 179, 218, 153, 129, 158, 50, 9, 135, 186, 107, 212, 234, 230, 39, 239, 4, 109, 7, 21, 59, 7, 45, 22, 85, 187, 105, 243, 70, 230, 202, 217, 105, 105, 7, 53, 40, 44, 45, 63, 154, 84, 252, 244, 136, 3, 20, 212, 35, 167, 242, 133, 179, 207, 227, 189, 146, 5, 182, 104, 137, 88, 177, 68, 153, 68, 117, 167, 98, 169, 134, 94, 76, 176, 230, 0, 186, 92, 114, 73, 57, 42, 75, 95, 58, 39, 39, 31, 3, 41, 205, 170, 161, 120, 143, 230, 144, 91, 172, 10, 62, 75, 161, 43, 186, 192, 183, 188, 55, 15, 89, 59, 116, 199, 251, 146, 85, 191, 136, 118, 151, 77, 88, 183, 26 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 80, 94, 11, 64, 67, 41, 46, 7, 54, 74, 214, 243, 29, 91, 26, 105, 81, 152, 219, 10, 47, 146, 195, 143, 122, 170, 211, 200, 47, 26, 228, 222, 177, 4, 252, 160, 36, 26, 132, 201, 130, 34, 18, 102, 35, 8, 10, 81, 20, 16, 8, 17, 170, 114, 41, 181, 114, 144, 166, 97, 30, 254, 143, 12 }, new byte[] { 209, 42, 201, 137, 65, 249, 109, 151, 222, 32, 212, 189, 189, 65, 153, 99, 237, 209, 164, 110, 132, 188, 148, 163, 203, 233, 149, 165, 172, 244, 8, 41, 127, 34, 44, 140, 149, 197, 139, 68, 181, 202, 208, 126, 31, 137, 218, 42, 77, 53, 44, 0, 126, 166, 219, 218, 1, 141, 66, 37, 93, 218, 122, 223, 172, 95, 74, 228, 250, 71, 214, 209, 81, 156, 34, 88, 220, 204, 183, 91, 68, 255, 250, 9, 5, 29, 101, 248, 90, 228, 145, 208, 111, 228, 98, 238, 209, 136, 92, 102, 91, 105, 232, 203, 90, 162, 213, 172, 195, 176, 249, 42, 130, 129, 204, 0, 159, 251, 193, 106, 57, 117, 171, 132, 245, 199, 174, 41 } });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Model",
                table: "Cars",
                column: "Model",
                unique: true);
        }
    }
}
