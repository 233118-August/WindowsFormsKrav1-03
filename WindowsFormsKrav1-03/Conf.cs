using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;



namespace WindowsFormsKrav1_03
{
    internal class Conf
    {
        private int freq;
        public int frequenz {
                                get {return freq; }
                                set {freq = value ; }
        }

        public Conf() 
        {

        }
        
    }
}
