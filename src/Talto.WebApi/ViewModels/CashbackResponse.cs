using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talto.WebApi.ViewModels
{
    public class CashbackResponse
    {
        public CashbackResponse() { }

        public CashbackResponse(DayOfWeek dayOfWeek, double value)
        {
            DayOfWeek = dayOfWeek.ToString().ToLower();
            Value = value;
        }

        public string DayOfWeek { get; set; }

        public double Value { get; set; }
    }
}
