namespace BID501Client
{
    partial class BidForm
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
            this.uxStatusLbl = new System.Windows.Forms.Label();
            this.uxStatus = new System.Windows.Forms.Button();
            this.uxPlaceBidBtn = new System.Windows.Forms.Button();
            this.uxMinBidLbl = new System.Windows.Forms.Label();
            this.uxProductsLabel = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.uxName = new System.Windows.Forms.Label();
            this.uxCount = new System.Windows.Forms.Label();
            this.uxMin = new System.Windows.Forms.Label();
            this.uxBidAmount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // uxStatusLbl
            // 
            this.uxStatusLbl.AutoSize = true;
            this.uxStatusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxStatusLbl.Location = new System.Drawing.Point(119, 140);
            this.uxStatusLbl.Name = "uxStatusLbl";
            this.uxStatusLbl.Size = new System.Drawing.Size(81, 25);
            this.uxStatusLbl.TabIndex = 2;
            this.uxStatusLbl.Text = "Status:";
            // 
            // uxStatus
            // 
            this.uxStatus.BackColor = System.Drawing.Color.White;
            this.uxStatus.Enabled = false;
            this.uxStatus.Location = new System.Drawing.Point(206, 137);
            this.uxStatus.Name = "uxStatus";
            this.uxStatus.Size = new System.Drawing.Size(78, 35);
            this.uxStatus.TabIndex = 3;
            this.uxStatus.UseVisualStyleBackColor = false;
            // 
            // uxPlaceBidBtn
            // 
            this.uxPlaceBidBtn.Font = new System.Drawing.Font("Modern No. 20", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxPlaceBidBtn.Location = new System.Drawing.Point(76, 338);
            this.uxPlaceBidBtn.Name = "uxPlaceBidBtn";
            this.uxPlaceBidBtn.Size = new System.Drawing.Size(146, 55);
            this.uxPlaceBidBtn.TabIndex = 4;
            this.uxPlaceBidBtn.Text = "BID";
            this.uxPlaceBidBtn.UseVisualStyleBackColor = true;
            this.uxPlaceBidBtn.Click += new System.EventHandler(this.uxPlaceBidBtn_Click);
            // 
            // uxMinBidLbl
            // 
            this.uxMinBidLbl.AutoSize = true;
            this.uxMinBidLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxMinBidLbl.Location = new System.Drawing.Point(66, 253);
            this.uxMinBidLbl.Name = "uxMinBidLbl";
            this.uxMinBidLbl.Size = new System.Drawing.Size(142, 25);
            this.uxMinBidLbl.TabIndex = 5;
            this.uxMinBidLbl.Text = "Minimum Bid:";
            // 
            // uxProductsLabel
            // 
            this.uxProductsLabel.AutoSize = true;
            this.uxProductsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxProductsLabel.Location = new System.Drawing.Point(578, 33);
            this.uxProductsLabel.Name = "uxProductsLabel";
            this.uxProductsLabel.Size = new System.Drawing.Size(97, 25);
            this.uxProductsLabel.TabIndex = 8;
            this.uxProductsLabel.Text = "Products";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Info;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(403, 70);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(272, 364);
            this.listBox1.TabIndex = 9;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
           // this.listBox1.BindingContextChanged += new System.EventHandler(this.listBox1_BindingContextChanged);
            // 
            // uxName
            // 
            this.uxName.AutoSize = true;
            this.uxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxName.Location = new System.Drawing.Point(48, 46);
            this.uxName.Name = "uxName";
            this.uxName.Size = new System.Drawing.Size(0, 25);
            this.uxName.TabIndex = 10;
            // 
            // uxCount
            // 
            this.uxCount.AutoSize = true;
            this.uxCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCount.Location = new System.Drawing.Point(223, 199);
            this.uxCount.Name = "uxCount";
            this.uxCount.Size = new System.Drawing.Size(0, 25);
            this.uxCount.TabIndex = 11;
            // 
            // uxMin
            // 
            this.uxMin.AutoSize = true;
            this.uxMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxMin.Location = new System.Drawing.Point(223, 253);
            this.uxMin.Name = "uxMin";
            this.uxMin.Size = new System.Drawing.Size(0, 25);
            this.uxMin.TabIndex = 12;
            // 
            // uxBidAmount
            // 
            this.uxBidAmount.Location = new System.Drawing.Point(53, 198);
            this.uxBidAmount.Name = "uxBidAmount";
            this.uxBidAmount.Size = new System.Drawing.Size(100, 26);
            this.uxBidAmount.TabIndex = 13;
            // 
            // BidForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(687, 450);
            this.Controls.Add(this.uxBidAmount);
            this.Controls.Add(this.uxMin);
            this.Controls.Add(this.uxCount);
            this.Controls.Add(this.uxName);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.uxProductsLabel);
            this.Controls.Add(this.uxMinBidLbl);
            this.Controls.Add(this.uxPlaceBidBtn);
            this.Controls.Add(this.uxStatus);
            this.Controls.Add(this.uxStatusLbl);
            this.Name = "BidForm";
            this.Text = "Bid501";
            this.Load += new System.EventHandler(this.BidForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label uxStatusLbl;
        private System.Windows.Forms.Button uxStatus;
        private System.Windows.Forms.Button uxPlaceBidBtn;
        private System.Windows.Forms.Label uxMinBidLbl;
        private System.Windows.Forms.Label uxProductsLabel;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label uxName;
        private System.Windows.Forms.Label uxCount;
        private System.Windows.Forms.Label uxMin;
        private System.Windows.Forms.TextBox uxBidAmount;
    }
}

