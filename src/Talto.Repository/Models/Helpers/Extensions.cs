using System;

namespace Talto.Repository.Models.Helpers
{
    /// <summary>
    /// Classe auxiliar para extensões.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Atribui metadados de rastreamento no objeto na hora da importação.
        /// </summary>
        /// <param name="traceable">O objeto rastreável.</param>
        public static void SetTraceValues(this Traceable traceable)
        {
            traceable.LastWriteDate = DateTime.Now;

            if (!traceable.CreationDate.HasValue) 
                traceable.CreationDate = traceable.LastWriteDate;
        }
    }
}
