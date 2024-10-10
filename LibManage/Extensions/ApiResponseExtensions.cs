using LibManage.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LibManage.Extensions
{
    public static class ApiResponseExtensions
    {
        public static ApiResponse<T> FromModelState<T>(this ApiResponse<T> response, ModelStateDictionary modelState, string message = "Preencha todas as validações", int status = 400)
        {
            var errors = modelState
                .Where(x => x.Value.Errors.Any())
                .SelectMany(x => x.Value.Errors.Select(e => $"{x.Key}: {e.ErrorMessage}"))
                .ToList();

            return response.Error(errors, status, message);
        }
    }
}
