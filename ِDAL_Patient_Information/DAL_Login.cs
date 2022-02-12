using System.Linq;
using BE_ProgDental;

namespace DAL_Prog_Dental
{
    public class DAL_Login
    {
        DB_Support dbl = new DB_Support();
        public byte Login(string username, string password)
        {
            DB_Support dbl = new DB_Support();
            if (dbl.Logins.Count() == 0)
            {
                return 0;
            }
            else
            {
                if (dbl.Logins.Any(i => i.UserName == username && i.Password == password)) 
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }

        public void Register(Login user)
        {
            dbl.Logins.Add(user);
            dbl.SaveChanges();
        }
    }
}
