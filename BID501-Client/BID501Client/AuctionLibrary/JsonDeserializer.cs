using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

namespace AuctionLibrary
{
    public class JsonDeserializer 
    {


        public JsonDeserializer()
        {
          
        }

        /// <summary>
        /// Deserializes the product message
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public ProductMessage DeserializeProductMessage(string msg)
        {      
                ProductMessage product = JsonConvert.DeserializeObject<ProductMessage>(msg);
                return product;
        }

        /// <summary>
        /// Deserializes the login message 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public LoginMessage DeserializeLoginMessage(string msg)
        {        
           LoginMessage login = JsonConvert.DeserializeObject<LoginMessage>(msg);
            return login;
        }


        /// <summary>
        /// Deserializes the bid message 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public BidMessage DeserializeBidMessage(string msg)
        {
            BidMessage login = JsonConvert.DeserializeObject<BidMessage>(msg);
            return login;
        }

    }
}
