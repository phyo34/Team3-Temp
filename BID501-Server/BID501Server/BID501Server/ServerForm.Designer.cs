namespace BID501Server
{
    partial class ServerForm
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
            this.uxProductList = new System.Windows.Forms.ListBox();
            this.uxClientList = new System.Windows.Forms.ListBox();
            this.uxAddBtn = new System.Windows.Forms.Button();
            this.uxCloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxProductList
            // 
            this.uxProductList.FormattingEnabled = true;
            this.uxProductList.ItemHeight = 18;
            this.uxProductList.Location = new System.Drawing.Point(14, 11);
            this.uxProductList.Name = "uxProductList";
            this.uxProductList.Size = new System.Drawing.Size(294, 400);
            this.uxProductList.TabIndex = 0;
            // 
            // uxClientList
            // 
            this.uxClientList.FormattingEnabled = true;
            this.uxClientList.ItemHeight = 18;
            this.uxClientList.Location = new System.Drawing.Point(314, 11);
            this.uxClientList.Name = "uxClientList";
            this.uxClientList.Size = new System.Drawing.Size(292, 400);
            this.uxClientList.TabIndex = 1;
            // 
            // uxAddBtn
            // 
            this.uxAddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAddBtn.Location = new System.Drawing.Point(101, 429);
            this.uxAddBtn.Name = "uxAddBtn";
            this.uxAddBtn.Size = new System.Drawing.Size(122, 38);
            this.uxAddBtn.TabIndex = 2;
            this.uxAddBtn.TabStop = false;
            this.uxAddBtn.Text = "Add";
            this.uxAddBtn.UseVisualStyleBackColor = true;
            this.uxAddBtn.Click += new System.EventHandler(this.uxAddBtn_Click);
            // 
            // uxCloseButton
            // 
            this.uxCloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCloseButton.Location = new System.Drawing.Point(387, 429);
            this.uxCloseButton.Name = "uxCloseButton";
            this.uxCloseButton.Size = new System.Drawing.Size(122, 38);
            this.uxCloseButton.TabIndex = 3;
            this.uxCloseButton.TabStop = false;
            this.uxCloseButton.Text = "Close";
            this.uxCloseButton.UseVisualStyleBackColor = true;
            this.uxCloseButton.Click += new System.EventHandler(this.uxCloseButton_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 479);
            this.Controls.Add(this.uxCloseButton);
            this.Controls.Add(this.uxAddBtn);
            this.Controls.Add(this.uxClientList);
            this.Controls.Add(this.uxProductList);
            this.Name = "ServerForm";
            this.Text = "ServerForm";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox uxProductList;
        private System.Windows.Forms.ListBox uxClientList;
        private System.Windows.Forms.Button uxAddBtn;
        private System.Windows.Forms.Button uxCloseButton;
    }
}

