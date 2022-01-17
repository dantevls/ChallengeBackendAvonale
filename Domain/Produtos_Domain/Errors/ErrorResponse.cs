using System;
using System.Collections.Generic;

namespace Produtos_Domain.Errors
{
    public class ErrorResponse
    {
        public string TraceId { get; set; }

        public List<ErrorDetails> Errors { get; private set; }

        public ErrorResponse()
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetails>();
        }
        public ErrorResponse(string logref, string message)
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetails>();
            AddError(logref, message);
        }

        public class ErrorDetails
        {
            public string Logref { get; private set; }
            public string Message { get; private set; }
            public ErrorDetails(string logref, string message)
            {
                Logref = logref;
                Message = message;
            }
        }

        public void AddError(string logref, string message)
        {
            Errors.Add(new ErrorDetails(logref, message));
        }
    }

}
