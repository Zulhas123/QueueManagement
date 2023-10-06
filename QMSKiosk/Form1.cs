using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QMSKiosk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("shutdown.exe", "-I -t 0");
            System.Diagnostics.Process.Start("shutdown.exe", "-s -t 0");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("shutdown.exe", "-I -t 0");
            System.Diagnostics.Process.Start("shutdown.exe", "-r -t 0");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
