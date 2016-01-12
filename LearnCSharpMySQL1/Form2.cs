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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mycon = "datasource=localhost;port=3306;username=root;Password=2557";
            string Query = "INSERT INTO database.players (idPlayers,UserName,Password,Goals,Assist) VALUES ('"+this.id.Text+"','"+user.Text+"','"+pass.Text+"','"+goal.Text+"','"+assist.Text+"');";

            MySqlConnection con = new MySqlConnection(mycon);
            MySqlCommand cmd = new MySqlCommand(Query, con);
            MySqlDataReader myReader;

            try
            {
                con.Open();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("Saved");
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
