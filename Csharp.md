# C# Features

## Inherits List/IList  

```C#
public class MyListClass : System.Collections.Generic.List<string>
{
    public IEnumerable<string> this[string prifix, params int[] keys] => keys.Select(key=> this[key] + " " + prifix);
}

[TestMethod]
public void MyMethod()
{
    var myList = new MyListClass { "Mofaggol", "Hoshen" };

    var bla = myList["Developer", 0, 1];

    foreach (var item in bla)
    {
        Debug.WriteLine(item);
    }
}
```
