using System.Net;

namespace ECommerceSimplesBackend.Application.Exceptions.CartExceptions
{
    public class NotFoundCartByUserIdException : ApiException
    {
        public NotFoundCartByUserIdException(int userId) : 
            base($"Nenhum carrinho foi encontrado vinculado com o usuário com ID: {userId}", HttpStatusCode.NotFound) { }
    }
}
