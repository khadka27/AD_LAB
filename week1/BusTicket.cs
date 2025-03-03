

namespace week1
{

    public class BusTicket : Ticket, IRefundable
    {


        public void ValidateTicket()
        {
            Console.WriteLine("Bus ticket is valid");
        }



        public string BusNumber { get; set; }


        public BusTicket(double price, string destination) : base(price, destination)
        {
            Price = price;
            Destination = destination;
        }




        public void ProcessRefund()
        {
            //throw new NotImplementedException();
            Console.WriteLine($"ProcessRefund {BusNumber} ");
        }

        public void ApplyDiscount()
        {

        }
    }

}
