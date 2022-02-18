using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace prog_dental
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Patient_information information = new Patient_information();
            AddUserControl(information);
            //panel2.Controls.Add(information);
        }


        private void MoveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            imgslide.Location = new Point(b.Location.X + 18, b.Location.Y - 19);
            imgslide.SendToBack();
        }
        private void Guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            MoveImageBox(sender);
        }

        private void Guna2Button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void AddUserControl(UserControl UC)
        {
            panel2.Controls.Clear();
            UC.Dock = DockStyle.Fill;
            UC.BringToFront();
            panel2.Controls.Add(UC);

        }



        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            Patient_information information = new Patient_information();
            AddUserControl(information);
            //panel2.Controls.Clear();
            //panel2.Controls.Add(information);
        }

        private void Guna2Button3_Click(object sender, EventArgs e)
        {
            UIDoctor doctor = new UIDoctor();
            AddUserControl(doctor);
        }

        private void Guna2Button1_CheckedChanged_1(object sender, EventArgs e)
        {
            MoveImageBox(sender);
        }

        private void Guna2Button4_Click(object sender, EventArgs e)
        {
            UIVisit visit = new UIVisit();
            AddUserControl(visit);
        }

        private void Guna2Button6_Click(object sender, EventArgs e)
        {
            //UISetting setting = new UISetting();
            //AddUserControl(setting);
        }

        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            AddUserControl(report);
        }
    }
}
