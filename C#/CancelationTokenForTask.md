## Cancel Runing Task

```C#
using static System.Console;
var source = new Cancellation TokenSource();
var token = source. Token;
Task.Run(async () {
    while (true) {
    WriteLine("cool");
    var wait = TimeSpan. FromSeconds (1);
    await Task.Delay (wait, token);
    }
}, token);

ReadKey();
// stop running the task
source. Cancel();
WriteLine("Cancelled!");
ReadKey();
```
