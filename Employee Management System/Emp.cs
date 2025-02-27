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
using System.Globalization;
namespace Employee_Management_System
{
    public partial class Emp : UserControl
    {
        DB con = new DB();
        public Emp()
        {
            InitializeComponent();
        }
        public void clear()
        {
            txtEId.Clear();
            txtEmpName.Clear();

            txtAddress.Clear();
            txtPhno.Clear();

        }
        public void getTable()
        {
            string select = "select * from Emp";
            SqlCommand cmd = new SqlCommand(select, con.GetCon());
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvEmp.DataSource = dt;


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtEId.Text == "" || txtEmpName.Text == "" || txtAddress.Text == "" || txtPhno.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    string insert = "insert into Emp values('" + txtEId.Text + "','" + txtEmpName.Text + "','" + dateTime.Value + "','" + txtAddress.Text + "','" + txtPhno.Text + "','" + comGender.SelectedItem.ToString() + "','" + comEdu.SelectedItem.ToString() + "', '" + comPo.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(insert, con.GetCon());
                    con.OpenCon();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data insert Successfully");
                    con.CloseCon();

                    getTable();
                    clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dateTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEId.Text = dgvEmp.SelectedRows[0].Cells[0].Value.ToString();
            txtEmpName.Text = dgvEmp.SelectedRows[0].Cells[1].Value.ToString();
            if (dgvEmp.SelectedRows.Count > 0)
            {
                dateTime.Value = Convert.ToDateTime(dgvEmp.SelectedRows[0].Cells[2].Value);
            }
            txtAddress.Text = dgvEmp.SelectedRows[0].Cells[3].Value.ToString();
            txtPhno.Text = dgvEmp.SelectedRows[0].Cells[4].Value.ToString();
            comGender.Text = dgvEmp.SelectedRows[0].Cells[5].Value.ToString();
            comEdu.Text = dgvEmp.SelectedRows[0].Cells[6].Value.ToString();
            comPo.Text = dgvEmp.SelectedRows[0].Cells[7].Value.ToString();


        }

        private void label9_Click(object sender, EventArgs e)
        {
            getTable();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtEId.Text == "" || txtEmpName.Text == "" || txtAddress.Text == "" || txtPhno.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {

                try
                {
                    string update = "update Emp set EmployeeName='" + txtEmpName.Text + "',DOB='" + dateTime.Value + "',Address='" + txtAddress.Text + "',Phno='" + txtPhno.Text + "',Gender='" + comGender.Text + "',Education='" + comEdu.Text + "',Position='" + comPo.Text + "' where Id='" + txtEId.Text + "'";
                    SqlCommand cmd = new SqlCommand(update, con.GetCon());
                    con.OpenCon();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Update Successfully");
                    con.CloseCon();
                    getTable();
                    clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtEId.Text == "" || txtEmpName.Text == "" || txtAddress.Text == "" || txtPhno.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    string delete = "delete from Emp where Id='" + txtEId.Text + "'";
                    SqlCommand cmd = new SqlCommand(delete, con.GetCon());
                    con.OpenCon();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfully");
                    con.CloseCon();
                    getTable();
                    clear();

                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

