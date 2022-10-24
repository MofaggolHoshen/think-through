using System;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        var person = new Person
        {
            Id = 10,
            Name = "Mofaggol Hoshen",
            Email = "mofaggol.hoshen@gmail.com"
        };

        person.OnEmailChanged += async (email) =>
        {

            Console.WriteLine("First subscription.");

            var i = await GetTaskAsync();

            Console.WriteLine($"First subscription: {1+10}");
        };


        person.OnEmailChanged += async (email) =>

        {
            Console.WriteLine("Second subscription.");

            var i = await GetTaskAsync();

            Console.WriteLine($"Second subscription: {1+20}");
        };

        await person.Update(new Person
        {
            Id=12,
            Name="Hoshen",
            Email="mofaggol.hoshen@outlook.com"
        });

        Console.WriteLine("Finished");

    }

    public static async Task<int> GetTaskAsync()
    {
        Console.WriteLine($"GetTaskAsync function.");

        return await HttpRequest();
    }

    public static async Task<int> HttpRequest()
    {
        await Task.Delay(500);

        Console.WriteLine($"HttpRequest function.");

        return 10;
    }
}

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public Func<string, Task> OnEmailChanged;

    public async Task Update(Person person)
    {
        this.Id = person.Id;

        if (person.Name != this.Name)
            this.Name = person.Name;

        if (person.Email != this.Email)
        {
            await OnEmailChanged.Invoke(person.Email);
            this.Email = person.Email;

        }
    }
}
