using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talto.Repository
{
    /// <summary>
    /// Define métodos de interação básicos com o back-end de uma entidade.
    /// </summary>
    /// <typeparam name="T">Uma clase que represente um entidade no banco de dados.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Retorna todas as entidades de <typeparamref name="T"/> no banco de dados. 
        /// </summary>
        Task<IEnumerable<T>> GetAsync();

        /// <summary>
        /// Busca e retorna a entidade com o ID dado <typeparamref name="T"/>.
        /// </summary>
        /// <param name="id">O ID da entidade a buscar.</param>
        /// <returns>
        /// A entidade cujo ID é o fornecido. 
        /// Nulo se nenhuma entidade for encontrada com o ID fornecido.
        /// </returns>
        Task<T> GetAsync(int id);

        /// <summary>
        /// Cria uma nova tupla de <typeparamref name="T"/> no banco de dados.
        /// </summary>
        /// <param name="entity">A entidade a criar.</param>
        /// <returns>
        /// A entidade criada. 
        /// </returns>
        Task<T> InsertAsync(T entity);

        /// <summary>
        /// Atualiza os atributos de uma tupla de <typeparamref name="T"/> no banco de dados.
        /// </summary>
        /// <param name="entity">A entidade a criar.</param>
        /// <returns>
        /// A entidade atualizada. 
        /// </returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Remove a tupla da entidade <typeparamref name="T"/> no banco de dados com o ID dado.
        /// </summary>
        /// <param name="id">O ID da entidade a remover.</param>
        Task DeleteAsync(int id);
    }
}
