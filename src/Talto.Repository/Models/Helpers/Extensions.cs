using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talto.Repository.Models.Helpers
{
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
