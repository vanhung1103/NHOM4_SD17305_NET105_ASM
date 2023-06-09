using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NHOM5_NET105_SD17305.Views.Migrations
{
    public partial class mgdas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "884e2c22-dd5f-4c86-9ebc-d8552764eb77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbbfa028-25ad-46b0-af90-ee5a2034e358");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a1b32bc-00b3-44ed-9e6a-9680ea16925b", "7684bec0-f690-4826-9ef0-e7f718695996", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3be1e3c-52d2-4ad0-ae3e-01108b66fe48", "d12e33f3-fd89-4e0b-b6c5-f2f37f465f64", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a1b32bc-00b3-44ed-9e6a-9680ea16925b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3be1e3c-52d2-4ad0-ae3e-01108b66fe48");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "884e2c22-dd5f-4c86-9ebc-d8552764eb77", "badf9f38-50e0-4fbf-8815-0a1b332fdce5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cbbfa028-25ad-46b0-af90-ee5a2034e358", "aded1bf8-07a9-481f-976e-7c66734eaea3", "User", "USER" });
        }
    }
}
