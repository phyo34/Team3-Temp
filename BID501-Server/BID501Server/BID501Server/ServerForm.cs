using AuctionLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace BID501Server
{
    
    public partial class ServerForm : Form
    {
        public delegate void ShowAddForm(object source, EventArgs args);
        public event ShowAddForm showAddForm;

        public delegate void CloseProduct(object source, ProductMessage args);
        public event CloseProduct closeProduct;
        private ServerController c;
        private System.Timers.Timer timer;


        public ServerForm(ServerController c)
        {
            this.c = c;
            InitializeComponent();
           
        }

        private void uxAddBtn_Click(object sender, EventArgs e)
        {
            OnShowAddForm();
            
        }

        private void uxCloseButton_Click(object sender, EventArgs e)
        {
            ProductMessage selectedProduct = uxProductList.SelectedItem as ProductMessage;
            MessageBox.Show("Closing product");
            
            OnCloseProduct(selectedProduct);

        }
        protected virtual void OnCloseProduct(ProductMessage msg)
        {
           
            closeProduct?.Invoke(this, msg);

        }


        protected virtual void OnShowAddForm()
        {
            showAddForm?.Invoke(this, EventArgs.Empty);
            Hide();
        }

        public void OnShowForm(object source, EventArgs e)
        {          
            this.Show();

        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            uxProductList.DataSource = c.ProductList();
            uxProductList.DisplayMember = "productName";
            uxClientList.DataSource = c.GetClientList;
            //create instance of a timer
            timer = new System.Timers.Timer();
            ///Sets timer to 1 sec
            timer.Interval = 1000;
            //make an elapsed event handler 
            timer.Elapsed += CheckTimer;
            //start timer
            timer.Start();
        }
        private void CheckTimer(object sender, ElapsedEventArgs e)
        {
            UpdateList();
        }

        private void UpdateList()
        {
            this.Invoke(new Action(() => { uxClientList.DataSource = null; }));
            this.Invoke(new Action(() => { uxClientList.DataSource = c.GetClientList; }));
        }

     
    }
}
