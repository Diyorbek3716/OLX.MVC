using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Core.Entities
{
    // BaseEntity class asosiy hisoblanadi Entities papkasi uchun
    public class BaseEntity:IHasIsDeletedProporty
    {
        //Guid (Globally Unique Identifier) sinfi .NETda unikal identifikatorlar yaratish va ishlatish uchun mo'ljallangan.
        //Guid sinfi C#da va boshqa .NET tillarida global darajada unikal bo'lgan identifikatorlarni yaratish va boshqarish imkoniyatini beradi.
        //Bu identifikatorlar ko'pincha ma'lumotlar bazasida, tizimlar orasida yoki turli jarayonlar uchun identifikator sifatida ishlatiladi.
        public Guid Id { get; set; }

        //[AllowNull] atributi .NETda, xususan, C#da, nullable referens tiplari bilan ishlashda qo‘llaniladi
        //va Nullable Reference Types (NRT) xususiyati yordamida null qiymatlar bilan
        //bog‘liq xatolarni boshqarishda yordam beradi. 
        [AllowNull]
        public DateTime CreateDate {  get; set; } = DateTime.Now;

        [AllowNull]
        public DateTime UpdateDate { get; set; } 

        [AllowNull]
        public Guid? CreatedBy { get; set; }

        [AllowNull]
        public Guid? UpdatedBy { get;set; }


        public bool IsDeleted { get; set; }=false;
    }
}
