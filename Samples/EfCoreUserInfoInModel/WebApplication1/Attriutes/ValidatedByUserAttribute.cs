using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Attriutes
{
    public class ValidatedByUserAttribute : ValidationAttribute
    {
        public ValidatedByUserAttribute() : base()
        {
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var config = validationContext.GetRequiredService<IConfiguration>();

            var contex = validationContext.GetRequiredService<HttpContext>();

            return base.IsValid(value, validationContext);
        }
    }
}
