using System.ComponentModel.DataAnnotations;

namespace Benchmark.Models
{
    public class BenchmarkRecordNoBase
    {
        [Key]
        public Guid BenchmarkDbId { get; set; }
    }
}
