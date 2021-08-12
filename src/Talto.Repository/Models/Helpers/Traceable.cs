using System;

namespace Talto.Repository.Models.Helpers
{
    /// <summary>
    /// Classe base para rastreamento de criação e alteração no banco de dados.
    /// </summary>
    public abstract class Traceable
    {
        /// <summary>
        /// Obtém a data de criação da entidade.
        /// </summary>
        public DateTime? CreationDate { get; internal set; }

        /// <summary>
        /// Obtém a última alteração na entidade.
        /// </summary>
        public DateTime? LastWriteDate { get; internal set; }
    }
}
