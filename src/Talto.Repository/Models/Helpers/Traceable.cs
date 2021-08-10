using System;

namespace Talto.Repository.Models.Helpers
{
    /// <summary>
    /// Classe base para rastreamento de criação e alteração no banco de dados.
    /// </summary>
    public abstract class Traceable
    {
        /// <summary>
        /// A data de criação da entidade.
        /// </summary>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// A data da última alteração na entidade.
        /// </summary>
        public DateTime? LastWriteDate { get; set; }
    }
}
