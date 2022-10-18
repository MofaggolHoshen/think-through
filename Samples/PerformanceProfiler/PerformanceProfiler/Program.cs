namespace ba;
public class Program
{
    public static async Task Main(string[] args)
    {
        Task[] timer = new Task[10];

        for (int i = 0; i < 10; i++)
        {
            int j = i;
            timer[i] = new Task(() => BadTimer(j+i));
        }

        foreach (var item in timer)
        {
            item.Start();
        }

        await Task.WhenAll(timer);

        Console.WriteLine("Timer has finished");
    }

    private static void BadTimer(int second)
    {
        Console.WriteLine("Timer for {0} seconds started", second);
        TimeSpan AmountOfTime = new TimeSpan(0, 0, second);
        DateTime startTime = DateTime.Now;
        DateTime nowTime = DateTime.Now;
        while(nowTime - startTime < AmountOfTime)
        {
            nowTime = DateTime.Now;
        }

        Console.WriteLine("Timer for {0} seconds ended", second);
    }

    private static void BetterTimerAsnyc(int second)
    {

    }
}