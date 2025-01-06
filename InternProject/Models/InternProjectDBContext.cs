using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternProject.Models
{
    public class InternProjectDBContext : DbContext
    {
        public InternProjectDBContext(DbContextOptions<InternProjectDBContext> options) 
            : base(options)
        {

        }
        public DbSet<tblSkill> tblSkills { get; set; }
        public DbSet<tblEmployee> tblEmployees { get; set; }
    }
}
