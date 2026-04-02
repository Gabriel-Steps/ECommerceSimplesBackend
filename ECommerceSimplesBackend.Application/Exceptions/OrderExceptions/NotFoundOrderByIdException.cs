using System.Net;

namespace ECommerceSimplesBackend.Application.Exceptions.OrderExceptions
{
    public class NotFoundOrderByIdException : ApiException
    {
        public NotFoundOrderByIdException(int id) : 
            base($"Nenhuma encomenda com o ID: {id} foi encontrada!", HttpStatusCode.NotFound)
        {
        }
    }
}
