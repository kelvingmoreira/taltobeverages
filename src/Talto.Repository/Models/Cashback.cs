using System;
using Talto.Repository.Models.Helpers;

namespace Talto.Repository.Models
{
    /// <summary>
    /// Representa o  percentual acordado para calcular o valor recebido de volta na conta no momento da venda.
    /// </summary>
    public class Cashback : Traceable
    {
        /// <summary>
        /// Obtém ou define o ID da cerveja.
        /// </summary>
        public int BeverageId { get; set; }

        /// <summary>
        /// Obtém ou define a cerveja à qual o cashback descreve.
        /// </summary>
        public Beverage Beverage { get; set; }

        /// <summary>
        /// Obtém ou define o dia da semana em que o cashback se aplica.
        /// </summary>
        public DayOfWeek DayOfWeek { get; set; }

        private double _value;

        /// <summary>
        /// Obtém ou define o valor percentual do cashback.
        /// </summary>
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
