using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Sample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers();

builder.Services.AddScoped<IValidator<Person>, PersonValidator>();

//ValidatorOptions.Global.PropertyNameResolver = (type, member, expression) =>
//{
//    if (member != null)
//    {
//        return member.Name + "Foo";
//    }
//    return null;
//};

//builder.Services.AddScoped<IValidator<Address>, AddressValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
