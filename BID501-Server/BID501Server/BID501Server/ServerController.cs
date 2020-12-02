using AuctionLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace BID501Server
{ 
    public class ServerController : WebSocketBehavior
    {
        private string serializedmsg;
        private Products p;
        private Credentials c;
        private BindingList<string> LoggedInClients;
        private WebSocketServer wss;

        private Dictionary<string, string> TopBids = new Dictionary<string, string>();
        private Dictionary<string, string> Users = new Dictionary<string, string>();

        public BindingList<string> GetClientList { get { return LoggedInClients; } set { this.LoggedInClients = value; } }
        public ServerController(Products p, Credentials c, WebSocketServer server)
        {
            this.p = p;
            this.c = c;
            wss = server;
            serializedmsg = "";

        }

        public BindingList<ProductMessage> ProductList()
        {
            return p.GetProduct;
        }
        public BindingList<ProductMessage> NewProductsList()
        {
            return p.GetAddedProduct;
        }

        /// <summary>
        /// Processes messages recieved from client. 
        /// If message is a sucessful login, server will return product list.
        /// If message is 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="msgType"></param>
        /// <returns></returns>
        public string  ProcessMessage(string s,string msgType )
        {

            string[] splitter = s.Split('#');
            string msg = splitter[0];
            string ID = splitter[1];
            // Retrieve message from client
            serializedmsg = msg;
            //Check to see what type of message it is 
            JsonDeserializer rm = new JsonDeserializer();

            string returnmsg = "";

            switch (msgType)
            {
                    case "Login":
                    
                    LoginMessage login = rm.DeserializeLoginMessage(serializedmsg);

                    string valid = c.ValidateLogin(login.userName, login.password);

                    switch (valid)
                    {
                        case "Good":
                            {
                                AddUser(ID, login.userName);
                                //Serialize list of product
                                
                                returnmsg = "Login#" + JsonConvert.SerializeObject(p.GetProduct);
                                break;
                            }
                        case "New":                                                                                 
                        case "Bad":
                            {
                                returnmsg = "Failed#failed";
                                break;

                            }
                           
                        default:
                            break;
                    }
                    //Add to the list if it is new user
                    if (valid == "New") c.Add(login.userName, login.password);
                    break;
                case "Bid":
                   
                    BidMessage bid = rm.DeserializeBidMessage(msg);
                    bool validProduct = ValidateBid(bid.productName,bid.bidAmount);
                    if (validProduct)
                    {
                        returnmsg = "Bid#" + JsonConvert.SerializeObject(p.GetProduct);

                        AddTopBid(bid.productName,ID);
                    }
                    else
                    {
                        returnmsg = "BadBid#" + JsonConvert.SerializeObject(p.GetProduct);

                    }
                    break;
                default:
                    break;
            }
            return returnmsg;
        }

        public void AddTopBid(string productName,string ID)
        {
            string val;
            if (TopBids.TryGetValue(productName, out val))
            {
                TopBids[productName] = ID;
            }
            else
            {
                // darn, lets add the value
                TopBids.Add(productName, ID);
            }

        }

        public void AddUser(string ID, string userName)
        {
            string val;
            if (Users.TryGetValue(ID, out val))
            {
                Users[ID] = userName;
            }
            else
            {
                // darn, lets add the value
                Users.Add(ID, userName);
            }
        }
        /// <summary>
        /// Writes data to files 
        /// </summary>
        public void WriteToFiles()
        {
            CredentialsDatabase cd = new CredentialsDatabase();
            cd.Write(c.GetDictionary);

            ProductDatabase pd = new ProductDatabase();
            pd.Write(p.GetProduct,p.GetAddedProduct); 
        }

        public bool ValidateBid(string name, int bid)
        {

            foreach (var item in p.GetProduct)
            {
                if (name == item.ProductName && bid > item.BidAmount && item.BidCount > 0)
                {
                    item.BidAmount = bid;
                    item.BidCount--;
                    if (item.BidCount - 1 < 0)
                        item.Status = "bad";
                    return true;

                }
                if (name == item.ProductName && bid == item.BidAmount && item.BidCount > 0)
                {
                    item.BidAmount = bid + 10;
                    item.BidCount--;
                    if (item.BidCount - 1 < 0)
                        item.Status = "bad";
                    return true;
                }
            }
            return false;
        }

        public void OnAddProduct(ProductMessage p)
        {
            string message = "AddProduct#" + JsonConvert.SerializeObject(p);
            wss.WebSocketServices.Broadcast(message);
        }

        public void AddLoggedInClient(IEnumerable<string> list)
        {
            BindingList<string> Clients = new BindingList<string>();
                  foreach(var log in list)  
                 Clients.Add("Client " + log);
            LoggedInClients = Clients;
           
        }

        public void RemoveLoggedInClient(IEnumerable<string> list,string ID)
        {
            BindingList<string> Clients = new BindingList<string>();
            foreach (var log in list)
            {
                Clients.Add("Client " + log);

               
            }

            foreach (var log in list)
            {
                if (log == ID)
                Clients.Remove("Client " + log);


            }

            LoggedInClients = Clients;

        }



        public void OnCloseProduct(object source, ProductMessage msg)
        {

            string message = "CloseProduct#" + JsonConvert.SerializeObject(msg);
            p.GetProduct.Remove(msg);
            string val;
            TopBids.TryGetValue(msg.ProductName, out val);
            string userName;
            Users.TryGetValue(val, out userName);
            wss.WebSocketServices.Broadcast("Winner#Winner for the " + msg.ProductName + " is "+ userName);
            wss.WebSocketServices.Broadcast(message);


        }
    }
}
