using System.Collections.Generic;
using System.Linq;
using BE_ProgDental;

namespace DAL_Prog_Dental
{
    public class DAL_Visit
    {
        DB_Support dbs = new DB_Support();
        public List<User> ReadPatient()
        {
            return dbs.Users.ToList();
        }
        public bool ReadPatient(string IdBimar)
        {
            return dbs.Users.Any(i=> i.Id == int.Parse(IdBimar));
        }

        public List<Doctor> ReadDoctor()
        {
            return dbs.Doctors.ToList();
        }

        public List<Insurance> ReadInsurances()
        {
            return dbs.Insurances.ToList();
        }

        public string Create(Visit visitDAL)
        {
            dbs.Visits.Add(visitDAL);
            dbs.SaveChanges();
            return "ثبت اطلاعات با موفقیت انجام شد";
        }

        public List<Visit> Read()
        {
            return dbs.Visits.ToList();
        }

        public List<Visit> Read(string nameB)
        {
            return dbs.Visits.Where(i => i.NameBimar.Contains(nameB) || i.DoctorName.Contains(nameB) || i.MoshkelBimar.Contains(nameB)).ToList();
        }

        public Visit Read(int id)
        {
            var q = dbs.Visits.Where(i => i.Id == id);
            if (q.Count()==1)
            {
                return q.Single();
            }
            return null;
        }

        public string Update(int id,Visit NewNobatdehi)
        {
            Visit nobatdehi = Read(id);
            nobatdehi.NameBimar = NewNobatdehi.NameBimar;
            nobatdehi.MoshkelBimar = NewNobatdehi.MoshkelBimar;
            nobatdehi.Bimeh = NewNobatdehi.Bimeh;
            nobatdehi.DoctorName = NewNobatdehi.DoctorName;
            nobatdehi.ZamanVisit = NewNobatdehi.ZamanVisit;
            nobatdehi.HazineKol = NewNobatdehi.HazineKol;
            nobatdehi.HazineVisit = NewNobatdehi.HazineVisit;

            dbs.SaveChanges();
            return "بروزرسانی با موفقیت انجام شد";
        }

        public string Delete(int id)
        {
            Visit nDel = Read(id);
            dbs.Visits.Remove(nDel);
            dbs.SaveChanges();
            return "حدف با موفقیت انجام شد ";
        }

        
    }
}
