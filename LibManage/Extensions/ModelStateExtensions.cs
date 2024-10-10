using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LibManage.Extensions
{
    public static class ModelStateExtensions
    {

        public static IEnumerable<string> ConvertModelStateErrors(ModelStateDictionary modeState)
        {

            return modeState
                       .Where(x => x.Value.Errors.Any())
                       .Select(x =>
                       {
                           var errorMessages = string.Join(", ", x.Value.Errors.Select(e => e.ErrorMessage));
                           return $"{x.Key}: {errorMessages}";
                       })
                       .ToList();
        }
    }
}
