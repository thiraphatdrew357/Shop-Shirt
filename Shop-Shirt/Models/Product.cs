using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_Shirt.Models
{
    public class Product
    {
        // 1. ไอดีสินค้า (กำหนดเป็น Primary Key อัตโนมัติ)
        [Key]
        public int ProductId { get; set; }

        // 2. ชื่อสินค้าเสื้อผ้า
        [Required(ErrorMessage = "กรุณากรอกชื่อสินค้า")]
        [MaxLength(100, ErrorMessage = "ชื่อสินค้าต้องไม่เกิน 100 ตัวอักษร")]
        public string Name { get; set; } = string.Empty;

        // 3. รายละเอียดสินค้า (ใส่เครื่องหมาย ? เพื่อบอกว่าปล่อยว่างไม่กรอกก็ได้)
        [MaxLength(300, ErrorMessage = "คำอธิบายต้องไม่เกิน 300 ตัวอักษร")]
        public string? Description { get; set; }

        // 4. ราคาสินค้าเริ่มต้น
        [Required(ErrorMessage = "กรุณากรอกราคาสินค้า")]
        [Range(0, double.MaxValue, ErrorMessage = "ราคาสินค้าต้องเป็นตัวเลขบวก")]
        [RegularExpression(@"^\d{1,16}(\.\d{1,2})?$", ErrorMessage = "❌ ราคาเสื้อผ้าต้องไม่เกิน 16 หลัก และใส่ทศนิยมได้สูงสุด 2 ตำแหน่งเท่านั้นครับ")]
        [Column(TypeName = "decimal(18,2)")] // กำหนดให้เก็บเป็น decimal(18,2")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal BasePrice { get;  set; }

        // 5. วันที่เพิ่มสินค้าเข้าระบบ (ล็อกสเปกเวลาไทย)
        public DateTime CreatedAt { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(
            DateTime.UtcNow,
            TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time")
            );

        // 🔥 6. เก็บชื่อไฟล์รูปภาพ
        [Required]
        [MaxLength(255, ErrorMessage = "ชื่อไฟล์รูปภาพต้องไม่เกิน 255 ตัวอักษร")]
        public string ImageUrl { get; set; }
    }
}