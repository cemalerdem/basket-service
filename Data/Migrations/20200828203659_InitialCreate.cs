using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(nullable: false),
                    UpdateAtUtc = table.Column<DateTime>(nullable: true),
                    ItemId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    BasketId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasketViews",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(nullable: false),
                    UpdateAtUtc = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketViews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(nullable: false),
                    UpdateAtUtc = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAtUtc", "IsActive", "Name", "Quantity", "UnitPrice", "UpdateAtUtc" },
                values: new object[,]
                {
                    { new Guid("c70dbbe0-da7c-414a-9d3f-3a1971b1d460"), new DateTime(2020, 8, 28, 20, 36, 59, 357, DateTimeKind.Utc).AddTicks(522), true, "Iphone", 5, 1200m, null },
                    { new Guid("90a678ec-812e-442a-a8ad-f0017c69ddde"), new DateTime(2020, 8, 28, 20, 36, 59, 357, DateTimeKind.Utc).AddTicks(5681), true, "Pencil", 5, 1200m, null },
                    { new Guid("499853b9-dcda-4eb3-a5f5-fe013e4736ee"), new DateTime(2020, 8, 28, 20, 36, 59, 357, DateTimeKind.Utc).AddTicks(5791), true, "Novel", 5, 1200m, null },
                    { new Guid("ac8ebb95-d266-4968-8e17-0b5e42b8ca06"), new DateTime(2020, 8, 28, 20, 36, 59, 357, DateTimeKind.Utc).AddTicks(5796), true, "Mouse", 5, 1200m, null },
                    { new Guid("f130e2c9-aa85-4c0d-96ca-1f85e7c96ddb"), new DateTime(2020, 8, 28, 20, 36, 59, 357, DateTimeKind.Utc).AddTicks(5799), true, "Keyboard", 5, 1200m, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "BasketViews");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
