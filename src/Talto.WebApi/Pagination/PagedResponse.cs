using System;
using System.Collections;

namespace Talto.WebApi.Pagination
{

    /// <summary>
    /// Encapsula uma resposta com dados de paginação. 
    /// Adaptado de <see href="https://codewithmukesh.com/blog/pagination-in-aspnet-core-webapi/"/>
    /// </summary>
    /// <typeparam name="TResponse">O dado a ser paginado.</typeparam>
    public class PagedResponse<TResponse> where TResponse : IEnumerable
    {
        /// <summary>
        /// Cria uma nova instância de <see cref="PagedResponse{TResponse}"/>.
        /// </summary>
        public PagedResponse() { }

        /// <summary>
        /// Cria uma nova instância de <see cref="PagedResponse{TResponse}"/> encapsulando dados.
        /// </summary>
        /// <param name="data">O dado a encapsular.</param>
        public PagedResponse(TResponse data) => Data = data;

        /// <summary>
        /// Cria uma nova instância de <see cref="PagedResponse{TResponse}"/> encapsulando dados com paginação.
        /// </summary>
        /// <param name="data">O dado a encapsular.</param>
        /// <param name="paginationFilter">Os dados de filtragem.</param>
        /// <param name="totalRecords">O total de tuplas disponíveis no banco de dados.</param>
        public PagedResponse(TResponse data, PaginationFilter paginationFilter, int totalRecords)
        {
            Data = data;
            PageNumber = paginationFilter.PageNumber;
            PageSize = paginationFilter.PageSize;
            TotalRecords = totalRecords;
        }

        /// <summary>
        /// Obtém ou define o número da página.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Obtém ou define o tamanho da página.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Obtém a contagem total de páginas.
        /// </summary>
        public int TotalPages => (int)Math.Ceiling(TotalRecords / (double)PageSize);

        /// <summary>
        /// Obtém ou define a contagem de tuplas no banco de dados.
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// Obtém ou define o dado-resposta.
        /// </summary>
        public TResponse Data { get; set; }
    }
}
