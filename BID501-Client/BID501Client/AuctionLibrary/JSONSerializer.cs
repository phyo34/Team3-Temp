using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
namespace AuctionLibrary
{
   public class JSONSerializer
    {
        private Message msg;
        public JSONSerializer(Message msg)
        {
            this.msg = msg;
        }

        public string SerializeMessage(Message msg)
        {
            return JsonConvert.SerializeObject(msg);
        }
    }
}
