using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarJournal.Migrations
{
    /// <inheritdoc />
    public partial class addCarsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Series = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    VendorId = table.Column<int>(type: "integer", nullable: false),
                    BodyTypeId = table.Column<int>(type: "integer", nullable: false),
                    EngineId = table.Column<int>(type: "integer", nullable: false),
                    GearboxId = table.Column<int>(type: "integer", nullable: false),
                    FuelTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_BodyTypes_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalTable: "BodyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_FuelTypes_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "FuelTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Gearboxes_GearboxId",
                        column: x => x.GearboxId,
                        principalTable: "Gearboxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 200, 101, 96, 160, 64, 196, 14, 171, 85, 186, 233, 100, 134, 202, 203, 65, 86, 172, 90, 95, 138, 125, 43, 69, 221, 145, 217, 170, 229, 3, 34, 155, 249, 229, 217, 193, 197, 226, 1, 104, 139, 174, 20, 202, 133, 52, 176, 64, 241, 61, 199, 114, 64, 199, 59, 106, 173, 48, 155, 227, 131, 119, 130, 162 }, new byte[] { 216, 36, 71, 104, 69, 118, 4, 74, 215, 66, 197, 130, 136, 244, 62, 96, 112, 78, 107, 254, 234, 57, 132, 189, 226, 213, 53, 226, 214, 63, 53, 85, 230, 132, 62, 68, 138, 37, 0, 41, 218, 122, 97, 183, 165, 105, 228, 42, 149, 78, 80, 150, 59, 220, 179, 198, 181, 129, 172, 76, 97, 41, 109, 75, 34, 230, 115, 223, 74, 181, 185, 194, 238, 4, 171, 164, 209, 18, 185, 33, 30, 88, 94, 40, 236, 125, 94, 28, 223, 162, 92, 126, 57, 206, 37, 193, 108, 17, 102, 130, 225, 121, 136, 55, 245, 212, 27, 152, 180, 76, 98, 147, 153, 95, 38, 164, 208, 49, 162, 213, 120, 11, 184, 96, 70, 229, 207, 119 } });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BodyTypeId",
                table: "Cars",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineId",
                table: "Cars",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FuelTypeId",
                table: "Cars",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_GearboxId",
                table: "Cars",
                column: "GearboxId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Model",
                table: "Cars",
                column: "Model",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_VendorId",
                table: "Cars",
                column: "VendorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 203, 211, 46, 85, 131, 238, 94, 193, 48, 3, 62, 67, 134, 137, 130, 137, 220, 147, 183, 3, 165, 218, 204, 136, 65, 94, 222, 104, 238, 132, 154, 178, 13, 98, 194, 75, 244, 13, 230, 123, 57, 127, 13, 184, 165, 85, 152, 159, 181, 181, 89, 59, 61, 79, 236, 79, 127, 214, 83, 48, 206, 77, 81, 206 }, new byte[] { 208, 125, 27, 87, 138, 202, 178, 15, 230, 202, 77, 191, 6, 116, 20, 89, 125, 59, 75, 104, 143, 119, 39, 141, 87, 215, 207, 184, 84, 21, 198, 33, 55, 109, 196, 42, 21, 217, 152, 128, 60, 72, 81, 233, 79, 167, 223, 252, 103, 23, 123, 26, 218, 55, 143, 52, 18, 214, 40, 223, 69, 63, 38, 192, 141, 214, 201, 225, 91, 116, 152, 184, 133, 101, 45, 52, 114, 152, 225, 125, 202, 235, 75, 244, 198, 236, 66, 176, 43, 74, 83, 74, 82, 92, 175, 221, 129, 81, 56, 235, 45, 156, 200, 208, 239, 210, 172, 230, 243, 12, 101, 51, 153, 190, 76, 241, 84, 3, 60, 95, 59, 171, 199, 113, 150, 48, 106, 162 } });
        }
    }
}
