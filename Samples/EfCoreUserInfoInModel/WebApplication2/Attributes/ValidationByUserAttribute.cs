using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Attributes
{
    public class ValidatedByUserAttribute : ValidationAttribute
    {
        public ValidatedByUserAttribute() : base()
        {
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var config = validationContext.GetRequiredService<IConfiguration>();

            var contex = validationContext.GetRequiredService<IHttpContextAccessor>();

            if (contex != null)
            {
                var subKey = contex?.HttpContext?.Request.Headers.FirstOrDefault(i=> i.Key == "subscription").Value;
            }

            return ValidationResult.Success;
        }
    }
}
