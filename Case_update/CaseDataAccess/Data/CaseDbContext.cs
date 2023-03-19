using CaseModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseDataAccess.Data
{
    public class CaseDbContext : IdentityDbContext<ApplicationUser>
    {
        public CaseDbContext(DbContextOptions<CaseDbContext> options) : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
