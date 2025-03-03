using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1
{
    public class TrainTicket:Ticket, IRefundable
    {

        public string SeatNumber { get; set; }



        // constoctor
        public TrainTicket(double price, string destination) : base(price, destination)
        {
            Price = price;
            Destination = destination;
        }

        public void ProcessRefund()
        {
            //throw new NotImplementedException();
            Console.WriteLine($"Refund processed{SeatNumber}");
        }

        public void ApplyDiscount()
        {
            throw new NotImplementedException();
        }
    }


}
