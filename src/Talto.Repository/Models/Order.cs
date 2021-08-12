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

        private double _totalCashback;

        /// <summary>
        /// Obtém ou define o cashback total da venda.
        /// </summary>
        public double TotalCashback
        {
            get => _totalCashback;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(TotalCashback));
                else
                    _totalCashback = value;
            }
        }

        /// <summary>
        /// Obtém ou define os lançamentos da venda.
        /// </summary>
        public ICollection<OrderEntry> Entries { get; set; }


    }
}
