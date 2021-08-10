using System;
using System.Collections.Generic;
using Talto.Repository.Models.Helpers;

namespace Talto.Repository.Models
{
    public class Beverage : DbObject
    {
        public string Name { get; set; }

        private double _price;

        public double Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Price));
                else
                    _price = value;
            }
        }

        public ICollection<Cashback> Cashbacks { get; set; }
    }
}
