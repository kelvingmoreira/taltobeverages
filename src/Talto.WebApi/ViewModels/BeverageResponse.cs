using System.Collections.Generic;
using System.Linq;

namespace Talto.WebApi.ViewModels
{
    /// <summary>
    /// Representa o DTO de uma resposta de uma cerveja.
    /// </summary>
    public class BeverageResponse
    {
        /// <summary>
        /// Cria uma nova instância do DTO.
        /// </summary>
        public BeverageResponse() { }

        /// <summary>
        /// Cria uma nova instância encapsulada do DTO.
        /// </summary>
        public BeverageResponse(int id, string name, double price, IEnumerable<CashbackResponse> cashbacks)
        {
            Id = id;
            Name = name;
            Price = price;
            Cashbacks = cashbacks.ToDictionary(c => c.DayOfWeek, c => c.Value);

        }

        /// <summary>
        /// Obtém ou define o ID da cerveja.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtém ou define o nome da cerveja.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtém ou define o preço de venda da cerveja.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Obtém ou define os cashbacks por dia da semana.
        /// </summary>
        public Dictionary<string, double> Cashbacks { get; set; }

    }
}
