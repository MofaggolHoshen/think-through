using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BenchmardExercise;

[MemoryDiagnoser]
public  class ListForEachVsForLoop
{
    private List<string> _items;

    [GlobalSetup]
    public void Setup()
    {
        _items = new List<string>(){
            "Test",
            "Test1",
            "Test2",
            "Test2",
            "Test2",
            "Test2",
            "Test2",
            "Test2",
            "Test2",
            "Test2",
            "Test2",
            "Test2",
            "Test2"
        };


    }

    [Benchmark]
    public void List_ForEach()
    {
        _items.ForEach(i => {
        });
    }

    [Benchmark]
    public void ForEach()
    {
        foreach (var str in _items)
        {
        }
    }

    [Benchmark]
    public void For()
    {
        for (int i = 0; i < _items.Count; i++)
        {
        }
    }
}

/****************************Result**********************************************
 * 
 * 
 * |       Method |      Mean |     Error |   StdDev |    Median | Allocated |
 * |------------- |----------:|----------:|---------:|----------:|----------:|
 * | List_ForEach | 42.746 ns | 1.8567 ns | 5.176 ns | 41.181 ns |         - |
 * |      ForEach | 25.304 ns | 0.5654 ns | 1.557 ns | 24.945 ns |         - |
 * |          For |  8.776 ns | 1.0132 ns | 2.987 ns |  7.655 ns |         - |
 * 
 *   Mean      : Arithmetic mean of all measurements
 *   Error     : Half of 99.9% confidence interval
 *   StdDev    : Standard deviation of all measurements
 *   Median    : Value separating the higher half of all measurements (50th percentile)
 *   Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
 *   1 ns      : 1 Nanosecond (0.000000001 sec)
 * 
 * 
 *********************************************************************************/
