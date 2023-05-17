using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmardExercise;

[MemoryDiagnoser]
public class StringAndStringBuilderCompare
{
    [Benchmark]
    public string Str()
    {
        string str = "";
        for (int i = 0; i < 1000; i++)
        {
            str = str + i;
        }

        return str;
    }

    [Benchmark]
    public string StrConcat()
    {
        string str = "";
        for (int i = 0; i < 1000; i++)
        {
            str = $"{i}";
        }

        return str;
    }

    [Benchmark]
    public void Str1()
    {

        for (int i = 0; i < 1000; i++)
        {
            StrAndStrBuidler person = new(i, i.ToString());
        }
    }

    [Benchmark]
    public string StrBuilder()
    {
        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < 1000; i++)
        {
            stringBuilder.Append(i);
        }

        return stringBuilder.ToString();
    }

    [Benchmark]
    public List<string> StrList()
    {
        var list = new List<string>();
        for (int i = 0; i < 1000; i++)
        {
            list.Add(i.ToString());
        }

        return list;
    }
}

public class StrAndStrBuidler
{
    public int Id { get; set; }
    public string Name { get; set; }

    public StrAndStrBuidler(int id, string name)
    {
        Id=id;
        Name=name;
    }
}
