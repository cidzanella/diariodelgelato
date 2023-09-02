using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Wrappers
{
    // Generic wrapper for service response to API controller.
    public class ServiceResponse<T> where T : class
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public T EntityDTO { get; protected set; }

        public ServiceResponse(bool success, string message, T entityDTO)
        {
            Success = success;
            Message = message;
            EntityDTO = entityDTO;
        }

        public ServiceResponse(T entityDTO) : this(true, string.Empty, entityDTO)
        {

        }

        public ServiceResponse(string message) : this(false, message, null)
        {

        }
    }
}
