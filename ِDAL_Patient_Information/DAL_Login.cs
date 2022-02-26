using System.Linq;
using BE_ProgDental;

namespace DAL_Prog_Dental
{
    public class DAL_Login
    {
         private readonly DB_Support dbl = new DB_Support();
        public byte Login(string username, string password)
        {
            return dbl.Logins.Count() == 0 ? (byte)0 : dbl.Logins.Any(i => i.UserName == username && i.Password == password) ? (byte)1 : (byte)2;
        }

        public void Register(Login user)
        {
            dbl.Logins.Add(user);
            dbl.SaveChanges();
        }
    }
}
