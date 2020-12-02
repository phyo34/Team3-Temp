using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BID501Server
{
    public class Credentials
    {
        private Dictionary<string, string> d;
        public  Dictionary<string,string> GetDictionary { get { return d; } set { this.d = value; } }

        public Credentials(Dictionary<string,string> d)
        {
            this.d = d;
        }

        /// <summary>
        /// Validates Credentials
        /// </summary>
        /// <param name="uN">Username</param>
        /// <param name="pN">Password</param>
        /// <returns></returns>
        public string ValidateLogin(string uN, string pN)
        {
            foreach (var i in d)
            {
                //If username matches password
               if (d.ContainsKey(uN) && d[uN].Equals(pN))
               return "Good";
               //If username des not math password
               if (d.ContainsKey(uN) && !d[uN].Equals(pN))
               return "Bad";
            }
            //If credentials  do not exist 
            return "New";
        }

        /// <summary>
        /// Adds the new credentials to the dictionary
        /// </summary>
        /// <param name="uN">username</param>
        /// <param name="pN">passwords</param>
        public void Add(string uN, string pN)
        {         
            d.Add(uN, pN);          
        }

      

    }
}
