using CalisanBilgi.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalisanBilgi
{
    public partial class Form1 : Form
    {
        EmployeeOperations employeeOperations = new EmployeeOperations();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource= employeeOperations.GetEmployeeTable();
            panel1.Visible = false;
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel1.Visible = true;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dataGridView1.Visible = true;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel1.Visible = true;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel1.Visible = true;
        }
    }
}
