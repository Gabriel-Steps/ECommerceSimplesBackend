using ECommerceSimplesBackend.Application.Exceptions.CartExceptions;
using ECommerceSimplesBackend.Domain.Entities;
using ECommerceSimplesBackend.Infra.Repositories.CartRepositories;
using MediatR;

namespace ECommerceSimplesBackend.Application.Queries.CartQueries.GetCartByUserIdAsync
{
    public class GetCartByUserIdAsyncQueryHandler : IRequestHandler<GetCartByUserIdAsyncQuery, Cart>
    {
        private readonly ICartRepository _repository;

        public GetCartByUserIdAsyncQueryHandler(ICartRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cart> Handle(GetCartByUserIdAsyncQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCartByUserId(request.UserId, cancellationToken) ??
                throw new NotFoundCartByUserIdException(request.UserId);
        }
    }
}
