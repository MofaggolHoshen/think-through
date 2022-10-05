using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using ModelBindingMessageProvider;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(options => { options.ResourcesPath = "Resources"; });

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("fa") };
    options.DefaultRequestCulture = new RequestCulture("en", "en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddMvc()
    .AddDataAnnotationsLocalization()
            .AddViewLocalization();


builder.Services.AddOptions<MvcOptions>()
    .Configure<IStringLocalizerFactory>((options, iStringLocalizerFactory) =>
    {
        //var L = iStringLocalizerFactory.Create(typeof(SharedResources));
        var L = iStringLocalizerFactory.Create("SharedResources", "ModelBindingMessageProvider");

        options.ModelBindingMessageProvider.SetValueIsInvalidAccessor((x) => L["The value '{0}' is invalid."]);
        options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor((x) => L["The field {0} must be a number."]);
        options.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor((x) => L["A value for the '{0}' property was not provided.", x]);
        options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => L["The value '{0}' is not valid for {1}.", x, y]);
        options.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => L["A value is required."]);
        options.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor((x) => L["The supplied value is invalid for {0}.", x]);
        options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor((x) => L["Null value is invalid.", x]);

        options.MaxModelBindingCollectionSize = 2000;   //When we post bulk collection here is the exception, this will fix it. 

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
var locOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
