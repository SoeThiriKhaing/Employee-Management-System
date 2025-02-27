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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
        
        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void pBar_ValueChanged(object sender, EventArgs e)
        {

        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 3;
            pBar.Value = startpoint;
            if (pBar.Value == 100)
            {
                pBar.Value = 0;
                timer1.Stop();
                this.Hide();
                login log = new login();
                log.Show();
            }
        }
    }
}
