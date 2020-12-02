namespace BID501Client
{
    partial class LoginForm
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
            this.uxUserNameLabel = new System.Windows.Forms.Label();
            this.uxPasswordLabel = new System.Windows.Forms.Label();
            this.uxUserName = new System.Windows.Forms.TextBox();
            this.uxPassword = new System.Windows.Forms.TextBox();
            this.uxLoginBtn = new System.Windows.Forms.Button();
            this.successText = new System.Windows.Forms.TextBox();
            this.failedText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // uxUserNameLabel
            // 
            this.uxUserNameLabel.AutoSize = true;
            this.uxUserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxUserNameLabel.Location = new System.Drawing.Point(72, 112);
            this.uxUserNameLabel.Name = "uxUserNameLabel";
            this.uxUserNameLabel.Size = new System.Drawing.Size(156, 32);
            this.uxUserNameLabel.TabIndex = 0;
            this.uxUserNameLabel.Text = "User Name";
            // 
            // uxPasswordLabel
            // 
            this.uxPasswordLabel.AutoSize = true;
            this.uxPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxPasswordLabel.Location = new System.Drawing.Point(72, 173);
            this.uxPasswordLabel.Name = "uxPasswordLabel";
            this.uxPasswordLabel.Size = new System.Drawing.Size(139, 32);
            this.uxPasswordLabel.TabIndex = 1;
            this.uxPasswordLabel.Text = "Password";
            // 
            // uxUserName
            // 
            this.uxUserName.Location = new System.Drawing.Point(244, 117);
            this.uxUserName.Name = "uxUserName";
            this.uxUserName.Size = new System.Drawing.Size(316, 26);
            this.uxUserName.TabIndex = 2;
            this.uxUserName.TextChanged += new System.EventHandler(this.uxUserName_TextChanged);
            // 
            // uxPassword
            // 
            this.uxPassword.Enabled = false;
            this.uxPassword.Location = new System.Drawing.Point(244, 173);
            this.uxPassword.Name = "uxPassword";
            this.uxPassword.Size = new System.Drawing.Size(316, 26);
            this.uxPassword.TabIndex = 3;
            this.uxPassword.TextChanged += new System.EventHandler(this.uxPassword_TextChanged);
            // 
            // uxLoginBtn
            // 
            this.uxLoginBtn.BackColor = System.Drawing.Color.Moccasin;
            this.uxLoginBtn.Enabled = false;
            this.uxLoginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLoginBtn.Location = new System.Drawing.Point(258, 309);
            this.uxLoginBtn.Name = "uxLoginBtn";
            this.uxLoginBtn.Size = new System.Drawing.Size(186, 69);
            this.uxLoginBtn.TabIndex = 4;
            this.uxLoginBtn.Text = "Login";
            this.uxLoginBtn.UseVisualStyleBackColor = false;
            this.uxLoginBtn.Click += new System.EventHandler(this.uxLoginBtn_Click);
            // 
            // successText
            // 
            this.successText.Enabled = false;
            this.successText.Location = new System.Drawing.Point(159, 260);
            this.successText.Name = "successText";
            this.successText.Size = new System.Drawing.Size(401, 26);
            this.successText.TabIndex = 5;
            this.successText.TextChanged += new System.EventHandler(this.successText_TextChanged);
            // 
            // failedText
            // 
            this.failedText.Enabled = false;
            this.failedText.Location = new System.Drawing.Point(159, 228);
            this.failedText.Name = "failedText";
            this.failedText.Size = new System.Drawing.Size(401, 26);
            this.failedText.TabIndex = 6;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(687, 450);
            this.Controls.Add(this.failedText);
            this.Controls.Add(this.successText);
            this.Controls.Add(this.uxLoginBtn);
            this.Controls.Add(this.uxPassword);
            this.Controls.Add(this.uxUserName);
            this.Controls.Add(this.uxPasswordLabel);
            this.Controls.Add(this.uxUserNameLabel);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxUserNameLabel;
        private System.Windows.Forms.Label uxPasswordLabel;
        private System.Windows.Forms.TextBox uxUserName;
        private System.Windows.Forms.TextBox uxPassword;
        private System.Windows.Forms.Button uxLoginBtn;
        private System.Windows.Forms.TextBox successText;
        private System.Windows.Forms.TextBox failedText;
    }
}