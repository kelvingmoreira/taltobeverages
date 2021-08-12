using System.Collections.Generic;
using System.Linq;

namespace Talto.WebApi.ViewModels
{
    public class BeverageResponse
    {
        public BeverageResponse() { }
        public BeverageResponse(int id, string name, double price, IEnumerable<CashbackResponse> cashbacks)
        {
            Id = id;
            Name = name;
            Price = price;
            Cashbacks = cashbacks.ToDictionary(c => c.DayOfWeek, c => c.Value);

        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public Dictionary<string, double> Cashbacks { get; set; }

    }
}
