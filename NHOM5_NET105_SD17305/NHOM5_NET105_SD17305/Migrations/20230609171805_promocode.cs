using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NHOM5_NET105_SD17305.Views.Migrations
{
    public partial class promocode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18dbd66-fb08-40c2-86c6-457364d93a5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a78c9e7c-fb03-42e0-a391-d23ffe639e2b");

            migrationBuilder.DropColumn(
                name: "PromoCode",
                table: "PromotionItems");

            migrationBuilder.DropColumn(
                name: "PromoValue",
                table: "PromotionItems");

            migrationBuilder.AddColumn<string>(
                name: "PromoCode",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PromoValue",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80f71728-3fd9-4f21-88bc-61499b3f18a4", "531fed2d-22d2-4a1a-a06e-35e09aa3bfc3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84c5b37d-452e-4383-9efa-5e8f3a0b799d", "23f26f97-0330-4b7a-be6a-2388d10214f0", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80f71728-3fd9-4f21-88bc-61499b3f18a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84c5b37d-452e-4383-9efa-5e8f3a0b799d");

            migrationBuilder.DropColumn(
                name: "PromoCode",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "PromoValue",
                table: "Promotions");

            migrationBuilder.AddColumn<string>(
                name: "PromoCode",
                table: "PromotionItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PromoValue",
                table: "PromotionItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18dbd66-fb08-40c2-86c6-457364d93a5e", "c580befb-16cc-45fb-b5dd-7e8aac7bf93e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a78c9e7c-fb03-42e0-a391-d23ffe639e2b", "a44ccb79-55e4-4eee-9d58-7ca0249f77f8", "User", "USER" });
        }
    }
}
