using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmardExercise;

[MemoryDiagnoser]
public class TwoStringsCompare
{
    private string _items;

    [GlobalSetup]
    public void Setup()
    {
        _items = "mofaggol Hoshen";


    }

    [Benchmark]
    public void StrWithEqualOperator()
	{
        if(_items.ToUpper() == "Mofaggol Hoshe".ToUpper())
        {
            int i = 0;
        }    
	}

    [Benchmark]
	public void StrWithEqualFunction()
	{
        if (_items.ToUpper().Equals("Mofaggol Hoshe".ToUpper()))
        {
            int i = 0;
        }
    }

    public void DefaultOrdinalComparisons()
    {
        string root = @"C:\users";
        string root2 = @"C:\Users";

        bool result = root.Equals(root2);
        Console.WriteLine($"Ordinal comparison: <{root}> and <{root2}> are {(result ? "equal." : "not equal.")}");

        result = root.Equals(root2, StringComparison.Ordinal);
        Console.WriteLine($"Ordinal comparison: <{root}> and <{root2}> are {(result ? "equal." : "not equal.")}");

        Console.WriteLine($"Using == says that <{root}> and <{root2}> are {(root == root2 ? "equal" : "not equal")}");
    }

    /// <summary>
    /// String.Equal function 
    /// first compare ference if same return true
    ///  1. string str1 = @"Mofaggol Hoshen";
    ///     string str2 = str1;
    ///     this sample return true
    ///     
    ///  2. string str1 = @"Mofaggol Hoshen";
    ///     string str2 = str1+"m";
    ///     this sample return flase
    /// </summary>
    public void DefaultEqual()
    {
        TwoStringsCompareClass str1 = new TwoStringsCompareClass(1, "Mofaggol1");
        TwoStringsCompareClass str2 = new TwoStringsCompareClass(1, "Mofaggol");


        bool result = str1.Name.Equals(str2.Name);
        Console.WriteLine($"Ordinal comparison: <{str1.Name}> and <{str2.Name}> are {(result ? "equal." : "not equal.")}");

        result = str1.Name.Equals(str2.Name, StringComparison.Ordinal);
        Console.WriteLine($"Ordinal comparison: <{str1.Name}> and <{str2.Name}> are {(result ? "equal." : "not equal.")}");

        Console.WriteLine($"Using == says that <{str1.Name}> and <{str2.Name}> are {(str1.Name == str2.Name ? "equal" : "not equal")}");
    }
}

public class TwoStringsCompareClass
{
    public int Id { get; set; }
    public string Name { get; set; }

    public TwoStringsCompareClass(int id, string name)
    {
        Id=id;
        Name=name;
    }
}
