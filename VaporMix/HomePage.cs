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
    public partial class HomePage : Form
    {
        String Id;
        ArrayList itemIds = new ArrayList();
        ArrayList itemNames = new ArrayList();
        ArrayList itemPrices = new ArrayList();

        public HomePage()
        {
            InitializeComponent();
        }
        public HomePage(String Id)
        {
            InitializeComponent();
            this.Id = Id;
        }

        private void btn_CheckOut_Click(object sender, EventArgs e)
        {
            if (cb_item1.Checked) 
            { 
                itemIds.Add("1");
                itemNames.Add("Doomsday v2");
                itemPrices.Add("5000"); 
            }
            if (cb_item2.Checked)
            {
                itemIds.Add("2");
                itemNames.Add("Kalasag v3");
                itemPrices.Add("5000");
            }
            if (cb_item3.Checked)
            {
                itemIds.Add("3");
                itemNames.Add("Kalasag v3 w/ Booster");
                itemPrices.Add("7000");
            }
            if (cb_item4.Checked)
            {
                itemIds.Add("4");
                itemNames.Add("Black Serpentes");
                itemPrices.Add("1500");
            }
            if (cb_item5.Checked)
            {
                itemIds.Add("5");
                itemNames.Add("Executive v3 Black");
                itemPrices.Add("4000");
            }
            if (cb_item6.Checked)
            {
                itemIds.Add("6");
                itemNames.Add("Executive v3 Booster");
                itemPrices.Add("1500");
            }

            if (itemIds.Count >= 1)
            {
                CheckOut objFormMain = new CheckOut(Id, itemIds, itemNames, itemPrices);
                this.Hide();
                objFormMain.Show();
            }
            else
            {
                MessageBox.Show("Invalid Orders", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            Form1 objFormMain = new Form1();
            this.Hide();
            objFormMain.Show();
        }

        private void btn_ShopNow_Click(object sender, EventArgs e)
        {
            pnl_MyOrders.Visible = false;
            pnl_ShopNow.Visible = true;
        }

        private void btn_MyOrders_Click(object sender, EventArgs e)
        {
            pnl_MyOrders.Visible = true;
            pnl_ShopNow.Visible = false;
            ordersListView.Items.Clear();
            itemsListView.Items.Clear();

            SqlConnection sqlcon = new SqlConnection(@"Data Source=CLAB1-19\SQLEXPRESS;Initial Catalog=vapormix;Integrated Security=True");
            string query = "Select * from Transactions Where Buyer_Id = '"+Id+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);

            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count >= 1)
            {
                foreach (DataRow row in dtbl.Rows)
                {
                    ListViewItem lvi = new ListViewItem(new[] { row["Id"].ToString(), row["Firstname"].ToString(), row["Lastname"].ToString(), row["TotalPrice"].ToString(), row["TotalQuantity"].ToString() });
                    ordersListView.Items.Add(lvi);
                }
            }
        }


        private void ordersListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ordersListView.SelectedItems.Count > 0)
            {
                itemsListView.Items.Clear();
                ListViewItem selectedItem = ordersListView.SelectedItems[0];
                string firstCellValue = selectedItem.SubItems[0].Text;
                Console.WriteLine(firstCellValue);

                SqlConnection sqlcon = new SqlConnection(@"Data Source=CLAB1-19\SQLEXPRESS;Initial Catalog=vapormix;Integrated Security=True");
                string query = "Select * from Orders join Items on Orders.Items_Id = Items.Id where Orders.Transaction_Id ='" + firstCellValue + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);

                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                Console.WriteLine(dtbl.Rows.Count);
                if (dtbl.Rows.Count >= 1)
                {
                    
                    foreach (DataRow row in dtbl.Rows)
                    {
                        Console.WriteLine(row["Name"]);
                        ListViewItem lvi = new ListViewItem(new[] { row["Name"].ToString() });
                        itemsListView.Items.Add(lvi);
                    }
                }
            }
        }
    }
}
