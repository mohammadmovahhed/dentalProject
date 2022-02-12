using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _ِDAL_Patient_Information;
using BE_ProgDental;

namespace BLL_Prog_Dental
{
    public class BLL_Login
    {
        DAL_Login dall = new DAL_Login();
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