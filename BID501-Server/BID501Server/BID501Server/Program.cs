using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;
using AuctionLibrary;

namespace BID501Server
{
    public delegate void OnAddProduct(ProductMessage pm);
    public delegate void BrodcastMessage(string message);

    public class Program
    {  //Start a websocket server at port 8001;
        public static WebSocketServer wss = new WebSocketServer(8002);
        public static ServerController serverController;
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            CredentialsDatabase cd = new CredentialsDatabase();
            ProductDatabase pd = new ProductDatabase();

            Products p = new Products(pd.LoadProduct(), pd.LoadNewProducts()) ;
            Credentials c = new Credentials(cd.Load());
            serverController = new ServerController(p, c, wss);

            ServerForm sf = new ServerForm(serverController);
            AddProductForm af = new AddProductForm(p, serverController.OnAddProduct);
            
            sf.showAddForm += af.OnShowForm;
            af.showServerForm += sf.OnShowForm;
            sf.closeProduct += serverController.OnCloseProduct;
            wss.ReuseAddress = true;
        

            // Add the Chat websocket service
            wss.AddWebSocketService<MessageReceived>("/MessageReceived");

            // Start the server
            wss.Start();

      
            Application.Run(sf);

          
            // Stop the server
            wss.Stop();


        }
    }
}
