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

        BLL_User BLL = new BLL_User();
        int id;
        bool flag = true;

        async Task SetDataGrid()
        {
            //بروزرسانی دیتاگرید
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = BLL.Read();
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

        async Task Clear()
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


        private async void Guna2GradientButton1_Click(object sender, EventArgs e)
        {
            var a = groupBox1.Controls.OfType<TextBoxX>().Any(i => i.Text == "");
            if (a || textBoxX2.TextLength != 10)
            {
                MessageBox.Show("لطفا ابتدا اطلاعات را تکمیل کنید");
            }
            else
            {
                if (await CheakCodeMelli(textBoxX2.Text))
                {
                    User BE = new User
                    {
                        Name = textBoxX1.Text,
                        CodeMelli_Id = int.Parse(textBoxX2.Text),
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
                else
                {
                    MessageBox.Show("کد ملی نامعتبر است لطفا دوباره چک کنید");
                }
            }
        }

        //برسی صحت کد ملی
        async Task<bool> CheakCodeMelli(string codeMelli)
        {
            char[] chArray = codeMelli.ToCharArray();
            int[] numArray = new int[chArray.Length];
            for (int i = 0; i < chArray.Length; i++)
            {
                numArray[i] = (int)char.GetNumericValue(chArray[i]);
            }
            int num2 = numArray[9];
            switch (codeMelli)
            {
                case "0000000000":
                case "1111111111":
                case "22222222222":
                case "33333333333":
                case "4444444444":
                case "5555555555":
                case "6666666666":
                case "7777777777":
                case "8888888888":
                case "9999999999":
                    MessageBox.Show("کد ملی وارد شده صحیح نمی باشد");
                    break;
            }
            int num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
            int num4 = num3 - ((num3 / 11) * 11);
            if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User BE = BLL.Read(id);
            textBoxX1.Text = BE.Name;
            textBoxX2.Text = BE.CodeMelli_Id.ToString();
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
            dataGridViewX1.Columns["CodeMelli_Id"].HeaderText = "کدملی";
            dataGridViewX1.Columns["PhoneNumber"].HeaderText = "تلفن";
            dataGridViewX1.Columns["GroupBload"].HeaderText = "گروه خونی";
            dataGridViewX1.Columns["TimeEnter"].HeaderText = "تاریخ مراجعه اولیه";
            dataGridViewX1.Columns["FatherName"].HeaderText = "نام پدر";
            dataGridViewX1.Columns["Moaref"].HeaderText = "معرف";
            dataGridViewX1.Columns["Jop"].HeaderText = "شغل";
            dataGridViewX1.Columns["Tahsilat"].HeaderText = "تحصیلات";
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
            id = Convert.ToInt32(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["CodeMelli_Id"].Value);
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
