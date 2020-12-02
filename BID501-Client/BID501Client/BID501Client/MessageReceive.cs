using AuctionLibrary;
using Microsoft.SqlServer.Server;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BID501Client
{
    public class  MessageReceive
    {
        private StateObs observer;
        private StateBidObs bidObservor;
        private ClientController c;
        public void StateObservor(StateObs ob)
        {
            this.observer = ob;
        }

        public void StateBidObservor(StateBidObs ob)
        {
            this.bidObservor = ob;
        }

        public MessageReceive(ClientController c)
        {
            this.c = c;

        }
        public bool MessageReceived(string s)
        {

            //Check to see what type of message it is 
            JsonDeserializer rm = new JsonDeserializer();
            string search = s;
            string[] result = search.Split('#');
            string msgType = result[0];
            string msg = result[1];
            if (msgType != "BadBid" || msgType != "Failed")
                //Will always go through since it is an OR
            {
                bool valid = c.ProcessMesage(msg, msgType);

                switch (msgType)
                {
                    case "Login":
                        if (valid) observer(State.SUCCESS);
                        break;
                    case "BadBid":
                        bidObservor(State.DECLINED);
                        break;
                    case "GoodBid":
                        MessageBox.Show(msg);
                        break;
                    case "Failed":
                        observer(State.DECLINED);
                        break;
                    case "AddProduct":
                        Console.WriteLine("Add Product");                       
                        break;
                    case "CloseProduct":
                        Console.WriteLine("Close Product");
                        break;
                    case "Winner":
                        bidObservor(State.WINNER);
                        break;
                    default:
                        observer(State.DECLINED);
                        break;
                }

            }

            return true;
        }

    }
}
