using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using SenariosTest;

namespace BenchmardExercise;

[MemoryDiagnoser]
public class CloneAndCopyObject
{
    CloneOrCopyObjectTest cloneOrCopyObjectTest = default!;

    [GlobalSetup]
    public void Setup()
    {
        cloneOrCopyObjectTest = new CloneOrCopyObjectTest();
    }

    [Benchmark]
    public void IClonable()
	{
        cloneOrCopyObjectTest.ICloneableHelper();
    }

    [Benchmark]
    public void Clone()
    {
        cloneOrCopyObjectTest.CloneHelper();
    }
}
