using FluentValidation.Results;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FluentValidation.Sample.Models;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Address Address { get; set; }
}
public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(i => i.Id)
            .GreaterThan(0)
            .NotEqual(0);


        RuleFor(i => i.Name)
          .NotEmpty()
          //.WithMessage(i => $"The field {nameof(Person.Name)} is required.")
          .MinimumLength(2)
          //.WithMessage(i => $"The field {nameof(Person.Name)} should be min 2.")
          .MaximumLength(5)
          //.WithMessage(i => $"The field {nameof(Person.Name)} should be min 2.")
          .WithName(i => $"Employee with ID, {i.Id}");


        RuleFor(i => i.Address)
                .NotEmpty()
                .SetValidator(new AddressValidator())
                .WithName(i => $"Employee with ID, {i.Id}");

        //RuleForEach(i => i.employees)
        //           .OverrideIndexer((batchFile, employees, employee, index) => $"[employment_contract_id: {employee.employee_identification_number}]")
        //           .SetValidator(new EmployeeValidator())
        //           .OverridePropertyName("employee");

    }

    public override async Task<ValidationResult> ValidateAsync(ValidationContext<Person> context, CancellationToken cancellation = default)
    {
        var result = await base.ValidateAsync(context, cancellation);


        if (!result.IsValid)
        {
            var person = context.InstanceToValidate;

            foreach (var error in result.Errors)
            {
                error.PropertyName = $"Person[ID:{person.Id}].{error.PropertyName}";
            }
            return new ValidationResult(result.Errors);
        }

        return new ValidationResult();
    }
}

public class Address
{
    public string Road { get; set; }
}

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(i => i.Road)
            .NotEmpty()
            .WithMessage(i => $"The field {nameof(Address.Road)} is required.")
            .Length(5)
            .WithMessage(i => $"The field should be 5.");
    }
}