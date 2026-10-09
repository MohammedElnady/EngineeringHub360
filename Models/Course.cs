using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EngineeringHub360.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(300)]
        public string ShortDescription { get; set; } = string.Empty;

        [MaxLength(3000)]
        public string Description { get; set; } = string.Empty;

        [Precision(18, 2)]
        public decimal OriginalPrice { get; set; }

        [Precision(18, 2)]
        public decimal DiscountPrice { get; set; }

        [MaxLength(200)]
        public string InstructorName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Category { get; set; } = string.Empty;

        [MaxLength(500)]
        public string ImageUrl { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public ICollection<CourseLesson> Lessons { get; set; }
            = new List<CourseLesson>();
    }
}