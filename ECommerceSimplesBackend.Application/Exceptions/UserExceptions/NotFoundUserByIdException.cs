using System.Net;

namespace ECommerceSimplesBackend.Application.Exceptions.UserExceptions
{
    public class NotFoundUserByIdException : ApiException
    {
        public NotFoundUserByIdException(int id) : 
            base($"Nenhum usuário com o ID: {id} foi encontrado!", HttpStatusCode.NotFound) { }
    }
}
