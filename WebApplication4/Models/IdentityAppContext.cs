using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class IdentityAppContext :IdentityDbContext<AppUser, AppRole, Guid>
    {
        public IdentityAppContext(DbContextOptions<IdentityAppContext> options): base(options)
        {

        }
    }
}
