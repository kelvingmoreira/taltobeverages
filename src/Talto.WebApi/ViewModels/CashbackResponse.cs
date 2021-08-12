using System;

namespace Talto.WebApi.ViewModels
{
    /// <summary>
    /// Representa o DTO de uma resposta de um cashback.
    /// </summary>
    public class CashbackResponse
    {
        /// <summary>
        /// Cria uma nova instância do DTO.
        /// </summary>
        public CashbackResponse() { }

        /// <summary>
        /// Cria uma nova instância encapsulada do DTO.
        /// </summary>
        public CashbackResponse(DayOfWeek dayOfWeek, double value)
        {
            DayOfWeek = dayOfWeek.ToString().ToLower();
            Value = value;
        }

        /// <summary>
        /// Obtém ou define o dia da semana em que o cashback se aplica.
        /// </summary>
        public string DayOfWeek { get; set; }

        /// <summary>
        /// Obtém ou define o valor percentual do cashback.
        /// </summary>
        public double Value { get; set; }
    }
}
