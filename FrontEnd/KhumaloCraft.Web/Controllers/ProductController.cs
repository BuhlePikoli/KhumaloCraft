/*
Author: Buhle Pikoli
Date: 09/05/2024
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KhumaloCraft.Web.Models;
using KhumaloCraft.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace KhumaloCraft.Web.Controllers
{
    // [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDTO> list = new();

            ResponseDTO response = await _productService.GetAllProductAsync();

            if(response != null && response.isSuccess){
                list = JsonConvert.DeserializeObject<List<ProductDTO>>(Convert.ToString(response.Result));
            }else{
                TempData["error"] = response.Message;
            }
            return View(list);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                ResponseDTO response = await _productService.CreateProductAsync(model);

                if (response != null && response.isSuccess)
                {
                    TempData["success"] = "Product created successfully";
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }


        public async Task<IActionResult> ProductDelete(int productId){

            ResponseDTO response = await _productService.GetProductByIdAsync(productId);

            if(response != null && response.isSuccess){
                ProductDTO model = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
                return View(model);
            }else{
                TempData["error"] = response.Message;
            }            
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductDTO productDTO){

            ResponseDTO response = await _productService.DeleteProductAsync(productDTO.ProductId);

            if(response != null && response.isSuccess){
                TempData["success"] = "Product deleted successfully";
                return RedirectToAction(nameof(ProductIndex));
                
            }else{
                TempData["error"] = response.Message;
            }
            return View(productDTO);
        }

        public async Task<IActionResult> ProductEdit(int productId){

            ResponseDTO response = await _productService.GetProductByIdAsync(productId);

            if(response != null && response.isSuccess){
                ProductDTO model = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
                return View(model);
            }else{
                TempData["error"] = response.Message;
            }            
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductDTO productDTO){

            if (ModelState.IsValid)
            {
                ResponseDTO response = await _productService.UpdateProductAsync(productDTO);

                if(response != null && response.isSuccess){
                    TempData["success"] = "Product updated successfully";
                    return RedirectToAction(nameof(ProductIndex));
                    
                }else{
                    TempData["error"] = response.Message;
                }
            }
            return View(productDTO);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}