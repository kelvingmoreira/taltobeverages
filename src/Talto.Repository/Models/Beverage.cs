using System;
using System.Collections.Generic;
using Talto.Repository.Models.Helpers;

namespace Talto.Repository.Models
{
    /// <summary>
    /// Representa uma cerveja.
    /// </summary>
    public class Beverage : DbObject
    {
        /// <summary>
        /// Obtém ou define o nome da cerveja.
        /// </summary>
        public string Name { get; set; }

        private double _price;

        /// <summary>
        /// Obtém ou define o preço da cerveja.
        /// </summary>
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

        /// <summary>
        /// Obtém ou define os cashbacks acordados da cerveja.
        /// </summary>
        public ICollection<Cashback> Cashbacks { get; set; }
    }
}
