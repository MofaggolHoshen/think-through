## Value type validation

With required attribute, Property needs to be nullable for example

```C#
    [required]
    public int? Id {set; get;}
```

On the other hand, if property is not nullable value type always be 0 in API, json serializer do it outof the box.
