using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benchmark.Models;
using Microsoft.EntityFrameworkCore;

namespace Benchmark
{
    public class BenchmarkRecord : EntityBase
    {
        [Key]
        public Guid BenchmarkDbId { get; set; }
    }
}
