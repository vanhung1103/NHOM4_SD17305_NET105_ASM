using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NHOM5_NET105_SD17305.Views.Migrations
{
    public partial class updatecombos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1306817d-ed92-4164-a935-b5d4cb4beac5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5e4febc-ae7b-438f-8e4e-7613c5b02628");

            migrationBuilder.AlterColumn<int>(
                name: "CombosPrice",
                table: "Combos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Combos",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Image",
                table: "Combos");

            migrationBuilder.AlterColumn<string>(
                name: "CombosPrice",
                table: "Combos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1306817d-ed92-4164-a935-b5d4cb4beac5", "c543cb74-6bc5-43e2-9c34-16b16347c0b0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5e4febc-ae7b-438f-8e4e-7613c5b02628", "6ad0f583-3696-425f-b833-8ab636db859d", "User", "USER" });
        }
    }
}
