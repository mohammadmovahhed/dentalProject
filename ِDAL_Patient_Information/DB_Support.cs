using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BE_ProgDental;

namespace _DAL_Patient_Information
{
    public class DB_Support : DbContext
    {
        public DB_Support() : base("name=constr1") { }
        public DbSet<PatientInfo> PatientInfos { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
}
