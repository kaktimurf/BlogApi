﻿using Core.Entities.Concrete;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
   public static class ClaimExtansions
    {
        public static void AddEmail(this ICollection<Claim> claims,string email)
        {
            claims.Add(new Claim(ClaimTypes.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims,string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }
        public static void AddLastName(this ICollection<Claim> claims, string surname)
        {
            claims.Add(new Claim(ClaimTypes.Surname, surname));
        }

        public static void AddRoles (this ICollection<Claim> claims, string[] roles)
        {
           roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role,role)));
        }


    }
}
