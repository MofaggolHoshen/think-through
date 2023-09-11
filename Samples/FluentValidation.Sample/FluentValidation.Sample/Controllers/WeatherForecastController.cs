using FluentValidation.Sample.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace FluentValidation.Sample.Controllers
{
    [ApiController]
    [Route("")]
    public class WeatherForecastController : ControllerBase
    {
        private ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpPost("person")]
        public async Task<IActionResult> CreatePerson(Person person, [FromServices] IValidator<Person> validator)
        {
            var result = await validator.ValidateAsync(person);

            if (!result.IsValid)
            {
                ModelStateDictionary modelState = new ModelStateDictionary();

                foreach (var error in result.Errors)
                {
                    modelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return ValidationProblem(modelState);
            }


            return Ok(person);
        }
    }
}
