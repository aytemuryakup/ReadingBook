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
using System.IO;

namespace loginandregisterform
{
    

    public partial class controlpanel : Form
    {
        private void kitapkontrol_Click(object sender, EventArgs e)
        {
            if (panelbooks.Left == 984)
            {
                paneluser.Visible = false;
                paneluser.Left = 984;

                panelbooks.Visible = false;
                panelbooks.Left = 57;
                panelbooks.Visible = true;
                panelbooks.Refresh();

            }
        }

        private void kullanicikontrol_Click(object sender, EventArgs e)
        {

            if (paneluser.Left == 984)
            {
                panelbooks.Visible = false;
                panelbooks.Left = 984;

                paneluser.Visible = false;
                paneluser.Left = 57;
                paneluser.Visible = true;
                paneluser.Refresh();
            }

        }
        public controlpanel()
        {
            InitializeComponent();
            bookstable();
            usertable();
        }
        

        private void butonara_Click(object sender, EventArgs e)
        {
            MySqlConnection myConn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=bebek571;SslMode=none;");
            string search = "select * from yazlab21.bx_books where concat(isbn,book_title,book_author,publisher) like '%" + txtsearch.Text + "%'";
            MySqlDataAdapter myConnection = new MySqlDataAdapter(search,myConn);
            DataTable tablo = new DataTable();
            myConnection.Fill(tablo);
            tablo1.DataSource = tablo;
        }
        public void bookstable()
        {
            MySqlConnection myConn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=bebek571;SslMode=none;");
            MySqlDataAdapter myConnection = new MySqlDataAdapter();
            MySqlCommand Command = new MySqlCommand();

            string tablosorgu = "select * from yazlab21.bx_books";
            DataTable tablo = new DataTable();

            Command.CommandText = tablosorgu;
            Command.Connection = myConn;

            myConnection.SelectCommand = Command;
            myConn.Open();
            myConnection.Fill(tablo);
            myConn.Close();
            tablo1.DataSource = tablo;
        }

        private void get_selected_row(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>0)
            {
                DataGridViewRow row = this.tablo1.Rows[e.RowIndex];

                txtisbn.Text = row.Cells["isbn"].Value.ToString();
                txtkitapadi.Text = row.Cells["book_title"].Value.ToString();
                txtkitapyazari.Text = row.Cells["book_author"].Value.ToString();
                txtyili.Text = row.Cells["year_of_publication"].Value.ToString();
                txtyayinci.Text = row.Cells["publisher"].Value.ToString();
                txtresims.Text = row.Cells["image_url_s"].Value.ToString();
                txtresimm.Text = row.Cells["image_url_m"].Value.ToString();
                txtresiml.Text = row.Cells["image_url_l"].Value.ToString();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void insertbutton_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=bebek571;SslMode=none;");
               
                string insert = "insert into yazlab21.bx_books(isbn,book_title,book_author,year_of_publication,publisher,image_url_s,image_url_m,image_url_l) " +
                "values('" + this.txtisbn.Text + "','" + this.txtkitapadi.Text + "','" + this.txtkitapyazari.Text + "','" + this.txtyili.Text + "'," +
                "'" + this.txtyayinci.Text + "','" + this.txtresims.Text + "','" + this.txtresimm.Text + "','" + this.txtresiml.Text + "')";
                MySqlCommand Command = new MySqlCommand(insert, myConn);
                MySqlDataReader myreader;
                myConn.Open();
                myreader = Command.ExecuteReader();
                while (myreader.Read())
                {
                }
                bookstable();
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guncellebutton_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=bebek571;SslMode=none;";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                string update;
                update = "update yazlab21.bx_books set book_title='" + this.txtkitapadi.Text + "',book_author='" + this.txtkitapyazari.Text + "',year_of_publication='" + this.txtyili.Text + "'" +
                    ",publisher='" + this.txtyayinci.Text + "',image_url_s='" + this.txtresims.Text + "',image_url_m='" + this.txtresimm.Text + "'," +
                    "image_url_l='" + this.txtresiml.Text + "' where isbn='" + this.txtisbn.Text + "'";
                MySqlCommand SelectCommand = new MySqlCommand(update, myConn);
                myConn.Open();
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();

                while (myReader.Read()) { }
                bookstable();
                myConn.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void silbutton_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=bebek571;SslMode=none;";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                string delete;
                delete = "delete from yazlab21.bx_books where isbn='"+this.txtisbn.Text+"'";
                MySqlCommand SelectCommand = new MySqlCommand(delete, myConn);
                myConn.Open();
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();

                while (myReader.Read()) { }
                bookstable();
                myConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //USER TABLOSU ARAMA
        private void usersearch_Click(object sender, EventArgs e)
        {
            MySqlConnection myConn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=bebek571;SslMode=none;");
            string search = "select * from yazlab21.user_informations where concat(user_id1,username,userpassword,usermail,bx_userage,bx_userlocation,useryetki) like '%" + txtusersearch.Text + "%'";
            MySqlDataAdapter myConnection = new MySqlDataAdapter(search, myConn);
            DataTable tablo = new DataTable();
            myConnection.Fill(tablo);
            tablo2.DataSource = tablo;
        }
        // USER TABLOSU
        public void usertable()
        {
            MySqlConnection myConn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=bebek571;SslMode=none;");
            MySqlDataAdapter myConnection = new MySqlDataAdapter();
            MySqlCommand Command = new MySqlCommand();

            string tablosorgu = "select * from yazlab21.user_informations";
            DataTable tablo = new DataTable();

            Command.CommandText = tablosorgu;
            Command.Connection = myConn;

            myConnection.SelectCommand = Command;
            myConn.Open();
            myConnection.Fill(tablo);
            myConn.Close();
            tablo2.DataSource = tablo;
        }
        // USER TABLO CLICK SET
        private void gel_selected_row2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                DataGridViewRow row = this.tablo2.Rows[e.RowIndex];

                txtuserid.Text = row.Cells["user_id1"].Value.ToString();
                txtusername.Text = row.Cells["username"].Value.ToString();
                txtuserpassword.Text = row.Cells["userpassword"].Value.ToString();
                txtusermail.Text = row.Cells["usermail"].Value.ToString();
                txtbookuserid.Text = row.Cells["bx_userid"].Value.ToString();
                txtage.Text = row.Cells["bx_userage"].Value.ToString();
                txtlocation.Text = row.Cells["bx_userlocation"].Value.ToString();
                txtyetki.Text = row.Cells["useryetki"].Value.ToString();
            }
        }

