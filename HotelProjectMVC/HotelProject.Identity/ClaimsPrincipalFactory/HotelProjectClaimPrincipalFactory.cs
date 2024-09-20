using HotelProject.Identity.Constants;
using HotelProject.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Identity.ClaimsPrincipalFactory
{
    public class HotelProjectClaimPrincipalFactory:UserClaimsPrincipalFactory<User>
    {
        public HotelProjectClaimPrincipalFactory(UserManager<User> userManager,IOptions<IdentityOptions> optionsAccessor
            ) : base(userManager, optionsAccessor) { }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity=await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType,user.UserName));
            identity.AddClaim(new Claim(ClaimNames.UserName,user.UserName));
            identity.AddClaim(new Claim(ClaimNames.FirstName,user.FirstName));
            identity.AddClaim(new Claim(ClaimNames.LastName,user.LastName));
            identity.AddClaim(new Claim(ClaimNames.Email,user.Email));
            identity.AddClaim(new Claim(ClaimNames.UserId, user.Id));
            
            return identity;

        }
    }
}
