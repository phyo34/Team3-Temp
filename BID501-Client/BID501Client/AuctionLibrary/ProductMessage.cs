using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AuctionLibrary
{

    public class ProductMessage : Message
    {

        private string productName;
        private int bidAmount;
        private int bidCount;
        private string status;
        private bool openOrClose;

        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
               
            }
        }
        public int BidAmount { 
            get { return bidAmount; }
            set { 
                bidAmount = value;
            }
            
        }


        public int  BidCount
        {
            get { return bidCount; }
            set
            {
                bidCount = value;
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
            }
        }

        public bool OpenOrClose
        {
            get { return openOrClose; }
            set
            {
                openOrClose = value;
            }
        }

        public ProductMessage( string productName, int bidAmount, int bidCount, string status)
        {
            this.productName = productName;
            this.bidAmount = bidAmount;
            this.bidCount = bidCount;
            this.status = status;
        }

    
    }
}
