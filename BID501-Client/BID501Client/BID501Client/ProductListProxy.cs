using AuctionLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
namespace BID501Client
{
    public class ProductListProxy 
    {
        private string userName;
        public string GetUserName { get { return userName; } set { this.userName = value; } }

        private  BindingList<ProductMessage> p;


        public  BindingList<ProductMessage> GetProduct { get { return p; } set { 
                this.p = value; 
            }
        }

    
       public ProductListProxy() { }

       public void AddProduct(ProductMessage product)
       {
            p.Add(product);

            foreach(var i in p)
            {
                Console.WriteLine(i.ProductName);
            }
       }
    }


}
