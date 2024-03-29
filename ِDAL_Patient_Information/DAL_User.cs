﻿using System.Collections.Generic;
using System.Linq;
using BE_ProgDental;

namespace DAL_Prog_Dental
{
    public class DAL_User
    {
        //CRUD : Create - Read - Update - Delete
        private readonly DB_Support DB = new DB_Support();

        public string Create(User BE)
        {//ایجاد شی در بانک اطلاعاتی
            if (!Read(BE))
            {
                DB.Users.Add(BE);
                DB.SaveChanges();
                return "ثبت اطلاعات با موفقیت انجام شد";
            }
            else
            {
                return "اطلاعات وارد شده تکراری است";
            }
        }

        public bool Read(User BE)
        {
            return DB.Users.Any(i => i.CodeMelli == BE.CodeMelli);
        }

        public List<User> Read(string Name)
        {
            return DB.Users.Where(i => i.Name.Contains(Name)).ToList();
        }

        public User Read(int id)
        {
            var q = DB.Users.Where(i => i.Id == id);
            return q.Count() == 1 ? q.Single() : null;
        }

        public List<User> Read()
        {
            return DB.Users.ToList();
        }
                
        public string Update(int id, User BENew)
        {            
            User BE = Read(id);
            BE.Name = BENew.Name;
            BE.CodeMelli = BENew.CodeMelli;
            BE.FatherName = BENew.FatherName;
            BE.TimeEnter = BENew.TimeEnter;
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
            User BE = Read(id);
            DB.Users.Remove(BE);
            DB.SaveChanges();
            return "حدف با موفقیت انجام شد ";
        }

    }
}
