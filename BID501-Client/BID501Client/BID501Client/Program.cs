using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BID501Client
{
    //Delegate takes in the state, and the string from that state. For example, if in "Username" state, then it will pass the username string
    public delegate void InputHandler(State state, String args);
    //This delegate passes in the state
    public delegate void StateObs(State state);
    //This delegate passes in the state
    public delegate void StateBidObs(State state);

    public delegate bool MessageReceived(string message);

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static ClientController c;

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            ProductListProxy p = new ProductListProxy();
            c = new ClientController(p);

            LoginForm lf = new LoginForm(c.InputHandler);
            BidForm bf = new BidForm(c.GetProxy, c.InputHandler);


            lf.showBidForm += bf.OnShowForm;
            c.StateObservor(lf.StateObservor);
            c.StateBidbservor(bf.StateObservor);
            MessageReceive r = new MessageReceive(c);
            r.StateObservor(lf.StateObservor);
            r.StateBidObservor(bf.StateObservor);
            c.MessageReceived += r.MessageReceived;

            Application.Run(lf);
        }
    }
}
