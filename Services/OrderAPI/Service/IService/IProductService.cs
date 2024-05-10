
using KhumaloCraft.Services.OrderAPI.Models.Dto;

namespace KhumaloCraft.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
