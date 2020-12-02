using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using AuctionLibrary;

namespace BID501Client
{
    public partial class BidForm : Form
    {
    
        private ProductListProxy p;
        //This is to show what state it is in, and pass the password to it
        InputHandler iHandler;
        private System.Timers.Timer timer;

        public BidForm( ProductListProxy p, InputHandler ih)
        {
            this.p = p;
           
            InitializeComponent();
            this.iHandler = ih;
        }

        public void BidForm_Load(object sender, EventArgs e)
        {
            this.Text = "BID501 - Welcome " + p.GetUserName + "!";


            listBox1.DataSource = p.GetProduct;
            listBox1.DisplayMember = "productName";

            //create instance of a timer
            timer = new System.Timers.Timer();
            ///Sets timer to 1 sec
            timer.Interval = 1000;
            //make an elapsed event handler 
            timer.Elapsed += CheckTimer;
            //start timer
            timer.Start();

           
        }
        ProductMessage curSelection;

        private void CheckTimer(object sender, ElapsedEventArgs e)
        {
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            if (curSelection != null)
            {

                foreach (var curItem in p.GetProduct)
                {
                  
                        //if status is open
                        if (curSelection.ProductName == curItem.ProductName)
                        {
                            this.Invoke(new Action(() => { uxName.Text = curItem.ProductName; }));
                            this.Invoke(new Action(() => { uxMin.Text = "$" + curItem.BidAmount.ToString(); }));
                            this.Invoke(new Action(() => { uxCount.Text = "(" + curItem.BidCount.ToString() + ")"; }));

                        this.Invoke(new Action(() => { uxMin.Enabled = true; }));
                        this.Invoke(new Action(() => { uxCount.Enabled = true; }));
                        this.Invoke(new Action(() => { uxBidAmount.Enabled = true; }));


                        this.Invoke(new Action(() => { uxPlaceBidBtn.Enabled = true; }));

                        if (curItem.Status == "good") this.Invoke(new Action(() => { uxStatus.BackColor = Color.Green; }));
                            else this.Invoke(new Action(() => { uxStatus.BackColor = Color.Red; }));

                        }


                    


                }

            
              
                
                       

                
            }
            this.Invoke(new Action(() => { listBox1.DataSource = null; }));
            this.Invoke(new Action(() => { listBox1.DataSource = p.GetProduct; }));
            this.Invoke(new Action(() => { listBox1.DisplayMember = "productName"; }));


        }

        public void OnShowForm(object sender, EventArgs e)
        {
            this.Show();

        }


        private void listBox1_Click(object sender, EventArgs e)
        {
            ProductMessage pp = listBox1.SelectedItems[0] as ProductMessage;
            curSelection = pp;
           
            if (p != null)
            {
                foreach (var curItem in p.GetProduct) 
                {
                    //if status is open
                    if (curSelection.ProductName == curItem.ProductName && curItem.OpenOrClose == true)                 
                    {
                        this.Invoke(new Action(() => { uxName.Text = curItem.ProductName; }));
                        this.Invoke(new Action(() => { uxMin.Text = "$" + curItem.BidAmount.ToString(); }));
                        this.Invoke(new Action(() => { uxCount.Text = "(" + curItem.BidCount.ToString() + ")"; }));

                        this.Invoke(new Action(() => { uxMin.Enabled = true; }));
                        this.Invoke(new Action(() => { uxCount.Enabled = true; }));
                        this.Invoke(new Action(() => { uxBidAmount.Enabled = true; }));


                        this.Invoke(new Action(() => { uxPlaceBidBtn.Enabled = true; }));

                        if (curItem.Status == "good") this.Invoke(new Action(() => { uxStatus.BackColor = Color.Green; }));
                        else this.Invoke(new Action(() => { uxStatus.BackColor = Color.Red; }));

                    }


                }
            
            }


        }

     
        private void uxPlaceBidBtn_Click(object sender, EventArgs e)
        {
            string name = uxName.Text;
            string amount = uxBidAmount.Text;


            uxBidAmount.Text = "";
            iHandler(State.BID, name + ":" + amount);
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
                    MessageBox.Show("Please Enter Username and Password");
                    break;
                case State.BID:
                    MessageBox.Show("Validating Bid...");
                    break;
            
                case State.DECLINED:
                    Invoke(new Action(() => MessageBox.Show(" Bid Declined"))); ;

                    break;
                case State.WINNER:
                    this.Invoke(new Action(() => { uxName.Text = ""; }));
                    this.Invoke(new Action(() => { uxMin.Enabled = false; }));
                    this.Invoke(new Action(() => { uxCount.Enabled = false; }));
                    this.Invoke(new Action(() => { uxBidAmount.Enabled = false; }));


                    this.Invoke(new Action(() => { uxPlaceBidBtn.Enabled = false; }));



                    break; 
                default:
                    MessageBox.Show("Invalid State");
                    break;

            }
        }

    }
}
