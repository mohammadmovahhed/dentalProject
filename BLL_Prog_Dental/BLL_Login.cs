using DAL_Prog_Dental;
using BE_ProgDental;

namespace BLL_Prog_Dental
{
    public class BLL_Login
    {
        private readonly DAL_Login dall = new DAL_Login();
        public byte Login(string username, string password)
        {
            return dall.Login(username, password);
        }
        public void Register(Login user)
        {
            dall.Register(user);
        }
    }
}