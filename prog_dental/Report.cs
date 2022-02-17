using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_Prog_Dental;
using BE_ProgDental;

namespace prog_dental
{
    public partial class Report : UserControl
    {
        public Report()
        {
            InitializeComponent();
        }

        BLL_Report blr = new BLL_Report();
        int id;
        int di;

        private void TextBoxX5_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX2.DataSource = null;
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = blr.Read(textBoxX5.Text);
            dataGridViewX1.Columns["Name"].HeaderText = "نام و نام خانوادگی";
            dataGridViewX1.Columns["CodeMelli_Id"].HeaderText = "کدملی";
            dataGridViewX1.Columns["PhoneNumber"].HeaderText = "تلفن";
            dataGridViewX1.Columns["GroupBload"].HeaderText = "گروه خونی";
            dataGridViewX1.Columns["TimeEnter"].HeaderText = "تاریخ مراجعه اولیه";
            dataGridViewX1.Columns["FatherName"].HeaderText = "نام پدر";
            dataGridViewX1.Columns["Moaref"].HeaderText = "معرف";
            dataGridViewX1.Columns["Jop"].HeaderText = "شغل";
            dataGridViewX1.Columns["Tahsilat"].HeaderText = "تحصیلات";
        }

        private void DataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["id"].Value);

        }

        private void DataGridViewX1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void نمایشاطلاعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User pi = blr.Read(id);
            labelX13.Text = pi.Name;
            labelX14.Text = pi.CodeMelli_Id.ToString();
            labelX19.Text = pi.TimeEnter;
            labelX15.Text = pi.FatherName;
            labelX16.Text = pi.PhoneNumber;
            labelX17.Text = pi.Moaref;
            labelX18.Text = pi.Jop;
            labelX21.Text = pi.GroupBload;
            labelX22.Text = pi.Tahsilat;

            dataGridViewX2.DataSource = null;
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = blr.Readn(pi.Name);
            guna2GradientButton1.Enabled = true;
            dataGridViewX1.Columns["Id"].HeaderText = "ردیف";
            dataGridViewX1.Columns["NameBimar"].HeaderText = "نام بیمار";
            dataGridViewX1.Columns["MoshkelBimar"].HeaderText = "علت مراجعه";
            dataGridViewX1.Columns["Bimeh"].HeaderText = "نوع بیمه";
            dataGridViewX1.Columns["DoctorName"].HeaderText = "پزشک معالج";
            dataGridViewX1.Columns["HazineVisit"].HeaderText = "مبلغ پرداختی";
            dataGridViewX1.Columns["ZamanVisit"].HeaderText = "زمان مراجعه";
            dataGridViewX1.Columns["HazineKol"].HeaderText = "هزینه کل";
        }

        private void Guna2GradientButton1_Click(object sender, EventArgs e)
        {
            stiReport2.Dictionary.Variables["Name"].Value = labelX13.Text;
            stiReport2.Dictionary.Variables["CodeMelli_Id"].Value = labelX14.Text;
            stiReport2.Dictionary.Variables["FatherName"].Value = labelX15.Text;
            stiReport2.Dictionary.Variables["PhoneNumber"].Value = labelX16.Text;
            stiReport2.Dictionary.Variables["Moaref"].Value = labelX17.Text;
            stiReport2.Dictionary.Variables["Jop"].Value = labelX18.Text;
            stiReport2.Dictionary.Variables["GroupBload"].Value = labelX21.Text;
            stiReport2.Dictionary.Variables["Tahsilat"].Value = labelX22.Text;
            stiReport2.Dictionary.Variables["TimeEnter"].Value = labelX19.Text;

            stiReport2.RegBusinessObject("PatientVisitReport", dataGridViewX1.DataSource);

            stiReport2.Render();
            stiReport2.Show();

            guna2GradientButton1.Enabled = false;
        }

        private void DataGridViewX2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void DataGridViewX2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            di = Convert.ToInt32(dataGridViewX2.Rows[dataGridViewX2.CurrentRow.Index].Cells["id"].Value);

        }

        private void TextBoxX1_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX2.DataSource = null;
            dataGridViewX2.DataSource = blr.Readdoc(textBoxX1.Text);
            dataGridViewX2.Columns["Name"].HeaderText = "نام و نام خانوادگی";
            dataGridViewX2.Columns["NezamPezeshki_Id"].HeaderText = "کدنظام پزشکی";
            dataGridViewX2.Columns["Takhasos"].HeaderText = "تخصص";
            dataGridViewX2.Columns["Phone"].HeaderText = "تلفن تماس";
            dataGridViewX2.Columns["Univercity"].HeaderText = "دانشگاه";
            dataGridViewX2.Columns["Age"].HeaderText = "تعداد سال خدمت";
            dataGridViewX2.Columns["Darsad"].HeaderText = "درصد دریافتی";
            dataGridViewX2.Columns["Address"].HeaderText = "آدرس";
            dataGridViewX2.Columns["PictureAddress"].HeaderText = "محل ذخیره تصویر";
        }

        private void نمایشاطاعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Doctor doc = blr.Readdoc(di);
            labelX31.Text = doc.Name;
            labelX30.Text = doc.NezamPezeshki_Id.ToString();
            labelX29.Text = doc.Takhasos;
            labelX26.Text = doc.Age.ToString();
            labelX25.Text = doc.Phone;
            labelX23.Text = doc.Address;
            labelX24.Text = doc.Darsad;
            labelX27.Text = doc.Univercity;
            labelX28.Text = doc.PictureAddress;

            dataGridViewX1.DataSource = null;
            dataGridViewX2.DataSource = null;
            dataGridViewX2.DataSource = blr.Readd(doc.Name);
            guna2GradientButton2.Enabled = true;
            dataGridViewX2.Columns["Id"].HeaderText = "ردیف";
            dataGridViewX2.Columns["NameBimar"].HeaderText = "نام بیمار";
            dataGridViewX2.Columns["MoshkelBimar"].HeaderText = "علت مراجعه";
            dataGridViewX2.Columns["Bimeh"].HeaderText = "نوع بیمه";
            dataGridViewX2.Columns["DoctorName"].HeaderText = "پزشک معالج";
            dataGridViewX2.Columns["HazineVisit"].HeaderText = "مبلغ پرداختی";
            dataGridViewX2.Columns["ZamanVisit"].HeaderText = "زمان مراجعه";
            dataGridViewX2.Columns["HazineKol"].HeaderText = "هزینه کل";
        }

        private void Guna2GradientButton2_Click(object sender, EventArgs e)
        {
            stiReport3.Dictionary.Variables["NezamPezeshki_Id"].Value = labelX30.Text;
            stiReport3.Dictionary.Variables["Name"].Value = labelX31.Text;
            stiReport3.Dictionary.Variables["Takhasos"].Value = labelX29.Text;
            stiReport3.Dictionary.Variables["Univercity"].Value = labelX27.Text;
            stiReport3.Dictionary.Variables["Age"].Value = labelX26.Text;
            stiReport3.Dictionary.Variables["Phone"].Value = labelX25.Text;
            stiReport3.Dictionary.Variables["Address"].Value = labelX23.Text;
            stiReport3.Dictionary.Variables["darsad"].Value = labelX24.Text;
            //stiReport3.Dictionary.Variables["DoctorImage"].Value = labelX28.Text;

            stiReport3.RegBusinessObject("DoctorVisitReport", dataGridViewX2.DataSource);
            //stiReport3.Compile();
            stiReport3.Render();
            stiReport3.Show();

            guna2GradientButton2.Enabled = false;
        }
    }
}
