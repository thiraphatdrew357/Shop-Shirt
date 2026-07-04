using System;

namespace Shop_Shirt.Models
{
    public class Product
    {
        // 1. ไอดีสินค้า (กำหนดเป็น Primary Key อัตโนมัติ)
        public int ProductId { get; set; }

        // 2. ชื่อสินค้าเสื้อผ้า
        public string Name { get; set; } = string.Empty;

        // 3. รายละเอียดสินค้า (ใส่เครื่องหมาย ? เพื่อบอกว่าปล่อยว่างไม่กรอกก็ได้)
        public string? Description { get; set; }

        // 4. ราคาสินค้าเริ่มต้น
        public decimal BasePrice { get;  set; }

        // 5. วันที่เพิ่มสินค้าเข้าระบบ (ให้ใส่เวลาปัจจุบันไว้เป็นค่าเริ่มต้น)
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}