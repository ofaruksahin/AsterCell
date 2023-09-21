using AsterCell.Application.Common.Constants;
using System.Text.Json.Serialization;

namespace AsterCell.Application.Common.Models
{
    public class Result
    {
        public bool IsSuccess { get; protected set; }
        public string Message { get; protected set; }

        public void SetSuccess()
        {
            IsSuccess = true;
        }

        public void SetFail(string message)
        {
            Message = message;
        }

        public Result()
        {
            IsSuccess = true;
            Message = ResultMessages.SuccessMessage;
        }

        [JsonConstructor]
        public Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }

    public class Result<T> : Result
    {
        public T Data { get; private set; }

        public Result()
        {
        }

        public void SetData(T data)
        {
            Data = data;
        }

        [JsonConstructor]
        public Result(T data, bool isSuccess, string message)
        {
            Data = data;
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
