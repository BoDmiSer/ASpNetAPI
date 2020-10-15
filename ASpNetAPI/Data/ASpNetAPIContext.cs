using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASpNetAPI.Models;
using ASpNetAPI.Models.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ASpNetAPI.Data
{
    public class ASpNetAPIContext : IdentityDbContext<User>
    {
        public ASpNetAPIContext (DbContextOptions<ASpNetAPIContext> options)
            : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=localhost;database=tutorial;user=root;password=1234");
        //}
        public DbSet<ASpNetAPI.Models.Tutorial> Tutorial { get; set; }
    }
}
