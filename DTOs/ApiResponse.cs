using System.Net;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace MahalliyMarket.DTOs
{
    public class ApiResponse<T>
    {
               //HTTP Status Code of the response
        public HttpStatusCode status_code { get; set; }

        //Indicates whether the request was successful
        public bool success { get; set; }

        //Response data in case of success
        public T? data { get; set; } 

        //List of errors in case of failure
        public List<string> errors { get; set; } = new List<string>();

        public ApiResponse()
        {
            success = true;
            errors = new List<string>();
        }

        public ApiResponse(int statusCode, T data)
        {
            this.status_code = (HttpStatusCode)statusCode;
            this.success = true;
            this.data = data;
            this.errors = new List<string>();
        }

        public ApiResponse(HttpStatusCode statusCode, T data)
        {
            this.status_code = statusCode;
            this.success = true;
            this.data = data;
            this.errors = new List<string>();
        }

        public ApiResponse(HttpStatusCode statusCode, List<string> errors)
        {
            this.status_code = statusCode;
            this.success = false;
            this.errors = errors;
        }

        public ApiResponse(HttpStatusCode statusCode, string error)
        {
            this.status_code = statusCode;
            this.success = false;
            this.errors = new List<string> { error };
        }
    }
}
