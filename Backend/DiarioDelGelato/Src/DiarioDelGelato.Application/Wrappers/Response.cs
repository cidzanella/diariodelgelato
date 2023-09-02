using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Wrappers
{
    // Used for CQRS Mediator Pattern (MediatR)
    public class Response<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Erros { get; set; }
        public T Data { get; set; }

        public Response()
        {
        }

        public Response(T data, string message = null)
        {
            Succeeded = true;
            Data = data;
            Message = message;
        }

        public Response(string message )
        {
            Succeeded = false;
            Message = message;
        }
    }
}
