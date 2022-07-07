# C# Knowledge

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

## CustomValidationAttribute Sample

```C#
[TestClass]
public class CustomValidationAttributeTest
{
[TestMethod]
    public void CustomAttributeTest()
    {
        var attribute = new CustomValidationAttribute(typeof(CustomValidationAttributeTest), "Validator");
        int model = 10;

        var isValid = attribute.IsValid(model);
        var result = attribute.GetValidationResult(model, new ValidationContext(model));
    }

    public static ValidationResult Validator(object value, ValidationContext context)
    {
        //Validation logic
        if (value is int i && i > 0)
            return ValidationResult.Success!;
        else
            return new ValidationResult("");
    }
}
```

## Web Server(TestServer with Localhost)

```C#
public class HttpBase
    {
        public HttpClient HttpClient { get; private set; }
        public TestServer TestServer { get; set; }

        public HttpBase()
        {
            // Arrange
            TestServer = new TestServer(new WebHostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.Test.json", optional: true, reloadOnChange: true);
                    config.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
                })
               .UseStartup<Startup>());
            HttpClient = TestServer.CreateClient();
            HttpClient.BaseAddress = new Uri(@"https://localhost:44303/api/");
            HttpClient.DefaultRequestHeaders.Add("key", "Value");
            HttpClient.DefaultRequestHeaders.Add("api-version", "1.0");
        }

    }

[TestClass]
public class PersonTest : HttpBase
    {
        [TestMethod]
        public async Task GetPersonDetails()
        {
            var response = await HttpClient.GetAsync("persons/10001");
            var resStr = await response.Content.ReadAsStringAsync();
           // Person person = await response.Content.ReadFromJsonAsync<Person>();
        }
    }
```
