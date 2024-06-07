using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Wrappers
{
    // Generic wrapper for service response to API controller.
    public class ServiceResponse<T>
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public T Data { get; protected set; }

        public ServiceResponse(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public ServiceResponse(T data, string message = default) : this(true, message, data)
        {

        }

        public ServiceResponse(string message) : this(false, message, default)
        {

        }
    }
}
