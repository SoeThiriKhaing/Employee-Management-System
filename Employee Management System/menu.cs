using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_System
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void btnEmp_Click(object sender, EventArgs e)
        {
            var emp = new Emp() { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(emp);
            emp.BringToFront();
          
            
            
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var view = new View() { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(view);
            view.BringToFront();
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            var salary = new Salary() { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(salary);
            salary.BringToFront();
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
