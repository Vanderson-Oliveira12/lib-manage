using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LibManage.Models
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public IEnumerable<string>? Errors { get; set; } = new List<string>();

        public ApiResponse<T> Error(IEnumerable<string>? errors = null, int status = 0, string message = "Nenhum registro encontrado")
        {

            errors ??= new List<string>();

            return new ApiResponse<T>()
            {
                Data = default,
                IsSucceeded = false,
                StatusCode = status,
                Message = message,
                Errors = errors,
            };
        }

        public ApiResponse<T> Success(T data, int status = 200, string message = "OK")
        {
            return new ApiResponse<T>
            {
                Data = data,
                IsSucceeded = true,
                StatusCode = 200,
                Message = message,
                Errors = null,
            };
        }

    }
}
