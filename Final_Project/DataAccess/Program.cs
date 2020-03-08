using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SODA;
using SODA.Models;
using SODA.Utilities;
using Json.Net;

namespace DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = new SodaClient("https://www.datos.gov.co", "8naPxF3oQIYI1NiilJm2JgR3q");

            // Get a reference to the resource itself
            // The result (a Resouce object) is a generic type
            // The type parameter represents the underlying rows of the resource
            // and can be any JSON-serializable class

            var dataset = client.GetResource("ysq6-ri4e.json?" +
                "$select=variable&$group=variable");

            // Resource objects read their own data
            var rows = dataset.GetRows(limit: 5000);

            Console.WriteLine("Got {0} results. Dumping first results:", rows.Count());

            foreach (var keyValue in rows.First())
            {
                Console.WriteLine(keyValue);
            }

            /*
             * the first number in seconds
             */
            Thread.Sleep(60 * (Int32)Math.Pow(10, 3));

        }
    }
}
