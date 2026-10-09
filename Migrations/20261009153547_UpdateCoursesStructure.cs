using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EngineeringHub360.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCoursesStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Courses",
                newName: "OriginalPrice");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Courses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPrice",
                table: "Courses",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "InstructorName",
                table: "Courses",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Courses",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Description", "DiscountPrice", "ImageUrl", "InstructorName", "OriginalPrice", "ShortDescription", "Title" },
                values: new object[] { "Technical Office", "تعلم الحصر الهندسي للمشروعات من البداية حتى الاحتراف.", 600m, "/images/courses/quantity-surveying.jpg", "Engineering Hub 360", 600m, "كورس الحصر الهندسي + كتاب الحصر", "الحصر الهندسي" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Description", "DiscountPrice", "ImageUrl", "InstructorName", "OriginalPrice", "ShortDescription", "Title" },
                values: new object[] { "Shop Drawing", "إعداد ومراجعة اللوحات التنفيذية الإنشائية والمعمارية.", 750m, "/images/courses/shopdrawing.jpg", "Engineering Hub 360", 850m, "كورس الشوب دروينج الإنشائي والمعماري", "الشوب دروينج الإنشائي والمعماري" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Description", "DiscountPrice", "ImageUrl", "InstructorName", "OriginalPrice", "ShortDescription", "Title" },
                values: new object[] { "Cost Control", "متابعة التنفيذ والحصر والتحكم في تكاليف المشروع.", 600m, "/images/courses/costcontrol.jpg", "Engineering Hub 360", 850m, "حصر المقاول والتحكم في التكاليف", "حصر المقاول والتحكم في التكاليف" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Category", "Description", "DiscountPrice", "ImageUrl", "InstructorName", "IsActive", "OriginalPrice", "ShortDescription", "Title" },
                values: new object[,]
                {
                    { 4, "Technical Office", "تأهيل مهندس المكتب الفني للعمل باحترافية.", 500m, "/images/courses/technicaloffice.jpg", "Engineering Hub 360", true, 700m, "يشمل كتاب إعداد مهندس مكتب فني", "تنظيم وإدارة المكتب الفني" },
                    { 5, "Technical Office", "الربط الكامل بين أعمال المكتب الفني والموقع.", 500m, "/images/courses/integration.jpg", "Engineering Hub 360", true, 750m, "يشمل كتابي الترابط", "الترابط بين المكتب الفني والتنفيذ" },
                    { 6, "Estimation", "احتراف تحليل الأسعار وتسعير بنود الأعمال.", 1000m, "/images/courses/pricing.jpg", "Engineering Hub 360", true, 2500m, "يشمل كتاب التسعير", "تسعير بنود الأعمال" },
                    { 7, "Claims", "دراسة وتحليل فروق الأسعار للمبتدئين.", 1000m, "/images/courses/claims1.jpg", "Engineering Hub 360", true, 6500m, "يشمل برنامج حسابات الفروق", "فروق الأسعار - المستوى الأول" },
                    { 8, "Claims", "المستوى المتقدم في فروق الأسعار والتعويضات.", 750m, "/images/courses/claims2.jpg", "Engineering Hub 360", true, 4500m, "يشمل برنامج الفروق والتعويضات", "فروق الأسعار - المستوى الثاني" },
                    { 9, "Technical Office", "تطوير مهارات المكتب الفني للمستوى المتقدم.", 800m, "/images/courses/advancedoffice.jpg", "Engineering Hub 360", true, 2500m, "Advanced Technical Office", "المكتب الفني المتقدم" },
                    { 10, "Quality", "مبادئ ضبط الجودة وضمان الجودة بالمشروعات.", 0m, "/images/courses/quality.jpg", "Engineering Hub 360", true, 0m, "هدية مجانية", "ضبط الجودة" },
                    { 11, "Technical Office", "إعداد ومراجعة مستخلصات المقاولين والمالكين.", 1000m, "/images/courses/paymentcertificate.jpg", "Engineering Hub 360", true, 1750m, "كورس مستقل", "إعداد المستخلصات" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "InstructorName",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "OriginalPrice",
                table: "Courses",
                newName: "Price");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { "التخطيط والجدولة الزمنية للمشروعات", "/images/primavera.jpg", 999m, "Primavera P6 Professional" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { "التحكم في التكاليف وإدارة الميزانيات", "/images/costcontrol.jpg", 799m, "Cost Control Professional" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { "حصر الكميات والتسعير الهندسي", "/images/qs.jpg", 899m, "Quantity Surveying" });
        }
    }
}
