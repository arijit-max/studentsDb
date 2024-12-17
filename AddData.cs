using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuitionFeeTracker
{
    public partial class AddData : Form
    {
        public AddData()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StudentsFEE.mdf;Integrated Security=True;Connect Timeout=30");
            string Name = tbName.Text;
            int Amount = int.Parse(tbAmount.Text);
            string StClass = cbClass.SelectedItem.ToString();
            string PaymentMode = cbMode.SelectedItem.ToString();
            string ClassType = cbType.SelectedItem.ToString();
            DateTime PaymentDate = dateTimePicker1.Value;

            string query = "INSERT INTO studentsdb(Name,Class,Mode,PaymentDate,TypeOfClass,Amount) values ('"+Name+"','"+StClass+"','"+PaymentMode+"','"+PaymentDate+"','"+ClassType+"','"+Amount+"')";

            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data inserted successfully", "Insertion Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear_Click(null, null);
            }
            catch
            {
                MessageBox.Show("Some technical problems occurred", "Insertion Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




            btnClear_Click(null, null);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbName.Clear();
            tbAmount.Clear();
            cbClass.Text = string.Empty;
            cbMode.Text = string.Empty;
            cbType.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 od = new Form1();
            od.Dock = DockStyle.Fill;
            od.TopLevel = false;
            this.Controls.Add(od);
            od.BringToFront();
            od.Show();
        }
    }
}
