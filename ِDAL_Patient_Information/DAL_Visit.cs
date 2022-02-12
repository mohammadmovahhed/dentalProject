﻿using _DAL_Patient_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_ProgDental;

namespace _ِDAL_Patient_Information
{ 
     public class DAL_Visit
    {
        DB_Support dbs = new DB_Support();
        public List<PatientInfo> ReadPatient()
        {
            return dbs.PatientInfos.ToList();
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
