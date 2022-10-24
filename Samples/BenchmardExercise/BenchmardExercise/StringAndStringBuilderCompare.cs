﻿using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmardExercise
{
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
        public void Str1()
        {

            for (int i = 0; i < 1000; i++)
            {
                Person person = new(i, i.ToString());
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
    }
}