using System.ComponentModel.DataAnnotations;

namespace InnovationDevTask.Attributes
{
    public class StatusValidator : ValidationAttribute
    {
        private readonly string[] _acceptedValues;
        public StatusValidator(params string[] acceptedValues)
        {
            _acceptedValues = acceptedValues;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            if (_acceptedValues.Select(x => x.ToLowerInvariant())
                .Contains(value.ToString().ToLowerInvariant()))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }
}
