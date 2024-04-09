using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Responses
{
    public class BaseResponse
    {
        public object Id { get; set; } = null!;
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public object Errors { get; set; } = null!;

        public static BaseResponse Created(Type type, object id)
        {
            return new BaseResponse
            {
                Id = id,
                IsSuccess = true,
                Message = $"{type.Name} created successfully"
            };
        }

        public static BaseResponse Updated(Type type, object id)
        {
            return new BaseResponse
            {
                Id = id,
                IsSuccess = true,
                Message = $"{type.Name} updated successfully"
            };
        }

        public static BaseResponse Success(string message)
        {
            return new BaseResponse
            {
                IsSuccess = true,
                Message = message
            };
        }

        public static BaseResponse Failed(string message, object errors)
        {
            return new BaseResponse
            {
                IsSuccess = false,
                Message = message,
                Errors = errors
            };
        }
    }
}
