using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EngineeringHub360.Models
{
    public class CourseLessonUploadViewModel
    {
        [Required(ErrorMessage = "يجب اختيار الدورة")]
        [Display(Name = "الدورة")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "عنوان الدرس مطلوب")]
        [MaxLength(200)]
        [Display(Name = "عنوان الدرس")]
        public string Title { get; set; } = string.Empty;

        [MaxLength(2000)]
        [Display(Name = "وصف الدرس")]
        public string Description { get; set; } = string.Empty;

        [Range(1, 10000, ErrorMessage = "ترتيب الدرس يجب أن يبدأ من 1")]
        [Display(Name = "ترتيب الدرس")]
        public int LessonOrder { get; set; } = 1;

        [Range(0, 10000)]
        [Display(Name = "مدة الدرس بالدقائق")]
        public int DurationMinutes { get; set; }

        [Display(Name = "فيديو الشرح")]
        public IFormFile? VideoFile { get; set; }

        [Display(Name = "ملف PDF")]
        public IFormFile? PdfFile { get; set; }

        [Display(Name = "ملف Excel")]
        public IFormFile? ExcelFile { get; set; }

        [Display(Name = "السماح بالمعاينة المجانية")]
        public bool IsFreePreview { get; set; }
    }
}