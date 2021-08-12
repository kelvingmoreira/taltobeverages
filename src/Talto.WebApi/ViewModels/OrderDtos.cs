using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talto.WebApi.ViewModels
{
    public class OrderRequest
    {
        public int Id { get; set; }

        public DateTime DatePlaced { get; set; }

        public List<OrderEntryRequest> Entries { get; set; }
    }

    public class OrderResponse
    {
        public OrderResponse() { }

        public OrderResponse(int id, DateTime datePlaced, IEnumerable<OrderEntryResponse> orderEntries, double totalCashbackRefunded)
        {
            Id = id;
            DatePlaced = datePlaced;
            Entries = orderEntries;
            _totalCashbackRefunded = totalCashbackRefunded;
        }

        public int Id { get; set; }

        public DateTime DatePlaced { get; set; }

        public string DayOfWeek => DatePlaced.DayOfWeek.ToString().ToLower();

        private double _totalCashbackRefunded;

        public double TotalCashbackRefunded => Math.Round(_totalCashbackRefunded, 2);

        private double _subTotal => Entries.Sum(o => o.TotalAmount);

        public double Subtotal => Math.Round(_subTotal, 2);

        public double GrandTotal => Math.Round(_subTotal - _totalCashbackRefunded, 2);

        public IEnumerable<OrderEntryResponse> Entries { get; set; }
    }

}
