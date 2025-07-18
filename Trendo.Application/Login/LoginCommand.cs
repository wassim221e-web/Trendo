
using MediatR;

namespace Trendo.Application.Auth.Command;

public class LoginCommand
{
    public class Request : IRequest<Response>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Response
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}