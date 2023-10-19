using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    public class BenchmarkRecordNoBase
    {
        [Key]
        public Guid BenchmarkDbId { get; set; }
    }
}
