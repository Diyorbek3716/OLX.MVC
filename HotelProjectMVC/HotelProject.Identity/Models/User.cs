using HotelProject.Core.Enams;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Identity.Models
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; } = GenderEnum.Unknown;
        public DateTime BrithDate { get; set; }
        public DateTime CreateDate { get; set; }= DateTime.Now;
        public string Status { get; set; } = "Active";
        public string? MobileId { get; set; } = string.Empty;
        public Guid? DistrictId { get; set; }
        public string? DistrictName { get; set; }
        public string? RegionName { get; set; }
        public User(string firstName, string lastName, string PhoneNamber)
        {
            FirstName=firstName;
            LastName=lastName;
            UserName=(firstName+lastName).ToString();
            PhoneNumber=PhoneNamber;
        }
        public User(string firstName, string lastName, string PhoneNamber,string email, GenderEnum genderEnum, DateTime brithDate)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = (firstName + lastName).ToString();
            PhoneNumber = PhoneNamber;
            Gender = genderEnum;
            Gender=genderEnum;
            BrithDate = brithDate;
        }
    }
}
