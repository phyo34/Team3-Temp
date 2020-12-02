using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using AuctionLibrary;
using System.Data.SqlTypes;

namespace BID501Server
{
    /// <summary>
    /// Class is responsible for retrieving credential information from Json files
    /// </summary>
  public  class CredentialsDatabase
    {

        public CredentialsDatabase()
        {
        }

    
        /// <summary>
        /// Writes the dictionary of credentials to the json file
        /// </summary>
        /// <param name="s">Dictionary to write to json</param>
        public void Write(Dictionary<string,string> d)
        {
             string lp = Application.StartupPath + @"\Credentials.json";
             //Write to file
             string json = JsonConvert.SerializeObject(d); 
             File.WriteAllText(lp, json);
           
            
        }

        /// <summary>
        /// Loads credentials into a Dictionary
        /// </summary>
        /// <returns>Returns the Dictionary of credentials</returns>
        public Dictionary<string, string> Load()
        {
            string lp = Application.StartupPath + @"\Credentials.json";
            var text = File.ReadAllText(lp);
            //this is the list od deserialized login messages
            var output = JsonConvert.DeserializeObject<Dictionary<string,string>>(text);
           return output;
        }  
      
    }
}
