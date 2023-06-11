using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NHOM5_NET105_SD17305.Views.Migrations
{
    public partial class promocodev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80f71728-3fd9-4f21-88bc-61499b3f18a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84c5b37d-452e-4383-9efa-5e8f3a0b799d");

            migrationBuilder.AlterColumn<int>(
                name: "PromoValue",
                table: "Promotions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e5d0d9f-83ff-4525-9f8f-3cd8c9227e37", "386fc869-cae0-404f-8758-d7433141d4fb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae096b35-114e-474e-b83b-985100210516", "9d3dee79-b866-4fe2-b3c1-228050f8cbcb", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e5d0d9f-83ff-4525-9f8f-3cd8c9227e37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae096b35-114e-474e-b83b-985100210516");

            migrationBuilder.AlterColumn<string>(
                name: "PromoValue",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80f71728-3fd9-4f21-88bc-61499b3f18a4", "531fed2d-22d2-4a1a-a06e-35e09aa3bfc3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84c5b37d-452e-4383-9efa-5e8f3a0b799d", "23f26f97-0330-4b7a-be6a-2388d10214f0", "User", "USER" });
        }
    }
}
