using Microsoft.EntityFrameworkCore; // <--- เพิ่มบรรทัดนี้
using Shop_Shirt.Data;                // <--- เพิ่มบรรทัดนี้เพื่อเชื่อมกับโฟลเดอร์ Data

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// --- ย้ายมาไว้ตรงนี้ (ก่อนสร้างตัวแปร app) ---
// 1. ดึงสายเชื่อมต่อ (Connection String) จาก appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. สั่งให้ระบบลงทะเบียนเชื่อมต่อกับฐานข้อมูล SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
// ------------------------------------------

var app = builder.Build(); // เส้นแบ่ง: ห้ามเอา builder.Services ไปไว้ใต้บรรทัดนี้

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();