using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tosen2
{
    class initConf
    {
        public string ip { set; get; }
        public string id { set; get; }
        public string pw { set; get; }
        
        public void get()
        {
            string mPath = @"conf\connect.txt";

            try
            {
                StreamReader sr = new StreamReader(mPath, Encoding.GetEncoding("Shift_JIS"));

                while(sr.Peek() != -1)
                {

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        } 
    }
}
