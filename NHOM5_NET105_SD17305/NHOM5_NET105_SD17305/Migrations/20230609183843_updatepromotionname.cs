using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NHOM5_NET105_SD17305.Views.Migrations
{
    public partial class updatepromotionname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PromotionName",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c66bdc60-8ac1-485e-af65-431791dbdd35", "bfee4dc5-4e62-49e9-aee5-1d1daec22666", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df419f66-cfd4-4126-924f-252773ca2e15", "096b90f8-bf63-4094-94b2-8ebc188d9c64", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c66bdc60-8ac1-485e-af65-431791dbdd35");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df419f66-cfd4-4126-924f-252773ca2e15");

            migrationBuilder.AlterColumn<int>(
                name: "PromotionName",
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
    }
}
