using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionLibrary
{
   public class BidMessage : Message
    {

        public string productName { get; set; }
        public int bidAmount { get; set; }
        public BidMessage(string productName, int bidAmount)
        {
            this.productName = productName;
            this.bidAmount = bidAmount;
        }
    }
}
