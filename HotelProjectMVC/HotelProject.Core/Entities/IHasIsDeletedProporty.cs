using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//ma'lum bir sinf yoki ob'ektning IsDeleted xususiyatiga ega yoki yo'qligini aniqlash uchun ishlatiladi
namespace HotelProject.Core.Entities
{
    public interface IHasIsDeletedProporty
    {
        public bool IsDeleted { get; set; }
    }
}
