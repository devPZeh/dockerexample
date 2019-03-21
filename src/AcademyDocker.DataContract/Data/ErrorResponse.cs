using System.Collections.Generic;

namespace AcademyDocker.DataContract.Data
{
    public class ErrorResponse
    {
        public string Code { get; set; }

        public IList<Error> Errors { get; set; }

        public ErrorResponse()
        {
            Errors = new List<Error>();
        }
    }
}