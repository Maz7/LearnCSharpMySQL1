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
            fillCombo();
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

        private void button2_Click(object sender, EventArgs e)
        {
            string mycon = "datasource=localhost;port=3306;username=root;Password=2557";
            string Query = "UPDATE database.players SET idPlayers='"+this.id.Text+"',UserName='"+user.Text+"',Password='"+pass.Text+"',Goals='"+ goal.Text+"',Assist='"+assist.Text+"' where idPlayers='" + this.id.Text + "' ;";

            MySqlConnection con = new MySqlConnection(mycon);
            MySqlCommand cmd = new MySqlCommand(Query, con);
            MySqlDataReader myReader;

            try
            {
                con.Open();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("Updated");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mycon = "datasource=localhost;port=3306;username=root;Password=2557";
            string Query = " DELETE FROM database.players WHERE idPlayers='" + this.id.Text + "' ;";

            MySqlConnection con = new MySqlConnection(mycon);
            MySqlCommand cmd = new MySqlCommand(Query, con);
            MySqlDataReader myReader;

            try
            {
                con.Open();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("Deleted");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String namestr = user.Text;
            comboBox1.Items.Add(namestr);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mycon = "datasource=localhost;port=3306;username=root;Password=2557";
            string Query = "SELECT * FROM database.players WHERE UserName= '"+ comboBox1.Text +"';";

            MySqlConnection con = new MySqlConnection(mycon);
            MySqlCommand cmd = new MySqlCommand(Query, con);
            MySqlDataReader myReader;

            try
            {
                con.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    int idP = myReader.GetInt32("idPlayers");
                    String user1 = myReader.GetString("UserName");
                    String pass1 = myReader.GetString("Password");
                    int goals1 = myReader.GetInt32("Goals");
                    int assist1 = myReader.GetInt32("Assist");

                    id.Text = idP.ToString();
                    user.Text = user1;
                    pass.Text = pass1;
                    goal.Text = goals1.ToString();
                    assist.Text = assist1.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void fillCombo()
        {
            string mycon = "datasource=localhost;port=3306;username=root;Password=2557";
            string Query = "SELECT * FROM database.players;" ;

            MySqlConnection con = new MySqlConnection(mycon);
            MySqlCommand cmd = new MySqlCommand(Query, con);
            MySqlDataReader myReader;

            try
            {
                con.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    String str = myReader.GetString("UserName");
                    comboBox1.Items.Add(str);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
