using System.Net;

namespace ECommerceSimplesBackend.Application.Exceptions.AuthExceptions
{
    public class UserNotFoundByLoginException : ApiException
    {
        public UserNotFoundByLoginException(string email) :
            base($"Nenhum usuário com o e-mail {email} foi encontrado!", HttpStatusCode.NotFound){}
    }
}
