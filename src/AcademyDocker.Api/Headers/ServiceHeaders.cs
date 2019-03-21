using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AcademyDocker.Api.Headers
{
    public class ServiceHeaders
    {
        public const string CLIENT_ID = "X-Client-Id";
        public const string CORRELATION_ID = "X-Correlation-Id";
        public const string GLOBAL_USER_ID = "X-Global-User-Id";
        public const string TENANT = "X-Tenant";
        public const string ROLES = "X-Roles";

        [FromHeader(Name = CLIENT_ID)]
        [Required]
        public string ClientId { get; set; }

        [FromHeader(Name = CORRELATION_ID)]
        [Required]
        public Guid? CorrelationId { get; set; }

        [FromHeader(Name = GLOBAL_USER_ID)]
        public long? GlobalUserId { get; set; }

        [FromHeader(Name = TENANT)]
        [Required]
        public string Tenant { get; set; }

        [FromHeader(Name = ROLES)]
        [Required]
        public string Roles { get; set; }

        /// <summary>
        /// GetRoles
        /// </summary>
        /// <returns></returns>
        public static string[] GetRoles(string role)
        {
            if (string.IsNullOrEmpty(role))
            {
                return new string[0];
            }

            return role.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
