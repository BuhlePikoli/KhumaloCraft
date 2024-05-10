using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhumaloCraft.Web.Models;

namespace KhumaloCraft.Web.Service.IService
{
    public interface IProductService
    {
        Task<ResponseDTO> GetProductAsync(string productName);
        Task<ResponseDTO> GetAllProductAsync();
        Task<ResponseDTO> GetProductByIdAsync(int id);
        Task<ResponseDTO> CreateProductAsync(ProductDTO productDTO);
        Task<ResponseDTO> UpdateProductAsync(ProductDTO productDTO);
        Task<ResponseDTO> DeleteProductAsync(int id);
    }
}