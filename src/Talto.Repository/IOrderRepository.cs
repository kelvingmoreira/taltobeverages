using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talto.Repository.Models;

namespace Talto.Repository
{
    /// <summary>
    /// Define métodos de interação básicos com o back-end de <see cref="Order"/>.
    /// </summary>
    public interface IOrderRepository : IRepository<Order>
    {

    }
}
