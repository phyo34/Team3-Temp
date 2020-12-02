using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionLibrary
{
   public class LoginMessage : Message
    {
    
        public string userName { get; set; }
        public string password { get; set; }
        public LoginMessage( string uN, string pN)
        {
            this.userName = uN;
            this.password = pN;
         
        }
    }
}
