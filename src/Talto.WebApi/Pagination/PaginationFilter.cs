namespace Talto.WebApi.Pagination
{
    //adaptado de https://codewithmukesh.com/blog/pagination-in-aspnet-core-webapi/
    /// <summary>
    /// Classe auxiliar para filtro de páginas.
    /// Adaptado de <see href="https://codewithmukesh.com/blog/pagination-in-aspnet-core-webapi/"/>
    /// </summary>
    public class PaginationFilter
    {
        /// <summary>
        /// Obtém ou define o número da página.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Obtém ou define o tamanho da página.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Cria uma nova instância de <see cref="PaginationFilter"/> com tamanho de pagina 10 e exibindo a primeira página.
        /// </summary>
        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="PaginationFilter"/> com filtragem personalizada.
        /// </summary>
        /// <param name="pageNumber">O número da página.</param>
        /// <param name="pageSize">O tamanho da página.</param>
        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 || pageSize < 1 ? 10 : pageSize;
        }
    }
}
