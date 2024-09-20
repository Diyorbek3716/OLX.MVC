using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Identity
{
    public static class IdentityModule
    {
        // IServiceCollection Servise deskriptorlari to'plami uchun shartnomani belgilaydi.
        //Xizmat deskriptorlari to'plami dastur arxitekturasini aniq belgilab beradi, xizmatlar va ularning xususiyatlari o'rtasida mantiqiy bog'lanish yaratadi.
        //Bu dastur tuzilishini yaxshilaydi va o'zgarishlarni boshqarishni osonlashtiradi.

        // IConfiguration  Kalit/qiymat ilovasi konfiguratsiya xususiyatlari to‘plamini ifodalaydi.
        // interfeys IConfigurationbarcha konfiguratsiya manbalarining yagona ko'rinishidir:
        //U barcha konfiguratsiya manbalarini yagona interfeys orqali boshqarishga imkon beradi.
        //Konfiguratsiya faqat o‘qish uchun mo‘ljallangan va konfiguratsiya namunasi dasturiy jihatdan yozish uchun mo‘ljallanmagan. 
        public static IServiceCollection RegesterIdentityModule(this IServiceCollection services, IConfiguration configuration )
        {
            services.AddDbContext<HotelProjectIdentityDBContext>(option =>
            {
                option.UseNpgsql(configuration.GetConnectionString("PostgresConnectionString"), opt=>
                opt.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));   
            });


            return services;
        }
    }
}
