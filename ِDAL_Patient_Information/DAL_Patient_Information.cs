using _DAL_Patient_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_ProgDental;

namespace DAL_Prog_Dental
{
    
    
   public class DAL_Patient_Information
    {
        //CRUD : Create - Read - Update - Delete
        DB_Support DB = new DB_Support();


        public string Create(PatientInfo BE)
        {//ایجاد شی در بانک اطلاعاتی
            if (!Read(BE))
            {
                if (BE.HCode.ToString().Length == 10)
                {
                    DB.PatientInfos.Add(BE);
                    DB.SaveChanges();
                    return "ثبت اطلاعات با موفقیت انجام شد";
                }
                else
                {
                    return "کد ملی نامعتبر است لطفا دوباره چک کنید";
                }
            }
            else
            {
                return "اطلاعات وارد شده تکراری است";
            }
        }

        public  bool Read(PatientInfo BE)
        {
            return DB.PatientInfos.Any(i => i.NParvandeh == BE.NParvandeh || i.HCode == BE.HCode);
        }

        public List<PatientInfo> Read (string Name)
        {
            return DB.PatientInfos.Where(i => i.Name.Contains(Name)).ToList();
        }

        public PatientInfo Read(int id)
        {
            var q= DB.PatientInfos.Where(i => i.Id == id);
            if (q.Count() == 1)
            {
                return q.Single();
            }
            return null;
        }

        public List<PatientInfo> Read()
        {
            return DB.PatientInfos.ToList();
        }

        public string Update(int id,PatientInfo BENew)
        {
            PatientInfo BE = new PatientInfo();

            BE = Read(id);

            BE.Name = BENew.Name;
            BE.HCode = BENew.HCode;
            BE.FatherName = BENew.FatherName;
            BE.TimeEnter = BENew.TimeEnter;
            BE.PatientProblem = BENew.PatientProblem;
            BE.NParvandeh = BENew.NParvandeh;
            BE.PhoneNumber = BENew.PhoneNumber;
            BE.Moaref = BENew.Moaref;
            BE.Jop = BENew.Jop;
            BE.GroupBload = BENew.GroupBload;
            BE.Tahsilat = BENew.Tahsilat;

            DB.SaveChanges();
            return "بروزرسانی با موفقیت انجام شد";
        }

        public string Delete(int id)
        {
            PatientInfo BE = Read(id);
            DB.PatientInfos.Remove(BE);
            DB.SaveChanges();
            return "حدف با موفقیت انجام شد ";
        }

    }
}
