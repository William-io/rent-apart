using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VARCHAR60 = table.Column<string>(name: "VARCHAR(60)", type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rentings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VARCHAR40 = table.Column<string>(name: "VARCHAR(40)", type: "nvarchar(40)", maxLength: 40, nullable: false),
                    VARCHAR120 = table.Column<string>(name: "VARCHAR(120)", type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Ranting = table.Column<int>(type: "int", nullable: false),
                    Rooms = table.Column<double>(type: "float", nullable: false),
                    Bookings = table.Column<double>(type: "float", nullable: false),
                    Gym = table.Column<bool>(type: "bit", nullable: false),
                    Pool = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Category",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "VARCHAR(60)" },
                values: new object[] { new Guid("b67c1bfe-0d13-4f6f-a970-48888baaa032"), "Casa" });

            migrationBuilder.InsertData(
                table: "Rentings",
                columns: new[] { "Id", "Availability", "Bookings", "CategoryId", "CreatedOn", "VARCHAR(120)", "Gym", "VARCHAR(40)", "Pool", "Price", "Ranting", "Rooms" },
                values: new object[] { new Guid("65f15545-4ed8-4881-accb-1503edd930c8"), false, 0.0, null, new DateTime(2021, 11, 30, 10, 28, 26, 537, DateTimeKind.Local).AddTicks(2514), "Hotel Quay is a hotel in the city of Quay, in the municipality of Quay, in the province of Québec, Canada.", true, "Hotel Quay", true, 1000.00m, 5, 2.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Rentings_CategoryId",
                table: "Rentings",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentings");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
