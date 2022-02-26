using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using BE_ProgDental;
using System.IO;
using BLL_Prog_Dental;
using System.Threading.Tasks;

namespace prog_dental
{
    public partial class UIDoctor : UserControl
    {
        public UIDoctor()
        {
            InitializeComponent();
        }

        private readonly BLL_Doctor bll = new BLL_Doctor();
        private Image pic;
        private OpenFileDialog f = new OpenFileDialog();
        private bool flag = true;
        private int id;


        async Task Clear()
        {
            foreach (var item in groupBox1.Controls)
            {
                if (item.GetType().ToString() == "DevComponents.DotNetBar.Controls.TextBoxX")
                {
                    (item as TextBoxX).Text = "";
                }
            }
        }

        async Task SetDataGrid()
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = bll.Read();
            dataGridViewX1.Columns["Name"].HeaderText = "نام و نام خانوادگی";
            dataGridViewX1.Columns["NezamPezeshki"].HeaderText = "کدنظام پزشکی";
            dataGridViewX1.Columns["Takhasos"].HeaderText = "تخصص";
            dataGridViewX1.Columns["Phone"].HeaderText = "تلفن تماس";
            dataGridViewX1.Columns["Univercity"].HeaderText = "دانشگاه";
            dataGridViewX1.Columns["Age"].HeaderText = "تعداد سال های خدمت";
            dataGridViewX1.Columns["Darsad"].HeaderText = "درصد دریافتی";
            dataGridViewX1.Columns["Address"].HeaderText = "آدرس";
            dataGridViewX1.Columns["PictureAddress"].Visible = false;
            dataGridViewX1.Columns["Id"].Visible = false;
            //dataGridViewX1.Columns["Visits"].Visible = false;
        }

        string SavePic(string NezamP)
        {
            //ایجاد پوشه ای برای دخیره تصاویر در پوشه اصلی پروژه دیباگ
            string AppPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\pictures\";

            //اگر پوشه وجود نداشت بسازش
            if (Directory.Exists(AppPath) == false)
            {
                Directory.CreateDirectory(AppPath);
            }
            //اسم تصاویر را اینگونه مینویسیم کد نظام پزشکی(که از ورودی میگیریم)و فرمت تصویر
            string IName = NezamP + ".jpg";
            try
            {
                //ادرس ، نام ، عکس را بگیر و در پوشه ذخیرش کن
                string filePath = f.FileName;
                File.Copy(filePath, AppPath + IName);
                //ادرس جدید ذخیره عکس
                return AppPath + IName;
            }
            catch (Exception exp)
            {
                MessageBox.Show("امکان ذخیره فایل وجود ندارد" + exp.Message);
                return null;
            }
        }


        private async void Guna2GradientButton1_Click(object sender, EventArgs e)
        {
            bool a = groupBox1.Controls.OfType<TextBoxX>().Any(i => i.Text == "");
            if (a && SavePic(textBoxX2.Text) == null)
            {
                MessageBox.Show("لطفا ابتدا تمام اطلاعات را تکمیل کنید");
            }
            else
            {
                Doctor doc = new Doctor
                {
                    Name = textBoxX1.Text,
                    NezamPezeshki = textBoxX2.Text,
                    Takhasos = textBoxX3.Text,
                    Univercity = textBoxX4.Text,
                    Age = Convert.ToByte(textBoxX5.Text),
                    Phone = textBoxX6.Text,
                    Darsad = textBoxX9.Text,
                    Address = textBoxX7.Text,
                    //savepic فعلی است که خودمان تعریف کرده ایم
                    PictureAddress = SavePic(textBoxX2.Text)
                };

                if (flag)
                {
                    MessageBox.Show(bll.Create(doc));
                }
                else
                {
                    MessageBox.Show(bll.Update(doc, id));
                    guna2GradientButton1.Text = "ثبت دکتر";
                }

                await SetDataGrid();
                await Clear();
                flag = true;
            }
        }


        private void DataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["Id"].Value);

            Doctor doctor = bll.Read(id);
            labelX1.Text = doctor.Name;
            labelX2.Text = doctor.NezamPezeshki;
            labelX1.Visible = true;
            labelX2.Visible = true;

            if (doctor.PictureAddress != null)
            {
                guna2PictureBox1.Image = Image.FromFile(doctor.PictureAddress);
            }
        }

        private void DataGridViewX1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void Guna2PictureBox1_Click(object sender, EventArgs e)
        {
            //میگیم که فقط فایل با فرمت JPG بگیر
            f.Filter = "JPG(*JPG)|*.JPG";
            if (f.ShowDialog() == DialogResult.OK)
            {
                pic = Image.FromFile(f.FileName);
                guna2PictureBox1.Image = pic;
            }
        }


        private async void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Doctor doc = bll.Read(id);
            textBoxX1.Text = doc.Name;
            textBoxX2.Text = doc.NezamPezeshki;
            textBoxX3.Text = doc.Takhasos;
            textBoxX4.Text = doc.Univercity;
            textBoxX5.Text = Convert.ToString(doc.Age);
            textBoxX6.Text = doc.Phone;
            textBoxX7.Text = doc.Address;
            textBoxX9.Text = doc.Darsad;
            flag = false;
            guna2GradientButton1.Text = "ویرایش اطلاعات";
            await SetDataGrid();
            //Clear();
        }


        private async void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bll.Delete(id);
            await SetDataGrid();
            await Clear();
        }

        private void TextBoxX8_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = bll.Read(textBoxX8.Text);
            dataGridViewX1.Columns["Name"].HeaderText = "نام و نام خانوادگی";
            dataGridViewX1.Columns["NezamPezeshki"].HeaderText = "کدنظام پزشکی";
            dataGridViewX1.Columns["Takhasos"].HeaderText = "تخصص";
            dataGridViewX1.Columns["Phone"].HeaderText = "تلفن تماس";
            dataGridViewX1.Columns["Univercity"].HeaderText = "دانشگاه";
            dataGridViewX1.Columns["Age"].HeaderText = "تعداد سال های خدمت";
            dataGridViewX1.Columns["Darsad"].HeaderText = "درصد دریافتی";
            dataGridViewX1.Columns["Address"].HeaderText = "آدرس";
            dataGridViewX1.Columns["PictureAddress"].Visible = false;
            dataGridViewX1.Columns["Id"].Visible = false;
            //dataGridViewX1.Columns["Visits"].Visible = false;
        }

        private async void UIDoctor_Load(object sender, EventArgs e)
        {
            await SetDataGrid();
        }

        private void textBoxX2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar) && (e.KeyChar == '.')))
            {
                e.Handled = true;


                MessageBox.Show("لطفا فقط عدد وارد کنید");
            }
        }
    }
}
