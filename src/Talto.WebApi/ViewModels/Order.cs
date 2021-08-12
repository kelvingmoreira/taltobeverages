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

        public OrderResponse(int id, DateTime datePlaced, IEnumerable<OrderEntryResponse> orderEntries, double totalCashback)
        {
            Id = id;
            DatePlaced = datePlaced;
            Entries = orderEntries;
            TotalCashback = totalCashback;
        }

        public int Id { get; set; }

        public DateTime DatePlaced { get; set; }

        public double TotalCashback { get; set; }

        public IEnumerable<OrderEntryResponse> Entries { get; set; }
    }

}
