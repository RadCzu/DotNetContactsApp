using DotNetContactsApp.Data;
using DotNetContactsApp.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DotNetContactsApp.Areas.Identity.Data;


var builder = WebApplication.CreateBuilder(args);


// Builder setup with Razor Service and the app Context
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationLocalDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("LocalDatabase")));
builder.Services.AddDefaultIdentity<ContactsAppUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationLocalDbContext>();

// Basic password complexity required
// Password length: 8, special character, a number but also both an uppercase and a lowercase letter.
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
});


// Added a policy for authentication so that, I can restrict access to the Contact Model
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireLoggedIn", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});

var app = builder.Build();

// Configured HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Use static files for possible extra css and js scripts
// None ended up in the final app
app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    RequestPath = "/js"
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
