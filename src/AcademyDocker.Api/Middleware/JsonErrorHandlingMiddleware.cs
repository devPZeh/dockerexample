using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AcademyDocker.DataContract.Data;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AcademyDocker.Api.Middleware
{
    public class JsonErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JsonSerializerSettings _serializerSettings;

        public JsonErrorHandlingMiddleware(RequestDelegate next)
        {
            _serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleException(httpContext, ex);
            }
        }

        private async Task HandleException(HttpContext httpContext, Exception ex)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = ex.Message,
                    Message = ex.StackTrace
                }
            };
            var errorResponse = new ErrorResponse()
            {
                Code = "unhandled.exception",
                Errors = errors
            };
            var json = JsonConvert.SerializeObject(errorResponse, _serializerSettings);

            httpContext.Response.ContentType = "application/json; charset=utf-8";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsync(json);

        }

    }
}
