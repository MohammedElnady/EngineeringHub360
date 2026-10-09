using EngineeringHub360.Data;
using EngineeringHub360.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EngineeringHub360.Controllers
{
    public class CourseLessonsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        private static readonly string[] VideoExtensions =
        {
            ".mp4", ".webm", ".mov"
        };

        private static readonly string[] PdfExtensions =
        {
            ".pdf"
        };

        private static readonly string[] ExcelExtensions =
        {
            ".xlsx", ".xls", ".xlsm", ".csv"
        };

        public CourseLessonsController(
            ApplicationDbContext context,
            IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var lessons = await _context.CourseLessons
                .Include(lesson => lesson.Course)
                .OrderBy(lesson => lesson.CourseId)
                .ThenBy(lesson => lesson.LessonOrder)
                .ToListAsync();

            return View(lessons);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadCoursesAsync();

            return View(new CourseLessonUploadViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(110 * 1024 * 1024)]
        public async Task<IActionResult> Create(
            CourseLessonUploadViewModel model)
        {
            var courseExists = await _context.Courses
                .AnyAsync(course =>
                    course.Id == model.CourseId &&
                    course.IsActive);

            if (!courseExists)
            {
                ModelState.AddModelError(
                    nameof(model.CourseId),
                    "الدورة المختارة غير موجودة.");
            }

            ValidateUploadedFiles(model);

            if (!ModelState.IsValid)
            {
                await LoadCoursesAsync(model.CourseId);
                return View(model);
            }

            var lesson = new CourseLesson
            {
                CourseId = model.CourseId,
                Title = model.Title,
                Description = model.Description,
                LessonOrder = model.LessonOrder,
                DurationMinutes = model.DurationMinutes,
                IsFreePreview = model.IsFreePreview,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            try
            {
                if (model.VideoFile != null)
                {
                    lesson.VideoPath = await SaveFileAsync(
                        model.VideoFile,
                        "videos");
                }

                if (model.PdfFile != null)
                {
                    lesson.PdfPath = await SaveFileAsync(
                        model.PdfFile,
                        "pdfs");
                }

                if (model.ExcelFile != null)
                {
                    lesson.ExcelPath = await SaveFileAsync(
                        model.ExcelFile,
                        "excels");
                }

                _context.CourseLessons.Add(lesson);

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] =
                    "تم إنشاء الدرس ورفع الملفات بنجاح.";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                DeleteSavedFile(lesson.VideoPath);
                DeleteSavedFile(lesson.PdfPath);
                DeleteSavedFile(lesson.ExcelPath);

                ModelState.AddModelError(
                    string.Empty,
                    "حدث خطأ أثناء حفظ الدرس أو رفع الملفات.");

                await LoadCoursesAsync(model.CourseId);

                return View(model);
            }
        }

        private async Task LoadCoursesAsync(
            int? selectedCourseId = null)
        {
            var courses = await _context.Courses
                .Where(course => course.IsActive)
                .OrderBy(course => course.Title)
                .ToListAsync();

            ViewBag.Courses = new SelectList(
                courses,
                "Id",
                "Title",
                selectedCourseId);
        }

        private void ValidateUploadedFiles(
            CourseLessonUploadViewModel model)
        {
            ValidateFile(
                model.VideoFile,
                VideoExtensions,
                100 * 1024 * 1024,
                nameof(model.VideoFile),
                "الفيديو");

            ValidateFile(
                model.PdfFile,
                PdfExtensions,
                20 * 1024 * 1024,
                nameof(model.PdfFile),
                "ملف PDF");

            ValidateFile(
                model.ExcelFile,
                ExcelExtensions,
                20 * 1024 * 1024,
                nameof(model.ExcelFile),
                "ملف Excel");
        }

        private void ValidateFile(
            IFormFile? file,
            string[] allowedExtensions,
            long maximumSize,
            string propertyName,
            string displayName)
        {
            if (file == null)
            {
                return;
            }

            if (file.Length == 0)
            {
                ModelState.AddModelError(
                    propertyName,
                    $"{displayName} فارغ.");

                return;
            }

            if (file.Length > maximumSize)
            {
                ModelState.AddModelError(
                    propertyName,
                    $"حجم {displayName} أكبر من الحد المسموح.");

                return;
            }

            var extension = Path
                .GetExtension(file.FileName)
                .ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
            {
                ModelState.AddModelError(
                    propertyName,
                    $"امتداد {displayName} غير مسموح.");
            }
        }

        private async Task<string> SaveFileAsync(
            IFormFile file,
            string folderName)
        {
            var uploadFolder = Path.Combine(
                _environment.WebRootPath,
                "uploads",
                folderName);

            Directory.CreateDirectory(uploadFolder);

            var extension = Path
                .GetExtension(file.FileName)
                .ToLowerInvariant();

            var safeFileName =
                $"{Guid.NewGuid():N}{extension}";

            var physicalPath = Path.Combine(
                uploadFolder,
                safeFileName);

            await using var stream = new FileStream(
                physicalPath,
                FileMode.CreateNew);

            await file.CopyToAsync(stream);

            return $"/uploads/{folderName}/{safeFileName}";
        }

        private void DeleteSavedFile(string? relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
            {
                return;
            }

            var cleanedPath = relativePath
                .TrimStart('/')
                .Replace(
                    '/',
                    Path.DirectorySeparatorChar);

            var fullPath = Path.Combine(
                _environment.WebRootPath,
                cleanedPath);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }
    }
}
