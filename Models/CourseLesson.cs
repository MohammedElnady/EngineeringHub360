using System.ComponentModel.DataAnnotations;

namespace EngineeringHub360.Models
{
    public class CourseLesson
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        public int LessonOrder { get; set; }

        public int DurationMinutes { get; set; }

        [MaxLength(500)]
        public string? VideoPath { get; set; }

        [MaxLength(500)]
        public string? PdfPath { get; set; }

        [MaxLength(500)]
        public string? ExcelPath { get; set; }

        public bool IsFreePreview { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int CourseId { get; set; }

        public Course Course { get; set; } = null!;
    }
}