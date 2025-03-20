using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OnlineLearning.API;

public static class ModelStateExtensions
{
    public static string GetAllErrors(this ModelStateDictionary modelState)
    {
        return string.Join("; ", modelState.Values
            .Where(v => v.Errors.Any())
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
    }
}
