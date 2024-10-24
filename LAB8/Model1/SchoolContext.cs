using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LAB8.Model1
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("name=SchoolContext")
        {
        }

        public virtual DbSet<Students> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}