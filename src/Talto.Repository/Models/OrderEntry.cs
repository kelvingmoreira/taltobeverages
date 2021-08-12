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
        /// Obtém ou define o ID da ordem.
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

        /// <summary>
        /// Obtém ou define o valor pago por unidade de cerveja no momento da venda.
        /// </summary>
        public double SalePrice { get; set; }

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

        private double _cashbackRefunded;

        /// <summary>
        /// Obtém ou define o valor de cashback devolvido no momento da venda.
        /// </summary>
        public double CashbackRefunded
        {
            get => _cashbackRefunded;
            internal set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(CashbackRefunded));
                else
                    _cashbackRefunded = value;
            }
        }


    }
}
