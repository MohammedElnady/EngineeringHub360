using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EngineeringHub360.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "ImageUrl", "IsActive", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "التخطيط والجدولة الزمنية للمشروعات", "/images/primavera.jpg", true, 999m, "Primavera P6 Professional" },
                    { 2, "التحكم في التكاليف وإدارة الميزانيات", "/images/costcontrol.jpg", true, 799m, "Cost Control Professional" },
                    { 3, "حصر الكميات والتسعير الهندسي", "/images/qs.jpg", true, 899m, "Quantity Surveying" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "IsAvailable", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "قاعدة بيانات أسعار متكاملة", "/images/database.jpg", true, "Cost Database", 499m },
                    { 2, "لوحة متابعة المشاريع", "/images/dashboard.jpg", true, "Excel Dashboard", 299m },
                    { 3, "نموذج احترافي للحصر والتسعير", "/images/boq.jpg", true, "BOQ Template", 199m },
                    { 4, "أدوات أكسل متقدمة", "/images/vba.jpg", true, "VBA Tools", 599m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
