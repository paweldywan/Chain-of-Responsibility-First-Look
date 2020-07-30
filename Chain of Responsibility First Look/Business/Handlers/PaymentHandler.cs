using Chain_of_Responsibility_First_Look.Business.Exceptions;
using Chain_of_Responsibility_First_Look.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_of_Responsibility_First_Look.Business.Handlers
{
    public class PaymentHandler //: IHandler<Order>
    {
        //private IHandler<Order> Next { get; set; }
        private readonly IList<IReceiver<Order>> receivers;

        public PaymentHandler(params IReceiver<Order>[] receivers)
        {
            this.receivers = receivers;
        }

        public virtual void Handle(Order order)
        {
            //Console.WriteLine($"Running: {GetType().Name}");

            //if(Next == null && order.AmountDue > 0)
            //{
            //    throw new InsufficientPaymentException();
            //}

            //if(order.AmountDue > 0)
            //{
            //    Next.Handle(order);
            //}
            //else
            //{
            //    order.ShippingStatus = ShippingStatus.ReadyForShipment;
            //}

            foreach (var receiver in receivers)
            {
                Console.WriteLine($"Running: {receiver.GetType().Name}");

                if(order.AmountDue > 0)
                {
                    receiver.Handle(order);
                }
                else
                {
                    break;
                }
            }

            if(order.AmountDue > 0)
            {
                throw new InsufficientPaymentException();
            }
            else
            {
                order.ShippingStatus = ShippingStatus.ReadyForShipment;
            }
        }

        //public IHandler<Order> SetNext(IHandler<Order> next)
        //{
        //    Next = next;

        //    return next;
        //}
    }
}
