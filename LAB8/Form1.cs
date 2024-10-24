using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LAB8.Model1;

namespace LAB8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private SchoolContext context = new SchoolContext();
        private BindingSource bindingSource = new BindingSource();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadMajors();
            dgv1.CellClick += dgv1_CellClick;
            btnThoat.Click += btnThoat_Click;
        }
        private void LoadData()
        {
            bindingSource.DataSource = context.Students.ToList();
            dgv1.DataSource = bindingSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var student = new Students
            {
                FullName = txtHoten.Text,
                Age = int.Parse(txtAge.Text),
                Major = ccbMajor.SelectedItem.ToString()
            };

            context.Students.Add(student);
            context.SaveChanges();
            LoadData();
        }
        private void LoadMajors()
        {
          
            List<string> majors = new List<string>
    {
        "Công nghệ thông tin",
        "Kỹ thuật điện",
        "Kinh doanh",
        "Quản trị nhân sự",
        "Ngôn ngữ Anh"
    };

            ccbMajor.DataSource = majors;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
            if (dgv1.CurrentRow != null)
            {
                var student = (Students)dgv1.CurrentRow.DataBoundItem;
                context.Students.Remove(student);
                context.SaveChanges();
                LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentRow != null)
            {
                var student = (Students)dgv1.CurrentRow.DataBoundItem;
                student.FullName = txtHoten.Text;
                student.Age = int.Parse(txtAge.Text);
                student.Major = ccbMajor.SelectedItem.ToString();
                context.SaveChanges();
                LoadData();
            }
        }
        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv1.Rows[e.RowIndex];
                var student = (Students)row.DataBoundItem;

                
                    
                      txtHoten.Text = student.FullName;
                       txtAge.Text = student.Age.ToString();
                       ccbMajor.SelectedItem = student.Major;
                    }
                }
            
        
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (bindingSource.Position < bindingSource.Count - 1)
            {
                bindingSource.MoveNext();
                UpdateTextBoxes();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (bindingSource.Position > 0)
            {
                bindingSource.MovePrevious();
                UpdateTextBoxes();
            }
        }
        private void UpdateTextBoxes()
        {
            var student = (Students)bindingSource.Current;
            txtHoten.Text = student.FullName;
            txtAge.Text = student.Age.ToString();
            ccbMajor.SelectedItem = student.Major;
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); 
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }

