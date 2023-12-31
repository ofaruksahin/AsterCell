﻿using System.Net;
using System.Text.Json.Serialization;

namespace AsterCell.Application.Common.Models
{
    public class ApiResponse
    {
        public object Data { get; private set; }

        [JsonIgnore]
        public int StatusCode { get; private set; }
        public List<string> Messages { get; private set; }

        public ApiResponse()
        {
            Messages = new List<string>();
        }

        public static ApiResponse Success(object data, int statusCode = (int)HttpStatusCode.OK)
           => new ApiResponse
           {
               Data = data,
               StatusCode = statusCode,
               Messages = new List<string>()
           };

        public static ApiResponse Success(object data, string message, int statusCode = (int)HttpStatusCode.OK)
            => new ApiResponse
            {
                Data = data,
                StatusCode = statusCode,
                Messages = new List<string>() { message }
            };

        public static ApiResponse Success(object data, List<string> messages, int statusCode = (int)HttpStatusCode.OK)
            => new ApiResponse
            {
                Data = data,
                StatusCode = statusCode,
                Messages = messages
            };

        public static ApiResponse Fail(object data, int statusCode = (int)HttpStatusCode.NotFound)
            => new ApiResponse
            {
                Data = data,
                StatusCode = statusCode,
                Messages = new List<string>()
            };

        public static ApiResponse Fail(object data, string message, int statusCode = (int)HttpStatusCode.NotFound)
            => new ApiResponse
            {
                Data = data,
                StatusCode = statusCode,
                Messages = new List<string> { message }
            };

        public static ApiResponse Fail(object data, List<string> messages, int statusCode = (int)HttpStatusCode.NotFound)
            => new ApiResponse
            {
                Data = data,
                StatusCode = statusCode,
                Messages = messages
            };
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
    }
}
