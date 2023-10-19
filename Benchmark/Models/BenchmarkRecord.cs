using System.ComponentModel.DataAnnotations;

namespace Benchmark.Models
{
    public class BenchmarkRecord : EntityBase
    {
        [Key]
        public Guid BenchmarkDbId { get; set; }
    }
}
