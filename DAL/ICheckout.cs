using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICheckout
    {
       
        List<Order> ProceedTOCheckout(string Username);
       
        List<FinalOrder> FinalBuy(int id);
        void deleteOrder(int id);
        Order getOrder(int id);
        List<Order> DisplayCheckout(string Username);
    }
}
