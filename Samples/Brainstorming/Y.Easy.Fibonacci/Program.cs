

string? input = Console.ReadLine();
int N = int.Parse(input ?? "0");

int a = 0, b = 1, c = 0;

for (int i = 0; i < N; i++)
{
    Console.Write(a + " ");
    c = a + b;
    a = b;
    b = c;
}