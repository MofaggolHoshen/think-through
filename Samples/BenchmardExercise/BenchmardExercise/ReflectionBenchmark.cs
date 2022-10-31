using BenchmarkDotNet.Attributes;
using SenariosTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmardExercise
{
    [MemoryDiagnoser]
    public class ReflectionBenchmark
    {
        [Benchmark]
        public void Nonymization()
        {
            ReflectionTests reflectionTests = new ReflectionTests();
            reflectionTests.AnonymizationHelper();
        }
    }
}
