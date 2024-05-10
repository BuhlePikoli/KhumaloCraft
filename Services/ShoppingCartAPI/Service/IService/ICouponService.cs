using KhumaloCraft.Services.ShoppingCartAPI.Models.Dto;

namespace KhumaloCraft.Services.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
