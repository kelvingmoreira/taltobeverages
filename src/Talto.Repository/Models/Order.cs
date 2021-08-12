using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talto.Repository.Models.Helpers;

namespace Talto.Repository.Models
{
    /// <summary>
    /// Representa uma ordem de venda.
    /// </summary>
    public class Order : DbObject
    {
        /// <summary>
        /// Obtém ou define a data em que a ordem foi lançada.
        /// </summary>
        public DateTime DatePlaced { get; set; } = DateTime.Now;

        private double _totalCashbackRefunded;

        /// <summary>
        /// Obtém ou define o cashback total devoldido na venda.
        /// </summary>
        public double TotalCashbackRefunded
        {
            get => _totalCashbackRefunded;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(TotalCashbackRefunded));
                else
                    _totalCashbackRefunded = value;
            }
        }

        /// <summary>
        /// Obtém ou define os lançamentos da venda.
        /// </summary>
        public ICollection<OrderEntry> Entries { get; set; }


    }
}
