using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuitionFeeTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddData od = new AddData();
            od.Dock = DockStyle.Fill;
            od.TopLevel = false;
            this.Controls.Add(od);
            od.BringToFront();
            od.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowData od = new ShowData();
            od.Dock = DockStyle.Fill;
            od.TopLevel = false;
            this.Controls.Add(od);
            od.BringToFront();
            od.Show();
        }
    }
}
