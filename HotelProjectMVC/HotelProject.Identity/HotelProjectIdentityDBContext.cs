using HotelProject.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Identity
{
    //IdentityDbContext<User, Role, string> foydalanuvchi va rol ma'lumotlarini saqlash
    //va boshqarish uchun Entity Framework orqali ma'lumotlar bazasiga kirish imkonini beradi.
    //Bu tizim foydalanuvchilarni autentifikatsiya qilish va avtorizatsiya qilish uchun zarur bo'lgan barcha funktsiyalarni taqdim etadi.
    public class HotelProjectIdentityDBContext:IdentityDbContext<User,Role,string>
    {
        //Bu konstruktor DbContextOptions<HotelProjectIdentityDBContext> turidagi parametrni qabul qiladi va base(options) orqali bazaviy DbContext konstruktoriga uzatadi. Bu orqali kontekstning qanday qilib sozlanishini belgilash imkonini beradi (masalan, ma'lumotlar bazasining ulanishi).
        public HotelProjectIdentityDBContext(DbContextOptions<HotelProjectIdentityDBContext> options):base(options)
        {
            //Bu qator Npgsql (PostgreSQL uchun Entity Framework Core provayderi) bilan ishlashda eski vaqt belgilari bilan ishlashni yoqadi. Bu, asosan, vaqt belgilari bilan bog'liq muammolarni bartaraf etish uchun qo'llaniladi.
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior",true);
            //Bu qator ma'lumotlar bazasini yangilaydi. Dastur ishga tushganda, agar yangi migratsiyalar mavjud bo'lsa, ular avtomatik ravishda qo'llaniladi. Bu orqali dastur yangilanishlari avtomatik ravishda ma'lumotlar bazasiga kiritilishi mumkin.
            Database.Migrate();
        }


        //modelBuilder yordamida siz ma'lumotlar modeli, ya'ni jadvallar va ularning o'zaro bog'lanishlarini belgilaysiz. Masalan, ustun nomlari, ma'lumot turlari, unikal cheklovlar va boshqa parametrlari.
        protected override void OnModelCreating(ModelBuilder modelBuilder)=>
            base.OnModelCreating(modelBuilder);


        //Bu metodda siz ma'lumotlar bazasi ulanishi (connection string) va uning parametrlarini belgilashingiz mumkin. Misol uchun, SQL Server, PostgreSQL yoki boshqa ma'lumotlar bazasi provayderlariga ulanish uchun kerakli sozlamalarni o'rnatishingiz mumkin.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    } 
}
