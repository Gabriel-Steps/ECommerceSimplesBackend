namespace ECommerceSimplesBackend.Application.ViewModels.CartItemViewModels
{
    public class CartItemInfoViewModelDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ImageUrlProduct { get; set; } = null!;
        public string NameProduct { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
