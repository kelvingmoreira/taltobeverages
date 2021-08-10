using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talto.Repository.Models.Helpers;

namespace Talto.Repository.Models
{
    public class Cashback : Traceable
    {
        public int BeverageId { get; set; }

        public Beverage Beverage { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

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
