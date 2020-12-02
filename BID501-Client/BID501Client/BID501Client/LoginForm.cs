using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BID501Client
{
    public partial class LoginForm : Form
    {
        public delegate void ShowBidForm (object source, EventArgs args);
        public event ShowBidForm showBidForm;
        //This is to show what state it is in, and pass the password to it
        InputHandler iHandler;

 
        public LoginForm(InputHandler ih)
        {
            InitializeComponent();
            this.iHandler = ih;

        }

        public LoginForm() { }
        /// <summary>
        /// Passing in username and password when the state is "Got Password"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLoginBtn_Click(object sender, EventArgs e)
        {
            string up = uxPassword.Text;
            string un = uxUserName.Text;
            iHandler(State.LOGIN, un + ":" + up);

        }

        /// <summary>
        /// This method keepts the GUI controlls enabled/disabled, displaying the
        /// right information based on the App's satate.
        /// </summary>
        /// <param name="state"></param>
        public void StateObservor(State state)
        {
            switch (state)
            {
                case State.START:
                    Invoke(new Action(() => MessageBox.Show("Please Enter Username and Password"))); 
                    break;
                case State.LOGIN:
                    MessageBox.Show( "Validating Credentials...");
                    break;
                case State.DECLINED:
                    Invoke(new Action(() => uxUserName.Text = ""));
                    Invoke(new Action(() => uxPassword.Text = ""));
                    Invoke(new Action(() => failedText.Text = "Invalid Credentials. Please try again."));
                    break;
                case State.SUCCESS:
                    Invoke(new Action(() => successText.Text = "SUCCESS"));
                    break;
                default:
                    MessageBox.Show("Invalid State");
                    break;

            }
        }
     

        private void uxPassword_TextChanged(object sender, EventArgs e)
        {
            uxLoginBtn.Enabled = true;

        }

        private void uxUserName_TextChanged(object sender, EventArgs e)
        {
            uxPassword.Enabled = true;
        }

      

        protected virtual void OnShowBidForm()
        {
            showBidForm?.Invoke(this, EventArgs.Empty);
        }

        private void successText_TextChanged(object sender, EventArgs e)
        {
            OnShowBidForm();
            this.Hide();
        }

      
    }
}
