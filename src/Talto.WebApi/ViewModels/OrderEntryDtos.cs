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

        private double _totalAmount => Quantity * _beverageSalePrice;

        public double TotalAmount => Math.Round(_totalAmount, 2);

        private double _cashbackRefunded;

        public double CashbackRefunded => Math.Round(_cashbackRefunded, 2);

        private double _netCost => _totalAmount - _cashbackRefunded;

        public double NetCost => Math.Round(_netCost, 2);
    }
}
