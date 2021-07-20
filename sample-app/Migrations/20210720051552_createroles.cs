using Microsoft.EntityFrameworkCore.Migrations;

namespace sample_app.Migrations
{
    public partial class createroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b15df849-a4f2-4e8a-b46a-e9f184e77858", "43b9c715-0a63-4dc0-ba92-014125f47504", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6fadfc2c-48e8-4935-b216-28c3184c4c8c", "0ba0b71b-3ad5-4d76-adec-b5e1779ea689", "Administrator", "Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fadfc2c-48e8-4935-b216-28c3184c4c8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b15df849-a4f2-4e8a-b46a-e9f184e77858");
        }
    }
}
