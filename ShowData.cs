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
    public partial class ShowData : Form
    {
        public ShowData()
        {
            InitializeComponent();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StudentsFEE.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
            int key = cbSearch.SelectedIndex;
            switch(key)
            {
                case 0:
                    string Name = tbName.Text;
                    string query = "select * from studentsdb";
                    try
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        var reader = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[0].HeaderText = "ID";
                        dataGridView1.Columns[1].HeaderText = "NAME";
                        dataGridView1.Columns[2].HeaderText = "CLASS";
                        dataGridView1.Columns[3].HeaderText = "MODE";
                        dataGridView1.Columns[4].HeaderText = "DATE";
                        dataGridView1.Columns[5].HeaderText = "CLASS TYPE";
                        dataGridView1.Columns[6].HeaderText = "AMOUNT";

                        dataGridView1.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
                        conn.Close();

                    }
                    catch
                    {
                        MessageBox.Show("Some technical problems occurred", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    break;


                case 1:


                case 2:

                default:
                    MessageBox.Show("Select a type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

            }
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
