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
            password.PasswordChar = '*';
            password.MaxLength = 20;
        }

        
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (username.Text.Equals("") || password.Text.Equals(""))
            {
                MessageBox.Show("Field empty");
            }

                String userN = username.Text.Trim();
            
            try
            {
                string mycon = "datasource=localhost;port=3306;username=root;Password=2557";
                MySqlConnection con = new MySqlConnection(mycon);
                
                MySqlCommand command = new MySqlCommand("SELECT * from database.players where username='" + userN +
                    "' and password='" + password.Text +  "' ;", con);

                MySqlDataReader reader;
                con.Open();
                reader = command.ExecuteReader();

                int i = 0;
                while(reader.Read())
                {
                    i = i + 1;
                }

                if(i == 1)
                {
                    MessageBox.Show("Successful");
                }
                else if(i > 1){
                    MessageBox.Show("Multiple accounts");
                }
                else
                {
                    MessageBox.Show("Can't connect");
                }
               
                con.Close();
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
