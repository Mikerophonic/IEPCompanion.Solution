using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IEPCompanion.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.UI; 

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        var services = builder.Services;

        var connectionString = GetConnectionString(builder, "DefaultConnection");

        services.AddDbContext<IEPCompanionContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


        //Adds identity roles to the database.
        builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IEPCompanionContext>();

        connectionString = GetConnectionString(builder, "IEPCompanion");

        builder.Services.AddControllersWithViews();
    }

    public static string GetConnectionString(WebApplicationBuilder builder, string name)
    {
        // Retrieve the connection string by name from your configuration.
        // This is just a placeholder. Replace with your actual code.
        return builder.Configuration.GetConnectionString(name);
    }
}

  // be sure to change the namespace to match your project
  namespace IEPCompanion
  {
    class Program
    {
      static async Task Main(string[] args)
      {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<IEPCompanionContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        // Adds identity roles to the database.
        builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
          .AddRoles<IdentityRole>()
          .AddEntityFrameworkStores<IEPCompanionContext>();

        builder.Services.AddControllersWithViews();

        // be sure to update the line below for your project
        builder.Services.AddDbContext<IEPCompanionContext>(
          dbContextOptions => dbContextOptions
            .UseMySql(
              builder.Configuration["ConnectionStrings:DefaultConnection"],
              ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"])
            )
        );

        // Line below adds Identity
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
          .AddEntityFrameworkStores<IEPCompanionContext>()
          .AddDefaultTokenProviders();

        // This is where we can determine Password requirements for users.
        builder.Services.Configure<IdentityOptions>(options =>
        {
          options.Password.RequireDigit = true;
          options.Password.RequireLowercase = true;
          options.Password.RequireNonAlphanumeric = true;
          options.Password.RequireUppercase = true;
          options.Password.RequiredLength = 6;
          options.Password.RequiredUniqueChars = 1;
        });

        var app = builder.Build();

        app.UseDeveloperExceptionPage();
        app.UseStaticFiles();

        app.UseRouting();

        // Next two lines below enable authentication and authorization.
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}"
        );

        // Regarding scope of roles, this is where we can add roles to the database.
        using (var scope = app.Services.CreateScope())
        {
          var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

          var roles = new[] { "Admin", "Teacher", "Student" };

          foreach (var role in roles)
          {
            if (!await roleManager.RoleExistsAsync(role))
            {
              await roleManager.CreateAsync(new IdentityRole(role));
            }
          }
        }

        app.Run();
      }
    }
  }

