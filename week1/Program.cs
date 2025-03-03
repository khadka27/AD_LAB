
// main method

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1
{
    class Program
    {
        static void Main(string[] args)
        {
            TrainTicket trainTicket = new TrainTicket(100, "New York");
            BusTicket busTicket = new BusTicket(50, "New Jersey");
            Console.WriteLine(trainTicket.ToString());
            Console.WriteLine(busTicket.ToString());
            trainTicket.ValidateTicket();
            busTicket.ValidateTicket();
        }
    }
}