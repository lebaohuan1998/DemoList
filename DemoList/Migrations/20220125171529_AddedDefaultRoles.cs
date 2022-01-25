using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoList.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0368b5d4-d064-470a-9842-aae96ba33e7a", "c1aea6d1-9fe5-4673-a9ea-14a2c4f143ab", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1fd6e4c2-5677-4f63-a9c5-3a50aa1c0c52", "e5e2dd75-e526-443c-a02b-2713791be2c4", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0368b5d4-d064-470a-9842-aae96ba33e7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fd6e4c2-5677-4f63-a9c5-3a50aa1c0c52");
        }
    }
}
