using HotelProject.Core.AccessConfigurations;
using HotelProject.Identity.ClaimsPrincipalFactory;
using HotelProject.Identity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
                //UseNpgsql Ilovangizda PostgreSQL uchun kerakli parametrlarni o'rnatish imkonini beradi, masalan, ulanish satrini va boshqa parametrlarni.
                //GetConnectionString Ulanish satrini odatda appsettings.json yoki boshqa konfiguratsiya fayllaridan o'qiydi, bu esa dasturiy ta'minotni konfiguratsiyani oson yangilash imkonini beradi.
                //MigrationsAssembly bu Entity Framework Core’da migratsiyalarni saqlash uchun maxsus yig'ish (assembly) ni belgilash imkonini beruvchi parametr.
                //Assembly.GetExecutingAssembly().FullName) bu hozirgi bajarilayotgan yig'ish (assembly) haqidagi ma'lumotlarni olish uchun ishlatiladigan kod. Asosan, bu metod quyidagi vazifalarni bajaradi:
                option.UseNpgsql(configuration.GetConnectionString("PostgresConnectionString"), opt=>
                opt.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));   
            });

            services.AddIdentity<User, Role>(option =>
            {
                option.Password.RequiredLength = 8;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireUppercase = false;
            }).AddRoles<Role>()
            .AddUserManager<UserManager<User>>()
            .AddRoleManager<RoleManager<Role>>()
            .AddEntityFrameworkStores<HotelProjectIdentityDBContext>()
            .AddClaimsPrincipalFactory<HotelProjectClaimPrincipalFactory>();


            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(option =>
            { 
                option.SaveToken=true;
                option.RequireHttpsMetadata=true;
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["AccessConfiguration:Audience"],
                    ValidIssuer = configuration["AccessConfiguration:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey.TheSecretKey))
                };

            });

            using var provider = services.BuildServiceProvider();
            //sms tokenlar bilan ishlar

            var dbcontext= provider.GetService<HotelProjectIdentityDBContext>();
            dbcontext?.Database.Migrate();

            return services;
        }
    }
}
