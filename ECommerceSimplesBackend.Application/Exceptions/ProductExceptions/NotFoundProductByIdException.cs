using System.Net;

namespace ECommerceSimplesBackend.Application.Exceptions.ProductExceptions
{
    public class NotFoundProductByIdException : ApiException
    {
        public NotFoundProductByIdException(int id) : 
            base($"Não foi encontrado nenhum produto com o ID: {id}", HttpStatusCode.NotFound)
        {
        }
    }
}
