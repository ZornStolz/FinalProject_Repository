using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SODA;
using Json.Net;
using System.Net;
using System.IO;

namespace DataAccess
{
    class Program
    {
        /*
         * source data to be consulted
         */
        public static String URL = "https://www.datos.gov.co/resource/ysq6-ri4e.json?";

        static void Main(string[] args)
        {
            readInfo(URL + "variable=CO&$limit=5");

            /*
             * the first number in seconds
             */
            Thread.Sleep(60 * (Int32)Math.Pow(10, 3));

        }

        private static void readInfo(String query)
        {
            string result = "";
            try
            {
                var url = query;
                var client = new WebClient();
                using (var stream = client.OpenRead(url))
                using (var reader = new StreamReader(stream))
                {
                    String line = reader.ReadLine();
                    int count = 0;
                    while ((line = reader.ReadLine()) != null && count <= 10)
                    {
                        String[] args = line.Split(',');
                        Console.WriteLine(args[count]);
                        count++;
                    }
                    reader.Close();
                    stream.Close();
                }

            }
            catch (WebException e)
            {
                result = string.Format("F", e);
                Console.WriteLine(result);
            }

        }


    } 
}
