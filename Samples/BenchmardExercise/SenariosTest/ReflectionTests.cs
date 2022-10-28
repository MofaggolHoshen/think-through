using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text.Json;

namespace SenariosTest;

[TestClass]
public class ReflectionTests
{
    [TestMethod]
    public void JsonObj()
    {
        //    // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/use-dom-utf8jsonreader-utf8jsonwriter?pivots=dotnet-6-0
        //    JsonNode jsonNode = JsonNode.Parse(File.ReadAllText("Helpers/NodePersing.json"));
    }
    [TestMethod]
    public void TestMethod1()
    {
        var setting = new List<ReflectionSetting>
        {
            new ReflectionSetting
            {
                DomainName = nameof(ReflecClassA),
                Properties = new List<string>
                {
                //nameof(ReflecClassA.Id),
                nameof(ReflecClassA.Names),
                nameof(ReflecClassA.ReflecClassBs)
                }
                //,
                //PropertyClasses = new List<ReflectionSetting>
                //{
                //    new ReflectionSetting
                //    {
                //        DomainName = nameof(ReflecClassB),
                //        Properties = new List<string>
                //        {
                //            nameof(ReflecClassB.Name)
                //        }
                //    }
                //}
            },
            new ReflectionSetting
                    {
                        DomainName = nameof(ReflecClassB),
                        Properties = new List<string>
                        {
                            nameof(ReflecClassB.Name),
                            nameof(ReflecClassB.Self)
                        }
                    }
        };

        var obj = new ReflecClassA
        {
            //    Id = 10,
            ReflecClassBs = new() {
                new ReflecClassB{
                Id = 20,
                Name = "Hoshen",
                Self = new()
                {
                    Id = 20,
                    Name = "Hoshen",
                    Self = new()
                    {
                        Id = 20,
                        Name = "Hoshen",
                    }
                }
                }
            }
        };

        var ano = Anonymized(obj, setting);

    }


    public T Anonymized<T>([DisallowNull] T fromAnonymizeObject, [DisallowNull] List<ReflectionSetting> anonymizationSettings) where T : class
    {
        if (fromAnonymizeObject == null)
            throw new ArgumentNullException(nameof(fromAnonymizeObject));

        var typeOfT = fromAnonymizeObject.GetType();

        PropertyInfo[] propertiesOfT = typeOfT.GetProperties();

        for (int i = 0; i < propertiesOfT.Length; i++)
        {
            var value = propertiesOfT[i].GetValue(fromAnonymizeObject);

            if (value is not null && anonymizationSettings.Any(setting => setting.DomainName.ToUpper() == typeOfT.Name.ToUpper() &&
                                                                          setting.Properties.Any(p => p.ToUpper() ==  propertiesOfT[i].Name.ToUpper())))
            {
                var propertyType = propertiesOfT[i].PropertyType;

                if (propertyType.IsValueType)
                {
                    propertiesOfT[i].SetValue(fromAnonymizeObject, 0);
                }
                else if (propertyType.IsClass && propertyType.IsGenericType == false && propertyType.IsArray == false)
                {
                    if (propertyType.Name == nameof(String))
                    {
                        propertiesOfT[i].SetValue(fromAnonymizeObject, "****");
                    }
                    else
                    {
                        List<ReflectionSetting> propertyClassSettings = new List<ReflectionSetting>();

                        // Looking for Property Class settings in current Domain
                        propertyClassSettings = anonymizationSettings.Where(rfSt => rfSt.DomainName.ToUpper() == typeOfT.Name.ToUpper() &&
                                                                         rfSt.PropertyClasses.Any(k => k.DomainName.ToUpper() == propertiesOfT[i].Name.ToUpper()))
                                                           .SelectMany(i => i.PropertyClasses)
                                                           .ToList();

                        // if Property Class settings found in current Domain
                        if (propertyClassSettings.Count == 0)
                        {
                            // Looking for Property Class settings in root Domain
                            propertyClassSettings = anonymizationSettings.Where(i => i.DomainName.ToUpper() == propertyType.Name.ToUpper()).ToList();
                        }

                        if (propertyClassSettings.Count > 0)
                        {
                            Anonymized(value, propertyClassSettings);
                        }
                    }
                }
                else if (propertyType.IsGenericType)
                {

                    var genericTypeName = propertyType.GenericTypeArguments.First();

                    //If Generic type is Value Type or String for example, int, double etc
                    if (genericTypeName.IsValueType || (genericTypeName.IsClass && genericTypeName.Name == nameof(String)))
                    {
                        propertiesOfT[i].SetValue(fromAnonymizeObject, null);
                    }
                    else
                    {

                        List<ReflectionSetting> propertyClassSettings = new List<ReflectionSetting>();

                        // Looking for Property Class settings in current Domain
                        propertyClassSettings = anonymizationSettings.Where(rfSt => rfSt.DomainName.ToUpper() == typeOfT.Name.ToUpper() &&
                                                                         rfSt.PropertyClasses.Any(k => k.DomainName.ToUpper() == genericTypeName.Name.ToUpper()))
                                                           .SelectMany(i => i.PropertyClasses)
                                                           .ToList();

                        // if Property Class settings found in current Domain
                        if (propertyClassSettings.Count == 0)
                        {
                            // Looking for Property Class settings in root Domain
                            propertyClassSettings = anonymizationSettings.Where(i => i.DomainName.ToUpper() == genericTypeName.Name.ToUpper()).ToList();
                        }

                        IEnumerable genericValues = (IEnumerable)value;

                        foreach (var genericValue in genericValues)
                        {
                            Anonymized(genericValue, propertyClassSettings);
                        }
                    }
                }
            }

        }

        return fromAnonymizeObject;
    }
}

public class ReflecClassA
{
    public int Id { get; set; }
    public List<string> Names { get; set; }

    public List<ReflecClassB> ReflecClassBs { get; set; }
}

public class ReflecClassB
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ReflecClassB Self { get; set; }
}
public class ReflectionSetting
{
    public string DomainName { get; set; }
    public List<string> Properties { get; set; }
    public List<ReflectionSetting> PropertyClasses { get; set; } = new List<ReflectionSetting>();
}