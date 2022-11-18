var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(options =>
{
   options.Conventions.AuthorizePage("/Login");
   options.Conventions.AllowAnonymousToPage("/Employee/Registration");

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();






app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Login}/{id?}");

app.Run();


