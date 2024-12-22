﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarJournal.Migrations
{
    /// <inheritdoc />
    public partial class CarModelUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cars_Model",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 70, 162, 6, 255, 9, 99, 203, 219, 196, 216, 197, 113, 45, 65, 124, 253, 37, 25, 74, 114, 134, 222, 42, 212, 134, 124, 237, 9, 133, 136, 98, 246, 202, 244, 56, 92, 135, 157, 224, 145, 235, 233, 236, 165, 34, 246, 249, 184, 191, 28, 119, 225, 123, 26, 237, 134, 134, 158, 80, 243, 103, 21, 66, 106 }, new byte[] { 35, 80, 125, 75, 100, 71, 75, 136, 55, 43, 25, 145, 224, 246, 33, 208, 22, 143, 101, 217, 135, 26, 229, 56, 215, 207, 214, 246, 159, 168, 13, 14, 190, 92, 180, 171, 24, 28, 224, 138, 210, 223, 55, 36, 28, 234, 181, 69, 63, 30, 177, 148, 223, 227, 159, 140, 68, 225, 113, 194, 76, 250, 130, 22, 246, 103, 167, 142, 183, 223, 74, 178, 206, 150, 80, 197, 203, 162, 82, 175, 228, 73, 134, 209, 205, 250, 183, 202, 24, 50, 69, 88, 59, 12, 227, 45, 251, 102, 210, 88, 182, 127, 73, 71, 107, 163, 236, 50, 249, 17, 161, 90, 63, 130, 48, 32, 11, 190, 2, 17, 68, 2, 148, 164, 44, 217, 89, 70 } });
        }
    }
}