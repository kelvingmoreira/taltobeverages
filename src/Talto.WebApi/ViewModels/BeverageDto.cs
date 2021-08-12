using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talto.WebApi.ViewModels
{
    public class BeverageDto
    {
        public BeverageDto() { }
        public BeverageDto(int id, string name, double price, IEnumerable<CashbackDto> cashbacks)
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
