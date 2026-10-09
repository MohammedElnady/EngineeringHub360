using EngineeringHub360.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EngineeringHub360.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<CourseLesson> CourseLessons { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CourseLesson>()
                .HasOne(lesson => lesson.Course)
                .WithMany(course => course.Lessons)
                .HasForeignKey(lesson => lesson.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>().HasData(

                new Course
                {
                    Id = 1,
                    Title = "الحصر الهندسي",
                    ShortDescription = "كورس الحصر الهندسي + كتاب الحصر",
                    Description = "تعلم الحصر الهندسي للمشروعات من البداية حتى الاحتراف.",
                    OriginalPrice = 600,
                    DiscountPrice = 600,
                    InstructorName = "المهندس محمد النادي",
                    Category = "Technical Office",
                    ImageUrl = "/images/courses/quantity-surveying.jpg",
                    IsActive = true
                },

                new Course
                {
                    Id = 2,
                    Title = "الشوب دروينج الإنشائي والمعماري",
                    ShortDescription = "كورس الشوب دروينج الإنشائي والمعماري",
                    Description = "إعداد ومراجعة اللوحات التنفيذية الإنشائية والمعمارية.",
                    OriginalPrice = 850,
                    DiscountPrice = 750,
                    InstructorName = "المهندس محمد النادي",
                    Category = "Shop Drawing",
                    ImageUrl = "/images/courses/shopdrawing.jpg",
                    IsActive = true
                },

                new Course
                {
                    Id = 3,
                    Title = "حصر المقاول والتحكم في التكاليف",
                    ShortDescription = "حصر المقاول والتحكم في التكاليف",
                    Description = "متابعة التنفيذ والحصر والتحكم في تكاليف المشروع.",
                    OriginalPrice = 850,
                    DiscountPrice = 600,
                    InstructorName = "المهندس محمد النادي",
                    Category = "Cost Control",
                    ImageUrl = "/images/courses/costcontrol.jpg",
                    IsActive = true
                },

                new Course
                {
                    Id = 4,
                    Title = "تنظيم وإدارة المكتب الفني",
                    ShortDescription = "يشمل كتاب إعداد مهندس مكتب فني",
                    Description = "تأهيل مهندس المكتب الفني للعمل باحترافية.",
                    OriginalPrice = 700,
                    DiscountPrice = 500,
                    InstructorName = "المهندس محمد النادي",
                    Category = "Technical Office",
                    ImageUrl = "/images/courses/technicaloffice.jpg",
                    IsActive = true
                },

                new Course
                {
                    Id = 5,
                    Title = "الترابط بين المكتب الفني والتنفيذ",
                    ShortDescription = "يشمل كتابي الترابط",
                    Description = "الربط الكامل بين أعمال المكتب الفني والموقع.",
                    OriginalPrice = 750,
                    DiscountPrice = 500,
                    InstructorName = "المهندس محمد النادي",
                    Category = "Technical Office",
                    ImageUrl = "/images/courses/integration.jpg",
                    IsActive = true
                },

                new Course
                {
                    Id = 6,
                    Title = "تسعير بنود الأعمال",
                    ShortDescription = "يشمل كتاب التسعير",
                    Description = "احتراف تحليل الأسعار وتسعير بنود الأعمال.",
                    OriginalPrice = 2500,
                    DiscountPrice = 1000,
                    InstructorName = "المهندس محمد النادي",
                    Category = "Estimation",
                    ImageUrl = "/images/courses/pricing.jpg",
                    IsActive = true
                },

                new Course
                {
                    Id = 7,
                    Title = "فروق الأسعار - المستوى الأول",
                    ShortDescription = "يشمل برنامج حسابات الفروق",
                    Description = "دراسة وتحليل فروق الأسعار للمبتدئين.",
                    OriginalPrice = 6500,
                    DiscountPrice = 1000,
                    InstructorName = "المهندس محمد النادي",
                    Category = "Claims",
                    ImageUrl = "/images/courses/claims1.jpg",
                    IsActive = true
                },

                new Course
                {
                    Id = 8,
                    Title = "فروق الأسعار - المستوى الثاني",
                    ShortDescription = "يشمل برنامج الفروق والتعويضات",
                    Description = "المستوى المتقدم في فروق الأسعار والتعويضات.",
                    OriginalPrice = 4500,
                    DiscountPrice = 750,
                    InstructorName = "المهندس محمد النادي",
                    Category = "Claims",
                    ImageUrl = "/images/courses/claims2.jpg",
                    IsActive = true
                },

                new Course
                {
                    Id = 9,
                    Title = "المكتب الفني المتقدم",
                    ShortDescription = "Advanced Technical Office",
                    Description = "تطوير مهارات المكتب الفني للمستوى المتقدم.",
                    OriginalPrice = 2500,
                    DiscountPrice = 800,
                    InstructorName = "المهندس محمد النادي",
                    Category = "Technical Office",
                    ImageUrl = "/images/courses/advancedoffice.jpg",
                    IsActive = true
                },

                new Course
                {
                    Id = 10,
                    Title = "ضبط الجودة",
                    ShortDescription = "هدية مجانية",
                    Description = "مبادئ ضبط الجودة وضمان الجودة بالمشروعات.",
                    OriginalPrice = 0,
                    DiscountPrice = 0,
                    InstructorName = "المهندس محمد النادي",
                    Category = "Quality",
                    ImageUrl = "/images/courses/quality.jpg",
                    IsActive = true
                },

                new Course
                {
                    Id = 11,
                    Title = "إعداد المستخلصات",
                    ShortDescription = "كورس مستقل",
                    Description = "إعداد ومراجعة مستخلصات المقاولين والمالكين.",
                    OriginalPrice = 1750,
                    DiscountPrice = 1000,
                    InstructorName = "المهندس محمد النادي",
                    Category = "Technical Office",
                    ImageUrl = "/images/courses/paymentcertificate.jpg",
                    IsActive = true
                }
            );

            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    Id = 1,
                    Name = "Cost Database",
                    Description = "قاعدة بيانات أسعار متكاملة",
                    Price = 499m,
                    ImageUrl = "/images/database.jpg",
                    IsAvailable = true
                },

                new Product
                {
                    Id = 2,
                    Name = "Excel Dashboard",
                    Description = "لوحة متابعة المشاريع",
                    Price = 299m,
                    ImageUrl = "/images/dashboard.jpg",
                    IsAvailable = true
                },

                new Product
                {
                    Id = 3,
                    Name = "BOQ Template",
                    Description = "نموذج احترافي للحصر والتسعير",
                    Price = 199m,
                    ImageUrl = "/images/boq.jpg",
                    IsAvailable = true
                },

                new Product
                {
                    Id = 4,
                    Name = "VBA Tools",
                    Description = "أدوات Excel متقدمة",
                    Price = 599m,
                    ImageUrl = "/images/vba.jpg",
                    IsAvailable = true
                }
            );
        }
    }
}