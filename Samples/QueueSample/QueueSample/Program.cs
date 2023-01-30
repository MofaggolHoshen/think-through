
int[] ints =
{
    1, 2, 3, 4,5
};

int[] ints2 = new int[ints.Length+1];



ints.CopyTo(ints2, 0);

Console.WriteLine(ints2[5]);
Console.WriteLine(ints2.Length);
