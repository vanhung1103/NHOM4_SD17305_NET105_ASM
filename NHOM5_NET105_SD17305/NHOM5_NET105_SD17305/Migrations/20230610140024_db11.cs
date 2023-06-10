using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NHOM5_NET105_SD17305.Views.Migrations
{
    public partial class db11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1755f48a-74df-45f0-b91b-94e95912f2f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c1abda3-40a2-4700-9359-4c7b01847ed0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d2f91e44-0db3-4c90-8baa-a4136341dd16", "962c6173-a28f-4f7c-ae63-23c8ef0d8ac8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e257f009-7b2f-4d90-990b-645bc342af0d", "e7f04bfb-bf8d-4245-9bbd-26337a36471d", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2f91e44-0db3-4c90-8baa-a4136341dd16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e257f009-7b2f-4d90-990b-645bc342af0d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1755f48a-74df-45f0-b91b-94e95912f2f7", "e9218c00-1558-4fad-9420-c096554b59bc", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c1abda3-40a2-4700-9359-4c7b01847ed0", "d9012552-d19d-4051-afc2-6a55aad21174", "User", "USER" });
        }
    }
}
