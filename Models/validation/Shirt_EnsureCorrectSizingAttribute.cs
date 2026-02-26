using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.validation
{
    public class Shirt_EnsureCorrectSizingAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //我们用他来修饰shirt的一个对象属性，所以我们确定他是一个shirt对象
            var shirt = validationContext.ObjectInstance as Shirt;
            if (shirt != null&&!string.IsNullOrEmpty(shirt.Gender))
            {
                if (shirt.Gender.Equals("men", StringComparison.OrdinalIgnoreCase) && shirt.Size < 8)
                {
                    return new ValidationResult("For men's shirts,the size has to be bigger or equal to 8.");
                }
                else if(shirt.Gender.Equals("women", StringComparison.OrdinalIgnoreCase) && shirt.Size < 6)
               {
                    return new ValidationResult("For women's shirts,the size has to be bigger or equal to 6.");
                }

            }
            return ValidationResult.Success; 
        }
    }
}
