using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_of_Responsibility_First_Look.Business.Models
{
    public class Order
    {
        public Order()
        {
            LineItems = new Dictionary<Item, int>();
            SelectedPayments = new List<Payment>();
            FinalizedPayments = new List<Payment>();
            ShippingStatus = ShippingStatus.WaitingForPayment;
        }

        public Dictionary<Item, int> LineItems { get; set; }

        public List<Payment> SelectedPayments { get; set; }

        public List<Payment> FinalizedPayments { get; set; }

        public ShippingStatus ShippingStatus { get; set; }

        public decimal AmountDue => SelectedPayments.Sum(p => p.Amount) - FinalizedPayments.Sum(p => p.Amount);
    }
}
