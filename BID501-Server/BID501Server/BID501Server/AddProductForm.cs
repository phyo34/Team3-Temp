using AuctionLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BID501Server
{
    public partial class AddProductForm : Form
    {
        private Products p;
        private OnAddProduct addProduct;

        public delegate void ShowServerForm (object source, EventArgs args);
        public event ShowServerForm showServerForm;
        public AddProductForm(Products p, OnAddProduct ap)
        {
            this.p = p;
            addProduct = ap;
            
            InitializeComponent();
            uxProductList.DataSource = p.GetAddedProduct;
            uxProductList.DisplayMember = "productName";
        } 

        public void OnShowForm(object sender, EventArgs e)
        {
            Show();
        }

        private void uxAddBtn_Click(object sender, EventArgs e)
        {
            //Gets selected item 
            ProductMessage pp = uxProductList.SelectedItems[0] as ProductMessage;

            if (p != null)
            {              
                    p.GetProduct.Add(pp);               
            }
            p.GetAddedProduct.Remove(pp);
            OnShowServerForm();
            addProduct(pp);
            this.Hide();
        }

        protected virtual void OnShowServerForm()
        {
            if (showServerForm != null)
            {
                showServerForm(this, EventArgs.Empty);
            }
        }
    }
}
