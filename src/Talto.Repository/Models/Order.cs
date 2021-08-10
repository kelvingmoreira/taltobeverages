using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talto.Repository.Models.Helpers;

namespace Talto.Repository.Models
{
    /// <summary>
    /// Representa uma ordem de venda.
    /// </summary>
    public class Order : DbObject
    {
        /// <summary>
        /// Obtém ou define a data em que a ordem foi lançada.
        /// </summary>
        public DateTime DatePlaced { get; set; } = DateTime.Now;


    }
}
