using ECommerceSimplesBackend.Application.ViewModels.ProductViewModels;
using MediatR;

namespace ECommerceSimplesBackend.Application.Queries.ProductQueries.GetAllProductsBetweenPricesAsync
{
    public class GetAllProductsBetweenPricesAsyncQuery : IRequest<List<ProductInfoViewModelDto>>
    {
        public decimal minPrice { get; set; }
        public decimal maxprice { get; set; }

        public GetAllProductsBetweenPricesAsyncQuery(decimal minPrice, decimal maxprice)
        {
            this.minPrice = minPrice;
            this.maxprice = maxprice;
        }
    }
}
