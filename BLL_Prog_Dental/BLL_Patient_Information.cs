using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_ProgDental;
using DAL_Prog_Dental;

namespace BLL_Prog_Dental
{
    public class BLL_Patient_Information
    {
        DAL_Patient_Information DAL = new DAL_Patient_Information();


        public string Create(PatientInfo BE)
        {
                    return DAL.Create(BE);
        }

       
        public List<PatientInfo>Read(string Name)
        {
            return DAL.Read(Name);
        }

        public PatientInfo Read(int ID)
        {
            return DAL.Read(ID);
        }

        public List<PatientInfo> Read()
        {
            return DAL.Read();
        }

        public string Update(int id, PatientInfo BENew)
        {
            return DAL.Update(id, BENew);
        }

        public string Delete(int id)
        {
            return DAL.Delete(id);
        }
    }
}
