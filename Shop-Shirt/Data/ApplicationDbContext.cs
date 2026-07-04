using Microsoft.EntityFrameworkCore;
using Shop_Shirt.Models;

namespace Shop_Shirt.Data
{
    // คลาสนี้จะทำหน้าที่เป็นสะพานเชื่อมระหว่างโค้ด C# กับ SQL Server
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // ตรงนี้คือการประกาศบอกว่าเราจะมีตารางชื่อ Products ในฐานข้อมูล (อ้างอิงจากคลาสโมเดล Product)
        // ตอนนี้ระบบอาจจะขึ้นเส้นใต้สีแดงที่คำว่า Product เพราะเรายังไม่ได้สร้างไฟล์ Product.cs ครับ (ไม่ต้องตกใจนะ)
        public DbSet<Product> Products { get; set; }

        // --- เพิ่มฟังก์ชันนี้ลงไปด้านล่างสุดของคลาสเพื่อล็อกขนาดเงิน ---
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // กำหนดให้ BasePrice ในตาราง Product เก็บข้อมูลแบบ decimal(18,2)
            modelBuilder.Entity<Product>()
                .Property(p => p.BasePrice)
                .HasColumnType("decimal(18,2)");
        }
    }
}
  