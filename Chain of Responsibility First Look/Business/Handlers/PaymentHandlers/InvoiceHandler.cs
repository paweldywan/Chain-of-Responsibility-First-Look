using Chain_of_Responsibility_First_Look.Business.Models;
using Chain_of_Responsibility_First_Look.Business.PaymentProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_of_Responsibility_First_Look.Business.Handlers.PaymentHandlers
{
    public class InvoiceHandler : IReceiver<Order> //PaymentHandler
    {
        private readonly InvoicePaymentProcessor InvoicePaymentProcessor = new InvoicePaymentProcessor();

        public void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Invoice))
                InvoicePaymentProcessor.Finalize(order);
        }
    }
}
