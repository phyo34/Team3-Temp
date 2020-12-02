using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;
using AuctionLibrary;
using System.ComponentModel;

namespace BID501Server
{
    public class Products
    {
        private BindingList<ProductMessage> p;
        private BindingList<ProductMessage> addedP;


        public BindingList<ProductMessage> GetProduct{ get { return p; } set { this.p = value; } }
        public BindingList<ProductMessage> GetAddedProduct { get { return addedP; } set { this.addedP = value; } }

        public Products(BindingList<ProductMessage> p, BindingList<ProductMessage> newP)
        {
            this.p = p;
            this.addedP = newP;

        }



    }
}
