using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talto.Models
{
    public class Cashback
    {
        public DayOfWeek DayOfWeek { get; set; }

        public int BeverageId { get; set; }

        public Beverage Beverage { get; set; }

        private double _value;

        public double Value
        {
            get => _value;
            set
            {
                if (value < 0 || value > 1) 
                    throw new ArgumentOutOfRangeException(nameof(Value));
                else 
                    _value = value;
            }
        }
    }
}
