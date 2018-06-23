﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ExamWork.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
    //ApplicationDbContext
    public class MovieContext : IdentityDbContext<ApplicationUser>
    {
        public MovieContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static MovieContext Create()
        {
            return new MovieContext();
        }
    }
}