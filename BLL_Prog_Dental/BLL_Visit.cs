using DAL_Prog_Dental;
using System.Collections.Generic;
using BE_ProgDental;

namespace BLL_Prog_Dental
{
    public class BLL_Visit
    {
        DAL_Visit dal = new DAL_Visit();
        public List<User> ReadPatient()
        {
            return dal.ReadPatient();
        }

        public bool ReadPatient(string IdBimar)
        {
            return dal.ReadPatient(IdBimar);
        }

        public List<Doctor> ReadDoctor()
        {
            return dal.ReadDoctor();
        }

        public List<Insurance> ReadInsurances()
        {
            return dal.ReadInsurances();
        }

        public string Create(Visit visitBLL)
        {
            return dal.Create(visitBLL);
        }

        public List<Visit> Read()
        {
            return dal.Read();
        }

        public List<Visit> Read(string nameB)
        {
            return dal.Read(nameB);
        }

        public Visit Read(int id)
        {
            return dal.Read(id);
        }

        public string Update(int id, Visit NewNobatdehi)
        {
            return dal.Update(id, NewNobatdehi);
        }

        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
