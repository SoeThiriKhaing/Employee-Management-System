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
    public partial class View : UserControl
    {
        DB con = new DB();
        public View()
        {
            InitializeComponent();
        }

        private void View_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string select = "select * from Emp where Id='" + txtEId.Text + "'";
            SqlCommand cmd = new SqlCommand(select, con.GetCon());
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                ENlabel.Text = dr["EmployeeName"].ToString();
                Dlabel.Text= dr["DOB"].ToString();
                Alabel.Text= dr["Address"].ToString();
                Plabel.Text= dr["Phno"].ToString();
                Glabel.Text= dr["Gender"].ToString();
                Elabel.Text= dr["Education"].ToString();
                Polabel.Text= dr["Position"].ToString();
            }

            
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("********Employee Detail********", new Font("Time New Roman", 22, FontStyle.Bold), Brushes.Maroon, new Point(200));
            e.Graphics.DrawString("Employee:"+ENlabel.Text+ "\tDOB:" + Dlabel.Text , new Font("Time New Roman", 16, FontStyle.Bold), Brushes.Maroon, new Point(10,100));
         
           e.Graphics.DrawString("Address:" + Alabel.Text + "\t\tPhno:" + Plabel.Text, new Font("Time New Roman", 16, FontStyle.Bold), Brushes.Maroon, new Point(10, 200));
            
            e.Graphics.DrawString("Gender:" + Glabel.Text + "\t\tEducation:" + Elabel.Text , new Font("Time New Roman", 16, FontStyle.Bold), Brushes.Maroon, new Point(10, 300));
          
            e.Graphics.DrawString("Position:" + Polabel.Text, new Font("Time New Roman", 16, FontStyle.Bold), Brushes.Maroon, new Point(10, 400));
            e.Graphics.DrawString("**********Detail**********", new Font("Time New Roman", 22, FontStyle.Bold), Brushes.Maroon, new Point(200,500));
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
