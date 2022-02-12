using System.Collections.Generic;
using BE_ProgDental;
using DAL_Prog_Dental;

namespace BLL_Prog_Dental
{
    public class BLL_User
    {
        DAL_User DAL = new DAL_User();


        public string Create(User BE)
        {
            return DAL.Create(BE);
        }


        public List<User> Read(string Name)
        {
            return DAL.Read(Name);
        }

        public User Read(int ID)
        {
            return DAL.Read(ID);
        }

        public List<User> Read()
        {
            return DAL.Read();
        }

        public string Update(int id, User BENew)
        {
            return DAL.Update(id, BENew);
        }

        public string Delete(int id)
        {
            return DAL.Delete(id);
        }
    }
}
