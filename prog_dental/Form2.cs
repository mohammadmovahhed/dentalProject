using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_Prog_Dental;

namespace prog_dental
{
    public partial class Form2 : Form
    {

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
           (
               int nLeftRect,     // x-coordinate of upper-left corner
               int nTopRect,      // y-coordinate of upper-left corner
               int nRightRect,    // x-coordinate of lower-right corner
               int nBottomRect,   // y-coordinate of lower-right corner
               int nWidthEllipse, // width of ellipse
               int nHeightEllipse // height of ellipse
           );

        public Form2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        BLL_Login blll = new BLL_Login();
        private void Guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (blll.Login(textBoxX1.Text, textBoxX2.Text) == 1)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
            {
                label1.Text = "نام کاربری یا رمزعبور اشتباه است";
            }
        }

        private void Login_form_vertical_Load(object sender, EventArgs e)
        {
            if (blll.Login("", "") == 0)
            {
                label3.Visible = true;
            }
            else
            {
                label3.Visible = false;
            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            Register_admin register = new Register_admin();
            register.Show();
        }
    }
}
