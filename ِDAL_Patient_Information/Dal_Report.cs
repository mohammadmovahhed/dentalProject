﻿using System.Collections.Generic;
using System.Linq;
using BE_ProgDental;


namespace DAL_Prog_Dental
{
    public class Dal_Report
    {
        private readonly DB_Support db = new DB_Support();
        public List<User> Read(string patientss)
        {
            return db.Users.Where(i => i.Name.Contains(patientss) || i.CodeMelli.Contains(patientss)).ToList();
        }

        public User Read(int id)
        {
            var q = db.Users.Where(i => i.Id == id);
            return q.Count() == 1 ? q.Single() : null;
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
            return db.Doctors.Where(i => i.Name.Contains(doctor) || i.NezamPezeshki.ToString().Contains(doctor)).ToList();
        }

        public Doctor Readdoc(int di)
        {
            var q = db.Doctors.Where(i => i.Id == di);
            return q.Count() == 1 ? q.Single() : null;
        }
    }
}
