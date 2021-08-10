using System;
using System.Collections.Generic;

namespace Talto.Models
{
    public class Beverage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Cashback> Cashbacks { get; set; }
    }
}
