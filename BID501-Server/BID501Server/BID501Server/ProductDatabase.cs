using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using AuctionLibrary;
using System.ComponentModel;
using System.Windows.Forms;

namespace BID501Server
{
    public class ProductDatabase
    {
        
       
        public ProductDatabase ()
        {
           
          
        }

    
        ///<summary>
        /// Loads products into a list
        /// </summary>
        /// <returns>list of product </returns>
        public BindingList<ProductMessage> LoadProduct()
        {
            string pp = Application.StartupPath + @"\Products.json";

            //We'll have to use iteration to find something 
            string json = File.ReadAllText(pp);
            var productList = JsonConvert.DeserializeObject<BindingList<ProductMessage>>(json);



            return productList;
        }


        ///<summary>
        /// Loads new products into a list
        /// </summary>
        /// <returns>list of new products </returns>
        public BindingList<ProductMessage> LoadNewProducts()
        {
            string pp = Application.StartupPath + @"\NewProducts.json";

            //We'll have to use iteration to find something 
            string json = File.ReadAllText(pp);
            var productList = JsonConvert.DeserializeObject<BindingList<ProductMessage>>(json);



            return productList;
        }
        /// <summary>
        /// Writes list of products to the json file
        /// </summary>
        /// <param name="p">list of product</param>
        public void Write(BindingList<ProductMessage> p, BindingList<ProductMessage> nnp)
        {
            string pp = Application.StartupPath + @"\Products.json";
            //Write to file
            string json = JsonConvert.SerializeObject(p);
            File.WriteAllText(pp, json);

            string np = Application.StartupPath + @"\NewProducts.json";
            //Write to file
            string newPJson = JsonConvert.SerializeObject(nnp);
            File.WriteAllText(np, newPJson);
        }
       
    }
}
