using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talto.WebApi.ViewModels
{
    public class OrderEntryResponse
    {
        public OrderEntryResponse() { }
        public OrderEntryResponse(int beverageId, string beverageName, double beveragePricePaid, int quantity, double cashbackRefunded)
        {
            BeverageId = beverageId;
            BeverageName = beverageName;
            BeveragePricePaid = beveragePricePaid;
            Quantity = quantity;
            CashbackRefunded = cashbackRefunded;
        }

        public int BeverageId { get; set; }

        public string BeverageName { get; set; }

        public double BeveragePricePaid { get; set; }

        public int Quantity { get; set; }

        public double CashbackRefunded { get; set; }
    }

    public class OrderEntryRequest
    {
        public int BeerId { get; set; }

        public int Quantity { get; set; }
    }
}
