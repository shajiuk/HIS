using FluentValidation;
using FluentValidation.Results;
using Travco.HIS.Api.Requests;

namespace Travco.HIS.Commands.SearchHA
{
    public class SearchParamsValidator : AbstractValidator<SearchRequest>
    {
        public SearchParamsValidator()
        {   
            RuleFor(param => param.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(param => param.PageSize).GreaterThanOrEqualTo(0);
        }

        public override ValidationResult Validate(ValidationContext<SearchRequest> context)
        {
            return context.InstanceToValidate == null
                ? new ValidationResult(new[] { new ValidationFailure("SearchHotelsParams", "SearchHotelsParams cannot be null") })
                : base.Validate(context);
        }
    }
}