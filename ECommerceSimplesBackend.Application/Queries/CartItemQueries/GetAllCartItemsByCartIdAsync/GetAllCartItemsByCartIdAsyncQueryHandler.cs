using ECommerceSimplesBackend.Application.ViewModels.CartItemViewModels;
using ECommerceSimplesBackend.Infra.Repositories.CartItemRepositories;
using ECommerceSimplesBackend.Infra.Repositories.ProductRepositories;
using MediatR;

namespace ECommerceSimplesBackend.Application.Queries.CartItemQueries.GetAllCartItemsByCartIdAsync
{
    public class GetAllCartItemsByCartIdAsyncQueryHandler : IRequestHandler<GetAllCartItemsByCartIdAsyncQuery, List<CartItemInfoViewModelDto>>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;

        public GetAllCartItemsByCartIdAsyncQueryHandler(ICartItemRepository cartItemRepository, IProductRepository productRepository)
        {
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
        }

        public async Task<List<CartItemInfoViewModelDto>> Handle(GetAllCartItemsByCartIdAsyncQuery request, CancellationToken cancellationToken)
        {
            var listItems = await _cartItemRepository.GetAllCartItemsByCartId(request.Id, cancellationToken);
            var products = await _productRepository.GetAllProductsByCartItem(listItems, cancellationToken);

            var productDic = products.ToDictionary(p => p.Id);

            var cartItemDtos = listItems.Select(item => new CartItemInfoViewModelDto
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                ImageUrlProduct = productDic[item.ProductId].ImageUrl,
                NameProduct = productDic[item.ProductId].Name,
                ProductPrice = item.ProductPrice,
                TotalPrice = item.ProductPrice * item.Quantity
            }).ToList();

            return cartItemDtos;
        }
    }
}
