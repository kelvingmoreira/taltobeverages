using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talto.Repository.Models.Helpers
{
    public static class Extensions
    {
        public static void SetTraceValues(this DbObject dbObject)
        {
            dbObject.LastWriteDate = DateTime.Now;

            if (!dbObject.CreationDate.HasValue) 
                dbObject.CreationDate = dbObject.LastWriteDate;
        }
    }
}
