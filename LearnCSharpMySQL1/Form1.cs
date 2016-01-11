using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LearnCSharpMySQL1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string mycon = "datasource=localhost;port=3306;username=root;Password=2557";
                MySqlConnection con = new MySqlConnection(mycon);
                MySqlDataAdapter adp = new MySqlDataAdapter();
                adp.SelectCommand = new MySqlCommand("SELECT * database.EmployeeInfo",con);
                //MySqlCommandBuilder cb = new MySqlCommandBuilder(adp);

                con.Open();

                MessageBox.Show("connected");

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
