using Microsoft.AspNetCore.Identity;

namespace EngineeringHub360.Data
{
    public static class IdentitySeeder
    {
        public static async Task SeedAdminAsync(
            IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            var roleManager =
                serviceProvider.GetRequiredService<
                    RoleManager<IdentityRole>>();

            var userManager =
                serviceProvider.GetRequiredService<
                    UserManager<IdentityUser>>();

            const string adminRole = "Admin";

            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                var roleResult = await roleManager.CreateAsync(
                    new IdentityRole(adminRole));

                if (!roleResult.Succeeded)
                {
                    var errors = string.Join(
                        Environment.NewLine,
                        roleResult.Errors.Select(error =>
                            error.Description));

                    throw new InvalidOperationException(
                        $"تعذر إنشاء صلاحية Admin:{Environment.NewLine}{errors}");
                }
            }

            var adminEmail =
                configuration["AdminAccount:Email"];

            var adminPassword =
                configuration["AdminAccount:Password"];

            if (string.IsNullOrWhiteSpace(adminEmail))
            {
                throw new InvalidOperationException(
                    "لم يتم تحديد البريد الإلكتروني لحساب الإدارة.");
            }

            if (string.IsNullOrWhiteSpace(adminPassword))
            {
                throw new InvalidOperationException(
                    "لم يتم تحديد كلمة مرور حساب الإدارة.");
            }

            var adminUser =
                await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var userResult =
                    await userManager.CreateAsync(
                        adminUser,
                        adminPassword);

                if (!userResult.Succeeded)
                {
                    var errors = string.Join(
                        Environment.NewLine,
                        userResult.Errors.Select(error =>
                            error.Description));

                    throw new InvalidOperationException(
                        $"تعذر إنشاء حساب الإدارة:{Environment.NewLine}{errors}");
                }
            }

            if (!await userManager.IsInRoleAsync(
                    adminUser,
                    adminRole))
            {
                var addToRoleResult =
                    await userManager.AddToRoleAsync(
                        adminUser,
                        adminRole);

                if (!addToRoleResult.Succeeded)
                {
                    var errors = string.Join(
                        Environment.NewLine,
                        addToRoleResult.Errors.Select(error =>
                            error.Description));

                    throw new InvalidOperationException(
                        $"تعذر منح صلاحية Admin:{Environment.NewLine}{errors}");
                }
            }
        }
    }
}