using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talto.WebApi.ViewModels
{

    public class OrderEntryRequest
    {
        public int BeverageId { get; set; }

        public int Quantity { get; set; }
    }

    public class OrderEntryResponse
    {
        public OrderEntryResponse() { }
        public OrderEntryResponse(int beverageId, string beverageName, double beverageSalePrice, int quantity, double cashbackRefunded)
        {
            BeverageId = beverageId;
            BeverageName = beverageName;
            _beverageSalePrice = beverageSalePrice;
            Quantity = quantity;
            _cashbackRefunded = cashbackRefunded;
        }

        public int BeverageId { get; set; }

        public string BeverageName { get; set; }

        private double _beverageSalePrice;

        public double BeverageSalePrice => Math.Round(_beverageSalePrice, 2);

        public int Quantity { get; set; }

        private double _billingAmount => Quantity * _beverageSalePrice;

        public double BillingAmount => Math.Round(_billingAmount, 2);

        private double _cashbackRefunded;

        public double CashbackRefunded => Math.Round(_cashbackRefunded, 2);

        private double _netCost => _billingAmount - _cashbackRefunded;

        public double NetCost => Math.Round(_netCost, 2);
    }
}
