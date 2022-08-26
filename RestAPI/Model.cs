using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPI
{
    public class post
    {
        /// <summary>
        /// For post Method 
        /// </summary>
        public string name { get; set; }
        public string job { get; set; }
        public post(string N, string J)
        {
            name = N;
            job = J;
        }
    }
    public class patch
    {
        public string name { get; set; }
        public string job { get; set; }

        public patch(string pN, string pJ)
        {
            name = pN;
            job = pJ;
        }
    }
}
