using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talto.Repository.Models.Helpers;

namespace Talto.Repository.Models
{
    /// <summary>
    /// Representa um lançamento de uma ordem de venda.
    /// </summary>
    public class OrderEntry : DbObject
    {
        /// <summary>
        /// Obtém ou define o ID da cerveja.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Obtém ou define a ordem de venda à qual o lançamento pertence.
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Obtém ou define o ID da cerveja.
        /// </summary>
        public int BeverageId { get; set; }

        /// <summary>
        /// Obtém ou define a cerveja a vender.
        /// </summary>
        public Beverage Beverage { get; set; }

        private int _quantity = 1;

        /// <summary>
        /// Obtém ou define a quantidade de cerveja vendida, em unidades.
        /// </summary>
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Quantity));
                else
                    _quantity = value;
            }
        }

        private double _cashbackAtSale;

        /// <summary>
        /// Obtém ou define o valor de cashback do lançamento no momento da venda.
        /// </summary>
        public double CashbackAtSale
        {
            get => _cashbackAtSale;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(CashbackAtSale));
                else
                    _cashbackAtSale = value;
            }
        }
    }
}
