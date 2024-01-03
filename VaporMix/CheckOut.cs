using System;
using System.Collections;
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
    public partial class CheckOut : Form
    {
        String Id;
        ArrayList itemIds = new ArrayList();
        ArrayList itemNames = new ArrayList();
        ArrayList itemPrices = new ArrayList();
        public CheckOut()
        {
            InitializeComponent();
        }
        public CheckOut(String a, ArrayList b, ArrayList c, ArrayList d)
        {
            InitializeComponent();
            clearArrayLists();
            Id = a;
            itemIds = b;
            itemNames = c;
            itemPrices = d;
            txt3.Text = "0";
            foreach (String x in itemPrices) {
                int y = int.Parse(txt3.Text.ToString()) + int.Parse(x);
                txt3.Text = "" + y;
            }
            txt4.Text = itemNames.Count.ToString();

            refreshListView();
        }

        private void CheckOut_Load(object sender, EventArgs e)
        {

        }

        private void refreshListView()
        {
            for (int i = 0; i < itemIds.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(new[] { itemIds[i].ToString(), itemNames[i].ToString(), itemPrices[i].ToString()});
                OrderListView.Items.Add(lvi);
            }
        }

        private void btn_BuyNow_Click(object sender, EventArgs e)
        {
            if (txt1.Text == "" || txt2.Text == "")
            {
                MessageBox.Show("Invalid Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime currentDateTime = DateTime.Now;
                string formattedDateTime = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                SqlConnection sqlcon = new SqlConnection(@"Data Source=CLAB1-19\SQLEXPRESS;Initial Catalog=vapormix;Integrated Security=True");
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("insert into Transactions(Buyer_Id,Firstname,Lastname,TotalPrice,TotalQuantity,Timestamp) VALUES(@Buyer_Id,@Firstname,@Lastname,@TotalPrice,@TotalQuantity,@Timestamp); SELECT SCOPE_IDENTITY()", sqlcon);
                cmd.Parameters.AddWithValue("@Buyer_Id", int.Parse(Id));
                cmd.Parameters.AddWithValue("@Firstname", txt1.Text.ToString());
                cmd.Parameters.AddWithValue("@Lastname", txt2.Text.ToString());
                cmd.Parameters.AddWithValue("@TotalPrice", txt3.Text.ToString());
                cmd.Parameters.AddWithValue("@TotalQuantity", txt4.Text.ToString());
                cmd.Parameters.AddWithValue("@Timestamp", formattedDateTime);
                int orderId = Convert.ToInt32(cmd.ExecuteScalar());
                sqlcon.Close();

                foreach (String x in itemIds)
                {
                    sqlcon.Open();
                    SqlCommand cmd2 = new SqlCommand("insert into Orders(Transaction_Id,Items_Id) values (@Transaction_Id, @Items_Id)", sqlcon);
                    cmd2.Parameters.AddWithValue("@Transaction_Id", orderId);
                    cmd2.Parameters.AddWithValue("@Items_Id", int.Parse(x));
                    cmd2.ExecuteNonQuery();
                    sqlcon.Close();
                }
                MessageBox.Show("Successfully Saved");
                

                HomePage objFormMain = new HomePage(Id);
                this.Hide();
                objFormMain.Show();
            }
        }
        private void clearArrayLists()
        {
            itemIds.Clear();
            itemNames.Clear();
            itemPrices.Clear();
        }
    }
}
