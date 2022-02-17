using System;
using System.Windows.Forms;
using BLL_Prog_Dental;
using BE_ProgDental;

namespace prog_dental
{
    public partial class Patient_information : UserControl
    {
        public Patient_information()
        {
            InitializeComponent();
        }

        BLL_User BLL = new BLL_User();
        int id;
        bool flag = true;

        void SetDataGrid()
        {
            //بروزرسانی دیتاگرید
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = BLL.Read();
            dataGridViewX1.Columns["Name"].HeaderText = "نام و نام خانوادگی";
            dataGridViewX1.Columns["CodeMelli"].HeaderText = "کدملی";
            dataGridViewX1.Columns["PhoneNumber"].HeaderText = "تلفن";
            dataGridViewX1.Columns["GroupBload"].HeaderText = "گروه خونی";
            dataGridViewX1.Columns["TimeEnter"].HeaderText = "تاریخ مراجعه اولیه";
            dataGridViewX1.Columns["FatherName"].HeaderText = "نام پدر";
            dataGridViewX1.Columns["Moaref"].HeaderText = "معرف";
            dataGridViewX1.Columns["Jop"].HeaderText = "شغل";
            dataGridViewX1.Columns["Tahsilat"].HeaderText = "تحصیلات";
            dataGridViewX1.Columns["Id"].HeaderText = "ردیف";
        }

        void Clear()
        {
            //پاکسازی تکست باکس ها
            foreach (var item in Controls)
            {
                if (item.GetType().ToString() == "DevComponents.DotNetBar.Controls.TextBoxX")
                {
                    (item as TextBox).Text = "";
                }
            }
        }

        //void NumberParvandeh()
        //{
        //    //نمایش اخرین شماره پرونده بیمار 
        //    int new_NParvandeh = 0;
        //    foreach (var item in BLL.Read())
        //    {
        //        new_NParvandeh = Convert.ToInt32(item.NParvandeh);
        //    }
        //    new_NParvandeh += 1;
        //    label2.Text = new_NParvandeh.ToString();
        //}


        private void Guna2GradientButton1_Click(object sender, EventArgs e)
        {

            User BE = new User
            {
                Name = textBoxX1.Text,
                CodeMelli = int.Parse(textBoxX2.Text),
                TimeEnter = dateTimePickerX1.Text,
                FatherName = textBoxX4.Text,
                PhoneNumber = textBoxX7.Text,
                Moaref = textBoxX6.Text,
                Jop = textBoxX8.Text,
                GroupBload = comboBoxEx2.Text,
                Tahsilat = comboBoxEx3.Text
            };

            if (flag)
            {
                //Create
                MessageBox.Show(BLL.Create(BE));
            }
            else if (!flag)
            {
                //Update
                flag = true;
                guna2GradientButton1.Text = "تشکیل پرونده";
                MessageBox.Show(BLL.Update(id, BE));
            }

            SetDataGrid();
            Clear();
        }


        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User BE = BLL.Read(id);
            textBoxX1.Text = BE.Name;
            textBoxX2.Text = BE.CodeMelli.ToString();
            dateTimePickerX1.Text = BE.TimeEnter;
            textBoxX4.Text = BE.FatherName;
            textBoxX7.Text = BE.PhoneNumber;
            textBoxX6.Text = BE.Moaref;
            textBoxX8.Text = BE.Jop;
            comboBoxEx2.Text = BE.GroupBload;
            comboBoxEx3.Text = BE.Tahsilat;


            flag = false;
            guna2GradientButton1.Text = "ویرایش اطلاعات";
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLL.Delete(id);
            SetDataGrid();
        }

        private void Patient_information_Load(object sender, EventArgs e)
        {
            SetDataGrid();
        }

        private void TextBoxX5_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = BLL.Read(textBoxX5.Text);
            dataGridViewX1.Columns["Name"].HeaderText = "نام و نام خانوادگی";
            dataGridViewX1.Columns["HCode"].HeaderText = "کدملی";
            dataGridViewX1.Columns["PhoneNumber"].HeaderText = "تلفن";
            dataGridViewX1.Columns["GroupBload"].HeaderText = "گروه خونی";
            dataGridViewX1.Columns["TimeEnter"].HeaderText = "تاریخ مراجعه اولیه";
            dataGridViewX1.Columns["FatherName"].HeaderText = "نام پدر";
            dataGridViewX1.Columns["Moaref"].HeaderText = "معرف";
            dataGridViewX1.Columns["Jop"].HeaderText = "شغل";
            dataGridViewX1.Columns["Tahsilat"].HeaderText = "تحصیلات";
            dataGridViewX1.Columns["Id"].HeaderText = "ردیف";
        }

        private void TextBoxX2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar) && (e.KeyChar == '.')))
            {
                e.Handled = true;


                MessageBox.Show("لطفا فقط عدد وارد کنید");

            }
        }

        private void TextBoxX3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar) && (e.KeyChar == '.')))
            {
                e.Handled = true;


                MessageBox.Show("لطفا فقط عدد وارد کنید");

            }
        }

        private void TextBoxX7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar) && (e.KeyChar == '.')))
            {
                e.Handled = true;


                MessageBox.Show("لطفا فقط عدد وارد کنید");

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

        private void textBoxX5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar) && (e.KeyChar == '.')))
            {
                e.Handled = true;


                MessageBox.Show("لطفا فقط عدد وارد کنید");

            }
        }
    }
}
