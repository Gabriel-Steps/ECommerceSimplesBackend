using System.Net;

namespace ECommerceSimplesBackend.Application.Exceptions.AuthExceptions
{
    public class UserPasswordIsIncorrectException : ApiException
    {
        public UserPasswordIsIncorrectException(string email) : 
            base($"A senha usada para acessar o usuário com o e-mail: {email} | Foi rejeitado", HttpStatusCode.Unauthorized)
        {}
    }
}
