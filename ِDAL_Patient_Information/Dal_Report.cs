using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _DAL_Patient_Information;
using BE_ProgDental;


namespace _ِDAL_Patient_Information
{
  public  class Dal_Report
    {
        DB_Support db = new DB_Support();
        public List<PatientInfo> Read(string patientss)
        {
            return db.PatientInfos.Where(i => i.Name.Contains(patientss) || i.HCode.Contains(patientss)).ToList();
        }

       public PatientInfo Read(int id)
        {
            var q = db.PatientInfos.Where(i => i.Id == id);
            if (q.Count() ==1)
            {
                return q.Single();
            }
            return null;
        }


        public List<Visit> Readn(string name)
        {
            return db.Visits.Where(i => i.NameBimar.Contains(name)).ToList();
        }

        public List<Visit> Readd(string name)
        {
            return db.Visits.Where(i => i.DoctorName.Contains(name)).ToList();
        }

        public List<Doctor> Readdoc(string doctor)
        {
            return db.Doctors.Where(i => i.Name.Contains(doctor) || i.NezamPezeshki.Contains(doctor)).ToList(); 
        }

        public Doctor Readdoc(int di)
        {
            var q = db.Doctors.Where(i => i.Id == di);
            if (q.Count() == 1) 
            {
                return q.Single();
            }
            return null;
        }
    }
}
