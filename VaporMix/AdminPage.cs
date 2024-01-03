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
    public partial class AdminPage : Form
    {
        String index;
        String index2;
        public AdminPage()
        {
            InitializeComponent();
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            RefreshAccountsTable();
            RefreshTransactionsTable();
        }

        private void btn_Accounts_Click(object sender, EventArgs e)
        {
            pnl_Accounts.Visible = true;
            pnl_Transactions.Visible = false;
            RefreshAccountsTable();
        }

        private void btn_Transactions_Click(object sender, EventArgs e)
        {
            pnl_Accounts.Visible = false;
            pnl_Transactions.Visible = true;
            RefreshTransactionsTable();
        }

        private void AccountTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            index = AccountTable.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_Username.Text = AccountTable.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Password.Text = AccountTable.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void RefreshAccountsTable()
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=CLAB1-19\SQLEXPRESS;Initial Catalog=vapormix;Integrated Security=True");
            string query = "Select * from Buyer";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);

            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count >= 1)
            {
                AccountTable.DataSource = dtbl;
            }
        }

        private void RefreshTransactionsTable()
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=CLAB1-19\SQLEXPRESS;Initial Catalog=vapormix;Integrated Security=True");
            string query = "Select * from Transactions";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count >= 1)
            {
                TransactionsTable.DataSource = dtbl;
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (index != "")
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=CLAB1-19\SQLEXPRESS;Initial Catalog=vapormix;Integrated Security=True");
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("delete from Buyer where Id = @index", sqlcon);
                cmd.Parameters.AddWithValue("@index", index);
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                txt_Password.Text = "";
                txt_Username.Text = "";
                index = "";
                RefreshAccountsTable();
            }
        }

        private void btn_SaveChanges_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=CLAB1-19\SQLEXPRESS;Initial Catalog=vapormix;Integrated Security=True");
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Update Buyer set Username=@Username, Password=@Password where Id = '"+index+"'", sqlcon);
            cmd.Parameters.AddWithValue("@Username", txt_Username.Text);
            cmd.Parameters.AddWithValue("@Password", txt_Password.Text);
            cmd.ExecuteNonQuery();
            sqlcon.Close();
            RefreshAccountsTable();
            txt_Password.Text = "";
            txt_Username.Text = "";
            index = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (index2 != "")
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=CLAB1-19\SQLEXPRESS;Initial Catalog=vapormix;Integrated Security=True");
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("delete from Transactions where Id = '" + index2 + "'", sqlcon);
                cmd.ExecuteNonQuery();
                sqlcon.Close();

                sqlcon.Open();
                SqlCommand cmd1 = new SqlCommand("delete from Orders where Transaction_Id = '" + index2 + "'", sqlcon);
                cmd1.ExecuteNonQuery();
                sqlcon.Close();

                index2 = "";
                RefreshTransactionsTable();
            }
        }

        private void TransactionsTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            index2 = TransactionsTable.Rows[e.RowIndex].Cells[0].Value.ToString();

            itemsListView.Items.Clear();

            SqlConnection sqlcon = new SqlConnection(@"Data Source=CLAB1-19\SQLEXPRESS;Initial Catalog=vapormix;Integrated Security=True");
            string query = "Select * from Orders join Items on Orders.Items_Id = Items.Id where Orders.Transaction_Id ='" + index2 + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);

            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            Console.WriteLine(dtbl.Rows.Count);
            if (dtbl.Rows.Count >= 1)
            {
                foreach (DataRow row in dtbl.Rows)
                {
                    ListViewItem lvi = new ListViewItem(new[] { row["Name"].ToString() });
                    itemsListView.Items.Add(lvi);
                }
            }
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            Form1 objFormMain = new Form1();
            this.Hide();
            objFormMain.Show();
        }
    }
}
