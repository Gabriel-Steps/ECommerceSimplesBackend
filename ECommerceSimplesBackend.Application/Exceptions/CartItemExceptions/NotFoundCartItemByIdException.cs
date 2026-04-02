using System.Net;

namespace ECommerceSimplesBackend.Application.Exceptions.CartItemExceptions
{
    public class NotFoundCartItemByIdException : ApiException
    {
        public NotFoundCartItemByIdException(int cartItem) : 
            base($"Não foi encontrado nenhum item desse carrinho com o ID: {cartItem}", HttpStatusCode.NotFound)
        {
        }
    }
}
