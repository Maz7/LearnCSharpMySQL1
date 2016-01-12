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
            timer1.Start();
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

        public void fill_listbox()
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string mycon = "datasource=localhost;port=3306;username=root;Password=2557";
            string Query = "SELECT UserName,Assist,Goals FROM database.players;";

            MySqlConnection con = new MySqlConnection(mycon);
            MySqlCommand cmd = new MySqlCommand(Query, con);
           // MySqlDataReader myReader;

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dataset = new DataTable();
                sda.Fill(dataset);

                BindingSource bs = new BindingSource();

                bs.DataSource = dataset;
                dataGridView1.DataSource = bs;
                sda.Update(dataset);
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            this.label6.Text = dt.ToString();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dia = MessageBox.Show("Are you sure you want to exit application?", "Exit", MessageBoxButtons.YesNo);

            if(dia == DialogResult.Yes)
            {
                Application.ExitThread();
                //Application.Exit();
            }
            else if(dia == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
