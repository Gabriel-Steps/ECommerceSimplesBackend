
namespace ECommerceSimplesBackend.Application.ViewModels.AuthViewModels
{
    public class UserAuthViewModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
