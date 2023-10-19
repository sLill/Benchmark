using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    public abstract class EntityBase
    {
        #region Properties..
        public DateTimeOffset CreatedOnUtc { get; set; }
        public DateTimeOffset ModifiedOnUtc { get; set; }
        #endregion Properties..

    }
}
