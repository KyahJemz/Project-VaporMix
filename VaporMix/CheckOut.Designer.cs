namespace vapormix
{
    partial class CheckOut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt1 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.btn_BuyNow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.OrderListView = new System.Windows.Forms.ListView();
            this.Item_Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Item_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Item_Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(130, 238);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(132, 20);
            this.txt1.TabIndex = 0;
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(130, 264);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(132, 20);
            this.txt2.TabIndex = 1;
            // 
            // txt3
            // 
            this.txt3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txt3.Location = new System.Drawing.Point(130, 290);
            this.txt3.Name = "txt3";
            this.txt3.ReadOnly = true;
            this.txt3.Size = new System.Drawing.Size(132, 20);
            this.txt3.TabIndex = 2;
            this.txt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt4
            // 
            this.txt4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txt4.Location = new System.Drawing.Point(130, 316);
            this.txt4.Name = "txt4";
            this.txt4.ReadOnly = true;
            this.txt4.Size = new System.Drawing.Size(132, 20);
            this.txt4.TabIndex = 3;
            this.txt4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_BuyNow
            // 
            this.btn_BuyNow.Location = new System.Drawing.Point(187, 342);
            this.btn_BuyNow.Name = "btn_BuyNow";
            this.btn_BuyNow.Size = new System.Drawing.Size(75, 23);
            this.btn_BuyNow.TabIndex = 4;
            this.btn_BuyNow.Text = "Buy Now";
            this.btn_BuyNow.UseVisualStyleBackColor = true;
            this.btn_BuyNow.Click += new System.EventHandler(this.btn_BuyNow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Firstname :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lastname :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(28, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total Price :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(28, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Total Quantity :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Malgun Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(45, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "Order Confrimation";
            // 
            // OrderListView
            // 
            this.OrderListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OrderListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Item_Id,
            this.Item_Name,
            this.Item_Price});
            this.OrderListView.ForeColor = System.Drawing.Color.White;
            this.OrderListView.FullRowSelect = true;
            this.OrderListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.OrderListView.Location = new System.Drawing.Point(31, 71);
            this.OrderListView.MultiSelect = false;
            this.OrderListView.Name = "OrderListView";
            this.OrderListView.Size = new System.Drawing.Size(231, 148);
            this.OrderListView.TabIndex = 10;
            this.OrderListView.UseCompatibleStateImageBehavior = false;
            this.OrderListView.View = System.Windows.Forms.View.Details;
            // 
            // Item_Id
            // 
            this.Item_Id.Text = "Id";
            this.Item_Id.Width = 30;
            // 
            // Item_Name
            // 
            this.Item_Name.Text = "Name";
            this.Item_Name.Width = 135;
            // 
            // Item_Price
            // 
            this.Item_Price.Text = "Price";
            this.Item_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 407);
            this.Controls.Add(this.OrderListView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_BuyNow);
            this.Controls.Add(this.txt4);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CheckOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Out Form";
            this.Load += new System.EventHandler(this.CheckOut_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.TextBox txt4;
        private System.Windows.Forms.Button btn_BuyNow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView OrderListView;
        private System.Windows.Forms.ColumnHeader Item_Id;
        private System.Windows.Forms.ColumnHeader Item_Name;
        private System.Windows.Forms.ColumnHeader Item_Price;
    }
}