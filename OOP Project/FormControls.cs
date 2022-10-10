using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class FormControls
    {
        private static string username, id;
        
        public static string registrationclose="No",updateinfo="No",QuickView="";


        public static string Username
        {
            get { return username; }
            set { username = value; }
        }

        public static string Id
        {
            get { return id; }
            set { id = value; }
        }


    }
}
