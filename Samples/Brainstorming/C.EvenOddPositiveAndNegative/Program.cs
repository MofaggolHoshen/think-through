
// User input
string? input = Console.ReadLine();
// Convert to int
int N = int.Parse(input ?? "0");

// User input
    string? input2 = Console.ReadLine();
// Spit the string into an array
string[] numbers = input2.Split(' ');

int[] ints = Array.ConvertAll(numbers, int.Parse);

int even = 0, odd = 0, positive = 0, negative = 0;

// Loop N times
for (int i = 0; i < N; i++)
{
    //Check if number is even
    if (ints[i] % 2 == 0)
    {
        even++;
    }
    else
    {
        odd++;
    }

    //Check if number is positive
    if (ints[i] > 0)
    {
        positive++;
    }
    else if (ints[i] < 0)
    {
        negative++;
    }
}

Console.WriteLine($"Even: {even}");
Console.WriteLine($"Odd: {odd}");
Console.WriteLine($"Positive: {positive}");
Console.WriteLine($"Negative: {negative}");