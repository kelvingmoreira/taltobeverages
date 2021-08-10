using System;
using System.Collections.Generic;
using Talto.Repository.Models.Helpers;

namespace Talto.Repository.Models
{
    public class Beverage : DbObject
    {
        public string Name { get; set; }
        public ICollection<Cashback> Cashbacks { get; set; }
    }
}
