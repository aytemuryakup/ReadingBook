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

namespace loginandregisterform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }
        private void butongirisgecis_Click(object sender, EventArgs e)
        {          
            if(slideB.Left==542)
            {
                slideA.Visible = false;
                slideA.Left = 542;

                slideB.Visible = false;
                slideB.Left = 31;
                slideB.Visible = true;
                slideB.Refresh();
            }
        }
        //iki sayfa arası geçiş butonları
        private void butonkayitgecis_Click(object sender, EventArgs e)
        {
            if (slideA.Left == 542)
            {
                slideB.Visible = false;
                slideB.Left = 542;

                slideA.Visible = false;
                slideA.Left = 31;
                slideA.Visible = true;
                slideA.Refresh();

            }
        }
        private void buttonsignin_Click(object sender, EventArgs e)
        {
            try
            {
                //Database bağlantısı
                string myConnection = "datasource=localhost;port=3306;username=root;password=bebek571;SslMode=none;";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                //Sisteme Giriş için databasedeki useri çağırma
                string select;
                select = "select * from yazlab21.user_informations where username = '" + this.txtusername.Text + "' ";
                select += "and userpassword = '" + this.txtpassword.Text+ "';";
                MySqlCommand SelectCommand = new MySqlCommand(select, myConn);

                myConn.Open();
                //Database i okuma
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                 while (myReader.Read())
                  {
                    if(myReader["useryetki"].ToString() == "1")
                        {
                            //MessageBox.Show("Admin Giriş Sayfasına Yönlendirme");

                            Form gecis = new controlpanel();
                            gecis.Show();
                            this.Hide();


                        }
                    else
                        {
                            MessageBox.Show("Admin değilsiniz");
                        }
                  }
                }
                else
                {
                    myConn.Close();
                    MessageBox.Show("Username or Password incorrect");
                }

             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Databaseye bağlanamadı");
            }

        }

        private void butongiris_Click(object sender, EventArgs e)
        {

            try
            { 
                 // Database bağlantısı
                string myConnection = "datasource=localhost;port=3306;username=root;password=bebek571;SslMode=none;";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                string insert;
                insert = "insert into yazlab21.user_informations(username,userpassword,usermail,bx_userid,bx_userage,bx_userlocation) " +
                    "values('" + this.txtkayituser.Text + "','" + this.txtkayitsifre.Text + "','" + this.txtmail.Text + "','" + this.txtid.Text + "'," +
                    "'" + this.txtage.Text + "','" + this.txtkonum.Text + "')";
                MySqlCommand SelectCommand = new MySqlCommand(insert,myConn);
                myConn.Open();
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();

                while (myReader.Read()) { }
                MessageBox.Show("Kayit Başarılı");
                myConn.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                // Database bağlantısı
                string myConnection = "datasource=localhost;port=3306;username=root;password=bebek571;SslMode=none;";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                string update;
                update = "update yazlab21.bx_users set location='" + this.txtkonum.Text + "',age='" + this.txtage.Text + "' where user_id='" + this.txtid.Text + "'";
                MySqlCommand SelectCommand = new MySqlCommand(update, myConn);
                myConn.Open();
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();

                while (myReader.Read()) { }
                myConn.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
               
        }

     /*   private void slideA_Paint(object sender, PaintEventArgs e)
        {

        }*/

        private void boxuserkontrolbutton_Click(object sender, EventArgs e)
        {
            try
            {
                //Database bağlantısı
                string myConnection = "datasource=localhost;port=3306;username=root;password=bebek571;SslMode=none;";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                //Sisteme Giriş için databasedeki useri çağırma
                string select;
                select = "select * from yazlab21.bx_users where user_id = '" + this.txtid.Text + "' ";
                MySqlCommand SelectCommand = new MySqlCommand(select, myConn);

                myConn.Open();
                //Database i okuma
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    txtage.Text = myReader["age"].ToString();
                    txtkonum.Text = myReader["location"].ToString();
                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }

}
    
