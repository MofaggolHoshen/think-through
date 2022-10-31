using BenchmardExercise;
using BenchmarkDotNet.Running;
using SenariosTest;

//BenchmarkRunner.Run<ArgumentException>();

//BenchmarkRunner.Run<ListForEachVsForLoop>();

//BenchmarkRunner.Run<TwoStringsCompare>();

//TwoStringsCompare twoStringsCompare= new TwoStringsCompare();
//twoStringsCompare.DefaultEqual();

//BenchmarkRunner.Run<CloneAndCopyObject>();
BenchmarkRunner.Run<ReflectionBenchmark>();

var cloneOrCopyObjectTest = new CloneOrCopyObjectTest();

cloneOrCopyObjectTest.CloneHelper();