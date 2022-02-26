using System;
using System.Windows.Forms;
using BLL_Prog_Dental;
using BE_ProgDental;
using System.Threading.Tasks;
using DevComponents.DotNetBar.Controls;
using System.Linq;

namespace prog_dental
{
    public partial class Patient_information : UserControl
    {
        public Patient_information()
        {
            InitializeComponent();
        }

        private readonly BLL_User BLL = new BLL_User();
        private int id;
        private bool flag = true;

        async Task SetDataGrid()
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
            dataGridViewX1.Columns["Id"].Visible = false;
            //dataGridViewX1.Columns["Visits"].Visible = false;
        }

        async Task Clear()
        {
            //پاکسازی تکست باکس ها
            foreach (var item in groupBox1.Controls)
            {
                if (item.GetType().ToString() == "DevComponents.DotNetBar.Controls.TextBoxX")
                {
                    (item as TextBox).Text = "";
                }
            }
        }


        private async void Guna2GradientButton1_Click(object sender, EventArgs e)
        {
            bool a = groupBox1.Controls.OfType<TextBoxX>().Any(i => i.Text == "");
            if (a || textBoxX2.TextLength != 10)
            {
                MessageBox.Show("لطفا ابتدا اطلاعات را تکمیل کنید");
            }
            else
            {
                User BE = new User
                {
                    Name = textBoxX1.Text,
                    CodeMelli = textBoxX2.Text,
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
                await SetDataGrid();
                await Clear();
            }
        }



        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User BE = BLL.Read(id);
            textBoxX1.Text = BE.Name;
            textBoxX2.Text = BE.CodeMelli;
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

        private async void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLL.Delete(id);
            await SetDataGrid();
        }

        private async void Patient_information_Load(object sender, EventArgs e)
        {
            await SetDataGrid();
        }

        private void TextBoxX5_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = BLL.Read(textBoxX5.Text);
            dataGridViewX1.Columns["Name"].HeaderText = "نام و نام خانوادگی";
            dataGridViewX1.Columns["CodeMelli"].HeaderText = "کدملی";
            dataGridViewX1.Columns["PhoneNumber"].HeaderText = "تلفن";
            dataGridViewX1.Columns["GroupBload"].HeaderText = "گروه خونی";
            dataGridViewX1.Columns["TimeEnter"].HeaderText = "تاریخ مراجعه اولیه";
            dataGridViewX1.Columns["FatherName"].HeaderText = "نام پدر";
            dataGridViewX1.Columns["Moaref"].HeaderText = "معرف";
            dataGridViewX1.Columns["Jop"].HeaderText = "شغل";
            dataGridViewX1.Columns["Tahsilat"].HeaderText = "تحصیلات";
            dataGridViewX1.Columns["Id"].Visible = false;
            //dataGridViewX1.Columns["Visits"].Visible = false;
        }

        private void TextBoxX2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar) && (e.KeyChar == '.')))
            {
                e.Handled = true;
                MessageBox.Show("لطفا فقط عدد وارد کنید");
            }
        }

        private void DataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["Id"].Value);
        }

        private void DataGridViewX1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }
    }
}
