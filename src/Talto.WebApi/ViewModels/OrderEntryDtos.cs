using System;

namespace Talto.WebApi.ViewModels
{
    /// <summary>
    /// Representa o DTO de uma solicitação de um lançamento de ordem de venda.
    /// </summary>
    public class OrderEntryRequest
    {
        /// <summary>
        /// Obtém ou define o ID da cerveja a vender.
        /// </summary>
        public int BeverageId { get; set; }

        /// <summary>
        /// Obtém ou define a quantidade de cerveja vendida, em unidades.
        /// </summary>
        public int Quantity { get; set; }
    }

    /// <summary>
    /// Representa o DTO de uma resposta de um lançamento de ordem de venda.
    /// </summary>
    public class OrderEntryResponse
    {
        /// <summary>
        /// Cria uma nova instância do DTO.
        /// </summary>
        public OrderEntryResponse() { }

        /// <summary>
        /// Cria uma nova instância encapsulada do DTO.
        /// </summary>
        public OrderEntryResponse(int beverageId, string beverageName, double beverageSalePrice, int quantity, double cashbackRefunded)
        {
            BeverageId = beverageId;
            BeverageName = beverageName;
            _beverageSalePrice = beverageSalePrice;
            Quantity = quantity;
            _cashbackRefunded = cashbackRefunded;
        }

        /// <summary>
        /// Obtém ou define o ID da cerveja a vender.
        /// </summary>
        public int BeverageId { get; set; }

        /// <summary>
        /// Obtém ou define o nome da cerveja a vender.
        /// </summary>
        public string BeverageName { get; set; }

        private double _beverageSalePrice;

        /// <summary>
        /// Obtém ou define o valor pago por unidade de cerveja no momento da venda.
        /// </summary>
        public double BeverageSalePrice => Math.Round(_beverageSalePrice, 2);

        /// <summary>
        /// Obtém ou define a quantidade de cerveja vendida, em unidades.
        /// </summary>
        public int Quantity { get; set; }

        private double _billingAmount => Quantity * _beverageSalePrice;

        /// <summary>
        /// Obtém ou define o valor da fatura.
        /// </summary>
        public double BillingAmount => Math.Round(_billingAmount, 2);

        private double _cashbackRefunded;

        /// <summary>
        /// Obtém ou define o valor de cashback da fatura.
        /// </summary>
        public double CashbackRefunded => Math.Round(_cashbackRefunded, 2);

        private double _netCost => _billingAmount - _cashbackRefunded;

        /// <summary>
        /// Obtém ou define o custo líquido de cashback.
        /// </summary>
        public double NetCost => Math.Round(_netCost, 2);
    }
}
