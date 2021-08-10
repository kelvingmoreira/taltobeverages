using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talto.Repository.Models.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Talto.Repository
{
    /// <summary>
    /// Define métodos de interação básicos com o back-end de uma entidade.
    /// </summary>
    /// <typeparam name="T">Uma classe que represente um entidade <see cref="DbObject"/> no banco de dados.</typeparam>
    public interface IRepository<T> where T : DbObject
    {
        /// <summary>
        /// Retorna o <see cref="DbSet{T}"/> tipado como <see cref="IQueryable{T}"/> para transferência de dados. 
        /// </summary>
        IQueryable<T> AsQueryable();

        /// <summary>
        /// Retorna todas as entidades de <typeparamref name="T"/> no banco de dados. 
        /// </summary>
        Task<IEnumerable<T>> GetAsync();

        /// <summary>
        /// Busca e retorna a entidade <typeparamref name="T"/> com o ID dado.
        /// </summary>
        /// <param name="id">O ID da entidade a buscar.</param>
        /// <returns>
        /// A entidade cujo ID é o fornecido. 
        /// Retorna <see langword="null"/> se nenhuma entidade for encontrada com o ID fornecido.
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
        /// /// <returns>
        /// <see langword="true"/> caso a entidade com ID (1º) exista e (2º) seja removida, caso contrário, <see langword="false"/>. 
        /// </returns>
        Task<bool> DeleteAsync(int id);
    }
}
