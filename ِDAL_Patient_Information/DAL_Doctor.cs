using System.Collections.Generic;
using System.Linq;
using BE_ProgDental;

namespace DAL_Prog_Dental
{
    public class DAL_Doctor
    {
        private readonly DB_Support db = new DB_Support();
        //create-read-update-delete

        public string Create(Doctor doc)
        {
            if (!Read(doc))
            {
                if (doc.NezamPezeshki.ToString().Length == 5)
                {
                    db.Doctors.Add(doc);
                    db.SaveChanges();
                    return "ثبت اطلاعات با موفقیت انجام شد";
                }
                else
                {
                    return "شماره نظام پزشکی اشتباه است";
                }
            }
            else
            {
                return "اطلاعات وارد شده تکراری است";
            }
        }

        public bool Read(Doctor doc)
        {
            return db.Doctors.Any(i => i.NezamPezeshki == doc.NezamPezeshki);
        }

        public List<Doctor> Read(string name)
        {
            return db.Doctors.Where(i => i.Name.Contains(name)).ToList();
        }

        public Doctor Read(int id)
        {
            var q = db.Doctors.Where(i => i.Id == id);
            return q.Count() == 1 ? q.Single() : null;
        }

        public List<Doctor> Read()
        {
            return db.Doctors.ToList();
        }

        public string Update(Doctor DocNew, int id)
        {
            Doctor doc = Read(id);
            doc.Name = DocNew.Name;
            doc.NezamPezeshki = DocNew.NezamPezeshki;
            doc.Takhasos = DocNew.Takhasos;
            doc.Univercity = DocNew.Univercity;
            doc.Age = DocNew.Age;
            doc.Phone = DocNew.Phone;
            doc.Address = DocNew.Address;
            //doc.PictureAddress = DocNew.PictureAddress;
            doc.Darsad = DocNew.Darsad;
            db.SaveChanges();
            return "بروزرسانی اطلاعات با موفقیت انجام شد";
        }

        public string Delete(int id)
        {
            Doctor doc = Read(id);
            db.Doctors.Remove(doc);
            db.SaveChanges();
            return "حذف اطلاعات با موفقیت انجام شد";
        }
    }
}
