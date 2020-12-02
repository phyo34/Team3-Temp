using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionLibrary
{
  public  class Message
    {
        public Message()
        {

        }
        /// <summary>
        /// Creates the Login Message
        /// </summary>
        /// <param name="type"></param>
        /// <param name="uN"></param>
        /// <param name="uP"></param>
        /// <returns></returns>
        public static Message CreateMessage(string uN, string uP)
        {
            return new LoginMessage( uN, uP);
        }

        /// <summary>
        /// Creates the product message
        /// </summary>
        /// <param name="type"></param>
        /// <param name="productName"></param>
        /// <param name="bidAmount"></param>
        /// <param name="bidCount"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static Message CreateMessage(string productName, int bidAmount, int bidCount, string status)
        {
            return new ProductMessage( productName, bidAmount, bidCount, status);
        }

        public static Message CreateBidMessage (string productName, int bid)
        {
            return new BidMessage(productName, bid);
        }
    }
}
