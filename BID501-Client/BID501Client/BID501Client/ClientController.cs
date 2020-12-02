using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using AuctionLibrary;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BID501Client
{

    /// <summary>
    /// The valid App states.
    /// </summary>
    public enum State
    {
        NOTINIT = -1,
        START = 0,
        LOGIN,
        BID,
        SUCCESS,
        PROCESS,
        DECLINED,
        WINNER,
        EXIT,
        CLOSE
    }
  public  class ClientController
    {

        private ProductListProxy _proxy;
        private StateObs observer;
        private StateBidObs bidObservor;

        
        public ProductListProxy GetProxy { get { return _proxy; } set { this._proxy = value; } }


        private WebSocket ws;


        // Event for when a message is received from the server
        public event MessageReceived MessageReceived;




        public ClientController(ProductListProxy p)
        {

            this._proxy = p;
            // Connects to the server
            ws = new WebSocket("ws://127.0.0.1:8002/MessageReceived");
            ws.OnMessage += (sender, e) => { MessageReceived(e.Data); };


       
            ws.Connect();

        }
        public void StateObservor(StateObs ob)
        {
            this.observer = ob;
        }

        public void StateBidbservor(StateBidObs ob)
        {
            this.bidObservor = ob;
        }


        /// <summary>
        /// Based on the state the controller will act and apply
        /// the logic needed to process the information. After taking action,
        /// it will notify the view of the result.
        /// </summary>
        /// <param name="state">The state passed in</param>
        /// <param name="args">The string associated given the state</param>
        public void InputHandler (State state, String args)
        {
            switch (state)
            {
                case State.START:

                    observer(State.START);
                    break;
              
                case State.LOGIN:
                    //Call method for validation
                    bool valid = ValidateLoginLocally(args);
                    if (valid)
                    {      
                        //Serialize login object  
                        AuctionLibrary.Message msg = CreateLoginMessage(args);
                        //Send serialized the object 
                        ws.Send("Login#"+SerializeMessage(msg));
                       
                    }
                    else
                    {
                        observer(State.DECLINED);
                        
                    }
                    break;
                case State.BID:
                    bidObservor(State.BID);
                    bool validBid = ValidateBidLocally(args);
                    if (validBid)
                    {
                        //Serialize login object  
                        AuctionLibrary.Message msg = CreateBidMessage(args);
                        //Send serialized the object 
                        ws.Send("Bid#"+SerializeMessage(msg));
                    }
                    else
                    {
                        bidObservor(State.DECLINED);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Validate Bid 
        /// </summary>
        /// <param name="args">The nameof product  and amount of the bid</param>
        /// <returns>Returns true if valid</returns>
        private bool ValidateBidLocally(string args)
        {
            string search = args;
            string[] result = search.Split(':');
            string productName = result[0];
            int bidAmount;
            bool isNumeric = int.TryParse(result[1], out bidAmount);
           


                if (result[0] != null && result[1] != null)
                {
                    if (isNumeric)
                    {
                        foreach (var item in _proxy.GetProduct)
                        {
                            if (productName == item.ProductName && bidAmount >= item.BidAmount) return true;
                        }
                    }
                 
                }
            
          

            return false;
        }

        /// <summary>
        /// Locally validates credentials by making sure nothing is null
        /// </summary>
        /// <param name="args">String to validate</param>
        /// <returns>Returns bool</returns>
        private bool ValidateLoginLocally(string args)
        {
            string search = args;
            string[] result = search.Split(':');
            _proxy.GetUserName = result[0];
            if (result[0] != null && result[1] != null) return true;
             return false;
        }
        /// <summary>
        /// Creates the login message 
        /// </summary>
        /// <param name="cred">Creates login message </param>
        /// <returns></returns>
        private AuctionLibrary.Message CreateLoginMessage(string args)
        {
            string search = args;
            string[] result = search.Split(':');
            AuctionLibrary.Message msg = new LoginMessage( result[0], result[1]);
            return msg;
        }


        private AuctionLibrary.Message CreateBidMessage(string args)
        {
            //Implement BID message
            string search = args;
            string[] result = search.Split(':');
            string productName = result[0];
            int bidAmount = Convert.ToInt32(result[1]);

            AuctionLibrary.Message msg = new BidMessage(productName, bidAmount);

            return msg;
        }

        private string SerializeMessage(AuctionLibrary.Message msg)
        {
           JSONSerializer serializer = new JSONSerializer(msg);
            return serializer.SerializeMessage(msg);


        }


        public bool ProcessMesage(string s, string msgType)
        {
           
            JsonDeserializer rm = new JsonDeserializer();


            if (msgType == "Bid")
            {
                var productList = Newtonsoft.Json.JsonConvert.DeserializeObject<BindingList<ProductMessage>>(s);
                foreach (var realItem in productList)
                {
                    foreach (var proxyItem in _proxy.GetProduct)
                    {
                        if (realItem.ProductName == proxyItem.ProductName && realItem.BidAmount == proxyItem.BidAmount)
                        {
                            _proxy.GetProduct = productList;
                            
                            return true;
                        }
                    }
                }


                return false;

            }

            else if (msgType == "Login")
            {

                if (s == "Failed") return false;
                else
                {
                    var productList = Newtonsoft.Json.JsonConvert.DeserializeObject<BindingList<ProductMessage>>(s);

                    _proxy.GetProduct = productList;

                    return true;

                }


            }

            else if (msgType == "AddProduct")
            {
                var product = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductMessage>(s);
                var ProductList = _proxy.GetProduct;
                ProductList.Add(product);
                _proxy.GetProduct = ProductList;
            }

            else if (msgType == "CloseProduct")
            {
                var product = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductMessage>(s);
                var ProductList = _proxy.GetProduct;
                int index =0;
                for (int i = 0; i < _proxy.GetProduct.Count; i++)
                {
                    if (_proxy.GetProduct[i].ProductName == product.ProductName)
                    {
                        index = i;
                        break;
                    }
                }
                  ProductList.RemoveAt(index);           
                _proxy.GetProduct = ProductList;
             

            }
            else if (msgType == "Winner")
            {
                MessageBox.Show(s);
            }
       
            return false;
        }

     




    }
}
