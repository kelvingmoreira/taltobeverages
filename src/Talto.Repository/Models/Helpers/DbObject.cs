namespace Talto.Repository.Models.Helpers
{
    /// <summary>
    /// Classe base para entidades principais do banco de dados.
    /// </summary>
    public abstract class DbObject : Traceable
    {
        /// <summary>
        /// Obtém ou define o ID no banco de dados.
        /// </summary>
        public int Id { get; set; }
    }
}
