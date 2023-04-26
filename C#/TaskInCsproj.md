## Copy File (External Package XML Doc) to Specific Directory Using Copy Task in csproj

```XML
  <Target Name="CopyDocumentationFiles" BeforeTargets="Build">
    <ItemGroup>
      <DocumentationFiles Include="%(Reference.RelativeDir)/Abc.One.API.*.xml" />
    </ItemGroup>

    <Copy SourceFiles="@(DocumentationFiles)" DestinationFolder="$(OutputPath)" />
  </Target>
```

Copy to publish for use $(PublishDir).

In azure build pipeline it's not working, not copying file to destination folder so use Copy File task -

```YML
- task: CopyFiles@2
  displayName: 'Copy XML for swagger'
  inputs:
    SourceFolder: '$(UserProfile)\.nuget\packages'
    Contents: '**\*ABC.CDF.API.AddOns*.xml'
    TargetFolder: '$(build.artifactstagingdirectory)'
```

I was copying XML documentation file for swagger, Copy File task will copy files with folder structure so we need to read all XML documentation files from sub folders while settingup/injecting swagger

```C#
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "CardOnlineMaintenance",
            Version = "v1"
        }
     );

    //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "ABC.DEF.API.*.xml", SearchOption.AllDirectories).ToList();
    xmlFiles.ForEach(xmlFile => c.IncludeXmlComments(xmlFile));
});
```

## Custom Tag in .csproj

```XML
<PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <Version>1.0.1</Version>
    <VersionDate>2023-01-27</VersionDate>
</PropertyGroup>
<ItemGroup>
    <AssemblyAttribute Include="Abc.Efg.API.Helper.VersionDateAttribute">
      <_Parameter1>$(VersionDate)</_Parameter1>
    </AssemblyAttribute>
 </ItemGroup>
```

```C#

// Attribute to read date from .csproj
namespace Abc.Efg.API.Helper
{
    [System.AttributeUsage(System.AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    sealed class VersionDateAttribute : System.Attribute
    {
        public DateTime Date { get; }
        public VersionDateAttribute(string versionDate)
        {
            if(DateTime.TryParse(versionDate, out DateTime date))
                Date = date;
        }
    }
}

// Reading values using System.Reflection
public void GetVersion()
    {
        var version = Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
        
        DateTime versionDate = DateTime.MinValue;

        if (Assembly.GetEntryAssembly()?.GetCustomAttribute<VersionDateAttribute>() is VersionDateAttribute versionAtt)
            versionDate = versionAtt.Date;
    }

```
