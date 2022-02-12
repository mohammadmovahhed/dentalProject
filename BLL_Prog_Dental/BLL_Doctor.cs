﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Prog_Dental;
using _ِDAL_Patient_Information;
using BE_ProgDental;

namespace BLL_Prog_Dental
{
    public class BLL_Doctor
    {
        DAL_Doctor dAL = new DAL_Doctor();

        public string Create(Doctor doc)
        {
            return dAL.Create(doc);
        }

        
        public List<Doctor> Read(string name)
        {
            return dAL.Read(name);
        }

        public Doctor Read(int id)
        {
            return dAL.Read(id);
        }

        public List<Doctor> Read()
        {
            return dAL.Read();
        }

        public string Update(Doctor DocNew, int id)
        {
            return dAL.Update(DocNew, id);
        }

        public string Delete(int id)
        {
            return dAL.Delete(id);
        }
    }
}