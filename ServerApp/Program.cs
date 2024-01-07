using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerApp.src;

namespace ServerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Starting the Server.
            Server.startServer();

            Console.ReadKey();
        }
    }
}
