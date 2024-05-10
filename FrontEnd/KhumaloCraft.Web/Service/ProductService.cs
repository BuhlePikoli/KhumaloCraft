using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhumaloCraft.Web.Models;
using KhumaloCraft.Web.Service.IService;
using KhumaloCraft.Web.Utility;

namespace KhumaloCraft.Web.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO> CreateProductAsync(ProductDTO productDTO)
        {
            return await _baseService.SendAsync(new RequestDTO{
                ApiType =StaticDetails.ApiType.POST,
                Data=productDTO,
                Url = StaticDetails.ProductAPIBase+"/api/product",
                ContentType = StaticDetails.ContentType.MultipartFormData
            });
        }

        public async Task<ResponseDTO> DeleteProductAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO{
                ApiType =StaticDetails.ApiType.DELETE,
                Url = StaticDetails.ProductAPIBase+"/api/product/" + id
            });
        }

        public async Task<ResponseDTO> GetAllProductAsync()
        {
            return await _baseService.SendAsync(new RequestDTO{
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductAPIBase+"/api/product"
            });
        }

        public async Task<ResponseDTO> GetProductAsync(string productName)
        {
            return await _baseService.SendAsync(new RequestDTO{
                ApiType =StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductAPIBase+"/api/product/GetByName/"+productName
            });
        }

        public async Task<ResponseDTO> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO{
                ApiType =StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductAPIBase+"/api/product/" + id
            });
        }

        public async Task<ResponseDTO> UpdateProductAsync(ProductDTO productDTO)
        {
            return await _baseService.SendAsync(new RequestDTO{
                ApiType =StaticDetails.ApiType.PUT,
                Data=productDTO,
                Url = StaticDetails.ProductAPIBase+"/api/product",
                ContentType = StaticDetails.ContentType.MultipartFormData
            });
        }
    }
}