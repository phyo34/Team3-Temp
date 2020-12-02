using AuctionLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace BID501Server
{
    class MessageReceived : WebSocketBehavior, IWebSocketSession
    {
        protected override void OnOpen()
        {                    
        }
        /// <summary>
        /// Could implement a switch 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMessage(MessageEventArgs e)
        {
            string search = e.Data;
            string[] result = search.Split('#');
            string msgType = result[0];
            string msg = result[1];

            switch (msgType)
            {
                case "Login":
                    string jsonLogin = Program.serverController.ProcessMessage(msg+"#"+ID, msgType);
                    string[] split = search.Split('#');
                    string resultFromServer = result[0];
                    //If client is succesfully logged in, add to client list
                    if (resultFromServer == "Login")
                    Program.serverController.AddLoggedInClient(Sessions.IDs);
                    Sessions.SendTo(jsonLogin, ID);
                 
                    break;
                case "Bid":
                    string jsonBid = Program.serverController.ProcessMessage(msg+"#"+ID, msgType);
                    string[] checkBid = search.Split('#');
                    string status = result[0];
                    
                   // MessageBox.Show(ID.ToString());
                    if (status == "BadBid")
                        Sessions.SendTo("BadBid#Bad", ID);
                    else
                        Sessions.SendTo("GoodBid#Your bid went through!", ID);

                    Sessions.Broadcast(jsonBid);
                    break;
                default:
                    break;

            }
        }

        public void SendWinnerMessage(string winner)
        {
            Sessions.SendTo("Winner#Winner",winner);
        }

        
        protected override void OnClose(CloseEventArgs e)
        {
            Program.serverController.RemoveLoggedInClient(Sessions.IDs, ID);


            Program.serverController.WriteToFiles();
        }
    }
}
