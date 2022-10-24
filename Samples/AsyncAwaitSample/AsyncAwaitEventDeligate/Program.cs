namespace AsyncAwaitEventDeligate;

/*
 *  https://www.youtube.com/watch?v=el-kKK-7SBU
 *  https://www.appsloveworld.com/csharp/100/24/how-to-await-on-async-delegate
 *  https://stackoverflow.com/questions/29155/what-are-the-differences-between-delegates-and-events
 *  https://learn.microsoft.com/en-us/shows/three-essential-tips-for-async/tip-1-async-void-top-level-event-handlers-only
 * 
 */

internal class Program
{
    static async Task Main(string[] args)
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