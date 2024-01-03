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

namespace vapormix
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Form1 objFormMain = new Form1();
            this.Hide();
            objFormMain.Show();
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            if (txt_Username.Text == "" ||
               txt_Password1.Text == "" ||
               txt_Password2.Text == "")
            {
                MessageBox.Show("Blanks?, Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txt_Password1.Text.Trim() == txt_Password2.Text.Trim())
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=CLAB1-19\SQLEXPRESS;Initial Catalog=vapormix;Integrated Security=True");
                string query = "Select * from Buyer Where Username = '" + txt_Username.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    MessageBox.Show("Username already exist, Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Username.Clear();
                    txt_Username.Focus();
                }
                else
                {
                    SqlConnection sqlcon2 = new SqlConnection(@"Data Source=CLAB1-19\SQLEXPRESS;Initial Catalog=vapormix;Integrated Security=True");
                    sqlcon2.Open();
                    SqlCommand cmd = new SqlCommand("insert into Buyer values (@Username, @Password)", sqlcon2);
                    cmd.Parameters.AddWithValue("@Username", (txt_Username.Text));
                    cmd.Parameters.AddWithValue("@Password", (txt_Password1.Text));
                    cmd.ExecuteNonQuery();
                    sqlcon2.Close();

                    MessageBox.Show("Successfully Created");

                    Form1 objFormMain = new Form1();
                    this.Hide();
                    objFormMain.Show();
                }
            }
            else
            {
                MessageBox.Show("Password did not match, Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Password1.Clear();
                txt_Password2.Clear();
                txt_Password1.Focus();
            }
        }
    }
}
