using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GridViewWithAccess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetData();
        }

        private DataTable GetData()
        {
            DataTable dt = new DataTable();

            //uper System.Data.OleDb ko lazmi khud hand sy import kry likh kr
            //configuration file ma provider ma b yhe likhy jo import kia ha 

            string connectionstring = ConfigurationManager.ConnectionStrings["access"].ConnectionString;
            OleDbConnection conn = new OleDbConnection(connectionstring);
            //ye access k sath ha islye OleDbConnetion krygy na k SqlConnection 

            
            OleDbDataAdapter ad = new OleDbDataAdapter("select * from employees", conn);

            //access ki wla sy jha jha Sql wala work ana ta wha wha OleDb wala aya ha
            ad.Fill(dt);

            return dt;
        }
    }
}
