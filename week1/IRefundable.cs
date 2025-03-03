using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace week1
{

    public interface IRefundable
    {
        void ProcessRefund();
      


    }

    public interface IDiscountable
    {
        void ApplyDiscount();
    }
}
