using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using BLL_Prog_Dental;
using BE_ProgDental;

namespace prog_dental
{
    public partial class UIVisit : UserControl
    {
        public UIVisit()
        {
            InitializeComponent();
        }

        int id;
        bool flag = true;

        public void DGV()
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = bll.Read();
            dataGridViewX1.Columns["Id"].HeaderText = "ردیف";
            dataGridViewX1.Columns["NameBimar"].HeaderText = "نام بیمار";
            dataGridViewX1.Columns["MoshkelBimar"].HeaderText = "علت مراجعه";
            dataGridViewX1.Columns["Bimeh"].HeaderText = "نوع بیمه";
            dataGridViewX1.Columns["DoctorName"].HeaderText = "پزشک معالج";
            dataGridViewX1.Columns["HazineVisit"].HeaderText = "مبلغ پرداختی";
            dataGridViewX1.Columns["ZamanVisit"].HeaderText = "زمان مراجعه";
            dataGridViewX1.Columns["HazineKol"].HeaderText = "هزینه کل";
        }

        int d = 0;
        public void Darsad()
        {
            foreach (var item in bll.ReadInsurances())
            {
                if (item.NameInsurance == comboBoxEx3.Text)
                {
                    d = Convert.ToInt32(item.Darsad);
                }
            }
        }

        int VisitA;
        public void MohasebeDarsad()
        {
            int VisitB = (d * VisitA) / 100;
            int VisitC = VisitA - VisitB;
            labelX8.Text = VisitC.ToString();
        }

        public void Clear()
        {
            foreach (var item in Controls)
            {
                if (item.GetType().ToString() == "DevComponents.DotNetBar.Controls.ComboBoxEx")
                {
                    (item as ComboBoxEx).Text = "";
                }
            }
        }

        BLL_Visit bll = new BLL_Visit();
        private void Guna2GradientButton1_Click(object sender, EventArgs e)
        {
            //var b = this.Controls.OfType<ComboBoxEx>().Any(i => i.Text == "");
            //if (b || textBoxX2.Text == "")
            //{
            //    MessageBox.Show("لطفا ابتدا تمام اطلاعات را تکمیل کنید");
            //}
            //else
            //{

            //فقط برای تست است و بعدا پاک میشود
            var Quser = from i in bll.ReadPatient() where comboBoxEx1.SelectedItem == i select i;
            if (Quser.Count() !=null)
            {
                MessageBox.Show("aokdj");
            }
            //Visit visitNew = new Visit
            //{
            //    User_ID = Quser.First().Name,
            //    MoshkelBimar = comboBoxEx2.Text,
            //    Bimeh = comboBoxEx3.Text,
            //    DoctorName = comboBoxEx4.Text,
            //    ZamanVisit = dateTimePickerX1.Text,
            //    HazineKol = Convert.ToString(textBoxX2.Text),
            //    HazineVisit = Convert.ToString(labelX8.Text)
            //};
            //if (flag)
            //{
            //    MessageBox.Show(bll.Create(visitNew));
            //}
            //else if (!flag)
            //{
            //    flag = true;
            //    guna2GradientButton1.Text = "تشکیل پرونده";
            //    MessageBox.Show(bll.Update(id, visitNew));
            //}
            //DGV();
            //Clear();
            //}
        }

        private void UIVisit_Load(object sender, EventArgs e)
        {
            DGV();
        }

        private void ComboBoxEx1_DropDown(object sender, EventArgs e)
        {
            if (comboBoxEx1.Items.Count == 0)
            {
                var q = from i in bll.ReadPatient() select i;
                comboBoxEx1.DataSource = q.ToList();
                comboBoxEx1.DisplayMember = "Name";
            }
        }

        private void ComboBoxEx4_DropDown(object sender, EventArgs e)
        {
            if (comboBoxEx4.Items.Count == 0)
            {
                var q = from i in bll.ReadDoctor() select i;
                comboBoxEx4.DataSource = q.ToList();
                comboBoxEx4.DisplayMember = "Name";
            }
        }

        private void ComboBoxEx3_DropDown(object sender, EventArgs e)
        {
            if (comboBoxEx3.Items.Count == 0)
            {
                var q = from i in bll.ReadInsurances() select i;
                comboBoxEx3.DataSource = q.ToList();
                comboBoxEx3.DisplayMember = "NameInsurance";
            }
            Darsad();
        }

        private void TextBoxX2_TextChanged(object sender, EventArgs e)
        {
            Darsad();

            if (d > 0)
            {
                if (textBoxX2.Text.Length > 0)
                {
                    VisitA = Convert.ToInt32(textBoxX2.Text);
                }
                else VisitA = 0;

                MohasebeDarsad();
            }
            else
            {
                labelX8.Text = textBoxX2.Text;
            }
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

        private void TextBoxX1_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = bll.Read(textBoxX1.Text);
            dataGridViewX1.Columns["Id"].HeaderText = "ردیف";
            dataGridViewX1.Columns["NameBimar"].HeaderText = "نام بیمار";
            dataGridViewX1.Columns["MoshkelBimar"].HeaderText = "علت مراجعه";
            dataGridViewX1.Columns["Bimeh"].HeaderText = "نوع بیمه";
            dataGridViewX1.Columns["DoctorName"].HeaderText = "پزشک معالج";
            dataGridViewX1.Columns["HazineVisit"].HeaderText = "مبلغ پرداختی";
            dataGridViewX1.Columns["ZamanVisit"].HeaderText = "زمان مراجعه";
            dataGridViewX1.Columns["HazineKol"].HeaderText = "هزینه کل";
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(bll.Delete(id));
            DGV();
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visit nUP = bll.Read(id);

            comboBoxEx1.Text = nUP.NameBimar;
            comboBoxEx2.Text = nUP.MoshkelBimar;
            comboBoxEx3.Text = nUP.Bimeh;
            comboBoxEx4.Text = nUP.DoctorName;
            dateTimePickerX1.Text = nUP.ZamanVisit;
            textBoxX2.Text = nUP.HazineKol;
            labelX8.Text = nUP.HazineVisit;

            flag = false;
            guna2GradientButton1.Text = "ویرایش اطلاعات";
        }

        private void TextBoxX2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar) && (e.KeyChar == '.')))
            {
                e.Handled = true;


                MessageBox.Show("لطفا فقط عدد وارد کنید");

            }
        }

       
    }
}
