using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1
{
    public abstract class Ticket
    {
        public double Price { get; set; }
        public string Destination { get; set; }


    public Ticket(double price, string destination)
        {
            Price = price;
            Destination = destination;
        }
        public override string ToString() {
            return "Price: " + Price + " Destination: " + Destination;


        }

        public void ValidateTicket()
        {
            Console.WriteLine($" Ticket is valid{Destination}");
        }
    }
}
