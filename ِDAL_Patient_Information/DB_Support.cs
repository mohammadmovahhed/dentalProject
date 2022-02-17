using System.Data.Entity;
using BE_ProgDental;
using System.Data.Entity.Infrastructure;

namespace DAL_Prog_Dental
{
    public class DB_Support : DbContext
    {
        public DB_Support() : base("name=constr1") 
        {
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
}
