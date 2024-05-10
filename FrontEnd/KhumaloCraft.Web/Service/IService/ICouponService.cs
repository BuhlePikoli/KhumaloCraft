using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhumaloCraft.Web.Models;

namespace KhumaloCraft.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDTO> GetCouponAsync(string couponCode);
        Task<ResponseDTO> GetAllCouponAsync();
        Task<ResponseDTO> GetCouponByIdAsync(int id);
        Task<ResponseDTO> CreateCouponAsync(CouponDTO couponDTO);
        Task<ResponseDTO> UpdateCouponAsync(CouponDTO couponDTO);
        Task<ResponseDTO> DeleteCouponAsync(int id);
    }
}