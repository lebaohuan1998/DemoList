using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoList.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Class", "Name" },
                values: new object[] { 1, "Class1", "Course1" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Class", "Name" },
                values: new object[] { 2, "Class2", "Course2" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Class", "Name" },
                values: new object[] { 3, "Class3", "Course3" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Age", "CourseId", "Name" },
                values: new object[] { 1, "address1", 1, 1, "Course1" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Age", "CourseId", "Name" },
                values: new object[] { 2, "address2", 2, 1, "Course2" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Age", "CourseId", "Name" },
                values: new object[] { 3, "address3", 3, 2, "Course3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
