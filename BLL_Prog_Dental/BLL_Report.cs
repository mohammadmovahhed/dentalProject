using System.Collections.Generic;
using DAL_Prog_Dental;
using BE_ProgDental;

namespace BLL_Prog_Dental
{
    public class BLL_Report
    {
        Dal_Report dbr = new Dal_Report();

        public List<User> Read(string patientss)
        {
            return dbr.Read(patientss);
        }


        public User Read(int id)
        {
            return dbr.Read(id);
        }

        public List<Visit> Readn(string name)
        {
            return dbr.Readn(name);
        }

        public List<Visit> Readd(string name)
        {
            return dbr.Readd(name);
        }

        public List<Doctor> Readdoc(string doctor)
        {
            return dbr.Readdoc(doctor);
        }

        public Doctor Readdoc(int di)
        {
            return dbr.Readdoc(di);
        }
    }
}
