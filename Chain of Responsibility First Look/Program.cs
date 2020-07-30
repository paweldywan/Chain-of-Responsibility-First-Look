using Chain_of_Responsibility_First_Look.Business;
using Chain_of_Responsibility_First_Look.Business.Handlers;
using Chain_of_Responsibility_First_Look.Business.Handlers.PaymentHandlers;
using Chain_of_Responsibility_First_Look.Business.Models;
using Chain_of_Responsibility_First_Look.Business.PaymentProcessors;
using System;
using System.Globalization;

namespace Chain_of_Responsibility_First_Look
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = args;


            UserProcessor();

            WriteSeparator();

            PaymentProcessor();


            Console.ReadKey();
        }

        private static void UserProcessor()
        {
            var user = new User("Filip Ekberg",
                            "870101XXXX",
                            new RegionInfo("SE"),
                            new DateTimeOffset(1987, 01, 29, 00, 00, 00, TimeSpan.FromHours(2)));

            var processor = new UserProcessor();

            var result = processor.Register(user);

            Console.WriteLine(result);
        }

        private static void WriteSeparator()
        {
            Console.WriteLine("---");
            Console.ReadKey();
        }

        private static void PaymentProcessor()
        {
            var order = new Order();
            order.LineItems.Add(new Item("ATOMOSV", "Atomos Ninja V", 499), 2);
            order.LineItems.Add(new Item("EOSR", "Canon EOS R", 1799), 1);

            order.SelectedPayments.Add(new Payment
            {
                PaymentProvider = PaymentProvider.Paypal,
                Amount = 1000
            });

            order.SelectedPayments.Add(new Payment
            {
                PaymentProvider = PaymentProvider.Invoice,
                Amount = 1797
            });

            Console.WriteLine(order.AmountDue);
            Console.WriteLine(order.ShippingStatus);

            var handler = new PaymentHandler(
                new CreditCardHandler(), 
                new InvoiceHandler(), 
                new PaypalHandler()
            );

            //var handler = new PaypalHandler();
            //handler.SetNext(new CreditCardHandler()).SetNext(new InvoiceHandler());

            handler.Handle(order);

            Console.WriteLine(order.AmountDue);
            Console.WriteLine(order.ShippingStatus);
        }
    }
}
