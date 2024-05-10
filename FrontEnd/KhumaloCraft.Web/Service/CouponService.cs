using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhumaloCraft.Web.Models;
using KhumaloCraft.Web.Service.IService;
using KhumaloCraft.Web.Utility;

namespace KhumaloCraft.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO> CreateCouponAsync(CouponDTO couponDTO)
        {
            return await _baseService.SendAsync(new RequestDTO{
                ApiType =StaticDetails.ApiType.POST,
                Data=couponDTO,
                Url = StaticDetails.CouponAPIBase+"/api/coupon"
            });
        }

        public async Task<ResponseDTO> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO{
                ApiType =StaticDetails.ApiType.DELETE,
                Url = StaticDetails.CouponAPIBase+"/api/coupon/" + id
            });
        }

        public async Task<ResponseDTO> GetAllCouponAsync()
        {
            return await _baseService.SendAsync(new RequestDTO{
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.CouponAPIBase+"/api/coupon"
            });
        }

        public async Task<ResponseDTO> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDTO{
                ApiType =StaticDetails.ApiType.GET,
                Url = StaticDetails.CouponAPIBase+"/api/coupon/GetByCode/"+couponCode
            });
        }

        public async Task<ResponseDTO> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO{
                ApiType =StaticDetails.ApiType.GET,
                Url = StaticDetails.CouponAPIBase+"/api/coupon/" + id
            });
        }

        public async Task<ResponseDTO> UpdateCouponAsync(CouponDTO couponDTO)
        {
            return await _baseService.SendAsync(new RequestDTO{
                ApiType =StaticDetails.ApiType.PUT,
                Data=couponDTO,
                Url = StaticDetails.CouponAPIBase+"/api/coupon"
            });
        }
    }
}