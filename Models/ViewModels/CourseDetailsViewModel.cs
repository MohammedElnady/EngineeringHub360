namespace EngineeringHub360.Models.ViewModels
{
    public class CourseDetailsViewModel
    {
        public Course Course { get; set; } = null!;

        public List<CourseLesson> Lessons { get; set; }
            = new();
    }
}