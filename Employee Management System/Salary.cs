using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Employee_Management_System
{
    public partial class Salary : UserControl
    {
        DB con = new DB();
        public Salary()
        {
            InitializeComponent();
        }

        private void Salary_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string select = "select EmployeeName,Position from Emp where Id='" + txtEId.Text + "'";
            SqlCommand cmd = new SqlCommand(select, con.GetCon());
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                label4.Text = dr["EmployeeName"].ToString();
                label5.Text = dr["Position"].ToString();
            }
        }
        int Daily,total;

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("********Employee Salary Detail********", new Font("Time New Roman", 22, FontStyle.Bold), Brushes.Maroon, new Point(200));
            e.Graphics.DrawString("EmployeeName:" + label4.Text + "\t\tPosition:" + label5.Text, new Font("Time New Roman", 16, FontStyle.Bold), Brushes.Maroon, new Point(10, 100));
            e.Graphics.DrawString("WorkDays:" + txtWork.Text + "\t\tDaily:" + Daily+"\t\tTotal:"+total, new Font("Time New Roman", 16, FontStyle.Bold), Brushes.Maroon, new Point(10, 200));
            e.Graphics.DrawString("**********Detail**********", new Font("Time New Roman", 22, FontStyle.Bold), Brushes.Maroon, new Point(200, 300));
        }

        private void txtTotal_Click(object sender, EventArgs e)
        {
            if (txtWork.Text == "")
            {
                MessageBox.Show("Missing Information");

            }else if (Convert.ToInt32(txtWork.Text)>28)
            {
                MessageBox.Show("Enter Valid Days");
            }
            else
            {
                if(label5.Text== "FrontEnd Developer")
                {
                    Daily = 7000;
                }else if(label5.Text== "BackEnd Developer")
                {
                    Daily = 10000;
                }else if(label5.Text== "FullStack Developer")
                {
                    Daily = 15000;
                }
                else
                {
                    Daily = 3500;
                }

               total = Daily * Convert.ToInt32(txtWork.Text);
                txtSa.Text = "EmployeeName:"+label4.Text + "\n"+"Position:" +label5.Text + "\n" +"WorkDays:"+ txtWork.Text + "\n" + Daily + "\n" + total;
            }
        }
    }
}



