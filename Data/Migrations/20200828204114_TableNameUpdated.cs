using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class TableNameUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("499853b9-dcda-4eb3-a5f5-fe013e4736ee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("90a678ec-812e-442a-a8ad-f0017c69ddde"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ac8ebb95-d266-4968-8e17-0b5e42b8ca06"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c70dbbe0-da7c-414a-9d3f-3a1971b1d460"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f130e2c9-aa85-4c0d-96ca-1f85e7c96ddb"));

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ItemDetailView");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemDetailView",
                table: "ItemDetailView",
                column: "Id");

            migrationBuilder.InsertData(
                table: "ItemDetailView",
                columns: new[] { "Id", "CreatedAtUtc", "IsActive", "Name", "Quantity", "UnitPrice", "UpdateAtUtc" },
                values: new object[,]
                {
                    { new Guid("d5249f8c-7c0e-48ab-9659-61509b5a87b5"), new DateTime(2020, 8, 28, 20, 41, 13, 784, DateTimeKind.Utc).AddTicks(8443), true, "Iphone", 5, 1200m, null },
                    { new Guid("9417e602-4e64-4ca7-96cf-94fa69cba20c"), new DateTime(2020, 8, 28, 20, 41, 13, 785, DateTimeKind.Utc).AddTicks(2685), true, "Pencil", 5, 1200m, null },
                    { new Guid("a39a0474-3fcb-4891-8ed5-3f603602a742"), new DateTime(2020, 8, 28, 20, 41, 13, 785, DateTimeKind.Utc).AddTicks(2762), true, "Novel", 5, 1200m, null },
                    { new Guid("1d6832e4-87b2-494a-8009-91cf9f8ff14d"), new DateTime(2020, 8, 28, 20, 41, 13, 785, DateTimeKind.Utc).AddTicks(2765), true, "Mouse", 5, 1200m, null },
                    { new Guid("e6a766b5-6e78-4fb3-884c-c6055cece4ef"), new DateTime(2020, 8, 28, 20, 41, 13, 785, DateTimeKind.Utc).AddTicks(2767), true, "Keyboard", 5, 1200m, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemDetailView",
                table: "ItemDetailView");

            migrationBuilder.DeleteData(
                table: "ItemDetailView",
                keyColumn: "Id",
                keyValue: new Guid("1d6832e4-87b2-494a-8009-91cf9f8ff14d"));

            migrationBuilder.DeleteData(
                table: "ItemDetailView",
                keyColumn: "Id",
                keyValue: new Guid("9417e602-4e64-4ca7-96cf-94fa69cba20c"));

            migrationBuilder.DeleteData(
                table: "ItemDetailView",
                keyColumn: "Id",
                keyValue: new Guid("a39a0474-3fcb-4891-8ed5-3f603602a742"));

            migrationBuilder.DeleteData(
                table: "ItemDetailView",
                keyColumn: "Id",
                keyValue: new Guid("d5249f8c-7c0e-48ab-9659-61509b5a87b5"));

            migrationBuilder.DeleteData(
                table: "ItemDetailView",
                keyColumn: "Id",
                keyValue: new Guid("e6a766b5-6e78-4fb3-884c-c6055cece4ef"));

            migrationBuilder.RenameTable(
                name: "ItemDetailView",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

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
    }
}