        private void userkayit_Click(object sender, EventArgs e)
        {

            try
            {
                MySqlConnection myConn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=bebek571;SslMode=none;");

                string insert = "insert into yazlab21.user_informations(username,userpassword,usermail,bx_userid,bx_userage,bx_userlocation,useryetki) " +
                "values('" + this.txtusername.Text + "','" + this.txtuserpassword.Text + "','" + this.txtusermail.Text + "','" + this.txtbookuserid.Text + "','" + this.txtage.Text + "'," +
                "'" + this.txtlocation.Text + "','" + this.txtyetki.Text + "')";
                MySqlCommand Command = new MySqlCommand(insert, myConn);
                MySqlDataReader myreader;
                myConn.Open();
                myreader = Command.ExecuteReader();
                while (myreader.Read())
                {
                }
                usertable();
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
                update = "update yazlab21.bx_users set location='" + this.txtlocation.Text + "',age='" + this.txtage.Text + "' where user_id='" + this.txtbookuserid.Text + "'";
                MySqlCommand SelectCommand = new MySqlCommand(update, myConn);
                myConn.Open();
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();

                while (myReader.Read()) { }
                myConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void userguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=bebek571;SslMode=none;";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                string update;
                update = "update yazlab21.user_informations set username='" + this.txtusername.Text + "',userpassword='" + this.txtuserpassword.Text + "',usermail='" + this.txtusermail.Text + "'" +
                    ",bx_userid='" + this.txtbookuserid.Text + "',bx_userage='" + this.txtage.Text + "',bx_userlocation='" + this.txtlocation.Text + "'," +
                    "useryetki='" + this.txtyetki.Text + "' where user_id1='" + this.txtuserid.Text + "'";
                MySqlCommand SelectCommand = new MySqlCommand(update, myConn);
                myConn.Open();
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();

                while (myReader.Read()) { }
                usertable();
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
                update = "update yazlab21.bx_users set location='" + this.txtlocation.Text + "',age='" + this.txtage.Text + "' where user_id='" + this.txtbookuserid.Text + "'";
                MySqlCommand SelectCommand = new MySqlCommand(update, myConn);
                myConn.Open();
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();

                while (myReader.Read()) { }
                myConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void usersil_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=bebek571;SslMode=none;";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                string delete;
                delete = "delete from yazlab21.user_informations where user_id1='" + this.txtuserid.Text + "'";
                MySqlCommand SelectCommand = new MySqlCommand(delete, myConn);
                myConn.Open();
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();

                while (myReader.Read()) { }
                usertable();
                myConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=bebek571;SslMode=none;";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                string delete;
                delete = "delete from yazlab21.bx_users where user_id='" + this.txtbookuserid.Text + "'";
                MySqlCommand SelectCommand = new MySqlCommand(delete, myConn);
                myConn.Open();
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();

                while (myReader.Read()) { }
                myConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
