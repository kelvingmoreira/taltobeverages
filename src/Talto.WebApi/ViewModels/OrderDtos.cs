using System;
using System.Collections.Generic;
using System.Linq;

namespace Talto.WebApi.ViewModels
{
    /// <summary>
    /// Representa o DTO de uma solicitação de uma ordem de venda.
    /// </summary>
    public class OrderRequest
    {
        /// <summary>
        /// Obtém ou define a data em que a ordem foi lançada.
        /// </summary>
        public DateTime DatePlaced { get; set; }

        /// <summary>
        /// Obtém ou define os lançamentos da venda.
        /// </summary>
        public List<OrderEntryRequest> Entries { get; set; }
    }

    /// <summary>
    /// Representa o DTO de uma resposta de uma ordem de venda.
    /// </summary>
    public class OrderResponse
    {
        /// <summary>
        /// Cria uma nova instância do DTO.
        /// </summary>
        public OrderResponse() { }

        /// <summary>
        /// Cria uma nova instância encapsulada do DTO.
        /// </summary>
        public OrderResponse(int id, DateTime datePlaced, IEnumerable<OrderEntryResponse> orderEntries, double totalCashbackRefunded)
        {
            Id = id;
            DatePlaced = datePlaced;
            Entries = orderEntries;
            _totalCashbackRefunded = totalCashbackRefunded;
        }
        /// <summary>
        /// Obtém ou define o ID da ordem.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtém ou define a data em que a ordem foi lançada.
        /// </summary>
        public DateTime DatePlaced { get; set; }

        /// <summary>
        /// Obtém ou define o dia da semana em que a ordem foi lançada.
        /// </summary>
        public string DayOfWeek => DatePlaced.DayOfWeek.ToString().ToLower();

        private double _subTotal => Entries.Sum(o => o.BillingAmount);

        /// <summary>
        /// Obtém ou define o subtotal da venda.
        /// </summary>
        public double Subtotal => Math.Round(_subTotal, 2);

        private double _totalCashbackRefunded;

        /// <summary>
        /// Obtém ou define o cashback total devolvido.
        /// </summary>
        public double TotalCashbackRefunded => Math.Round(_totalCashbackRefunded, 2);

        /// <summary>
        /// Obtém ou define o total da venda.
        /// </summary>
        public double GrandTotal => Math.Round(_subTotal - _totalCashbackRefunded, 2);

        /// <summary>
        /// Obtém ou define os lançamentos da venda.
        /// </summary>
        public IEnumerable<OrderEntryResponse> Entries { get; set; }
    }

}
