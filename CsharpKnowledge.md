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
