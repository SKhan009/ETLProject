using YSU.Models;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.Configure<NSFDatabaseSettings>(
builder.Configuration.GetSection("NSFDatabase"));
builder.Services.AddSingleton<AwardService>();

builder.Services.AddSingleton<MongoDbContext>(_ =>
    new MongoDbContext(builder.Configuration.GetConnectionString("MongoDBConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Configure Serilog to work with ASP.NET Core
//app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Xml",
    pattern: "Xml/{action=ReadXmlFiles}/{id?}",
    defaults: new { controller = "Xml" });


app.Run();
