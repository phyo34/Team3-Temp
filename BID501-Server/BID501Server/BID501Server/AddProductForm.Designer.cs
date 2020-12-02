namespace BID501Server
{
    partial class AddProductForm
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
            this.uxAddBtn = new System.Windows.Forms.Button();
            this.uxProductList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // uxAddBtn
            // 
            this.uxAddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAddBtn.Location = new System.Drawing.Point(102, 415);
            this.uxAddBtn.Name = "uxAddBtn";
            this.uxAddBtn.Size = new System.Drawing.Size(126, 49);
            this.uxAddBtn.TabIndex = 1;
            this.uxAddBtn.Text = "Add";
            this.uxAddBtn.UseVisualStyleBackColor = true;
            this.uxAddBtn.Click += new System.EventHandler(this.uxAddBtn_Click);
            // 
            // uxProductList
            // 
            this.uxProductList.FormattingEnabled = true;
            this.uxProductList.ItemHeight = 20;
            this.uxProductList.Location = new System.Drawing.Point(12, 23);
            this.uxProductList.Name = "uxProductList";
            this.uxProductList.Size = new System.Drawing.Size(317, 344);
            this.uxProductList.TabIndex = 2;
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 478);
            this.Controls.Add(this.uxProductList);
            this.Controls.Add(this.uxAddBtn);
            this.Name = "AddProductForm";
            this.Text = "AddProductForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button uxAddBtn;
        private System.Windows.Forms.ListBox uxProductList;
    }
}