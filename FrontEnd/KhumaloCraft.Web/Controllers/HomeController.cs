/*
Author: Buhle Pikoli
Date: 09/05/2024
*/

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KhumaloCraft.Web.Models;
using KhumaloCraft.Web.Service.IService;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using IdentityModel;

namespace KhumaloCraft.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IProductService _productService;
    private readonly ICartService _cartService;

    public HomeController(ILogger<HomeController> logger, IProductService productService, ICartService cartService)
    {
        _logger = logger;
        _productService = productService;
        _cartService = cartService;
    }


    public async Task<IActionResult> Index()
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

    [Authorize]
    public async Task<IActionResult> ProductDetails(int productId)
    {
         ProductDTO model = new();

            ResponseDTO response = await _productService.GetProductByIdAsync(productId);

            if(response != null && response.isSuccess){
                model = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
            }else{
                TempData["error"] = response.Message;
            }
            return View(model);
    }

    [Authorize]
        [HttpPost]
        [ActionName("ProductDetails")]
        public async Task<IActionResult> ProductDetails(ProductDTO productDto)
        {
            CartDto cartDto = new CartDto()
            {
                CartHeader = new CartHeaderDto
                {
                    UserId = User.Claims.Where(u => u.Type == JwtClaimTypes.Subject)?.FirstOrDefault()?.Value
                }
            };

            CartDetailsDto cartDetails = new CartDetailsDto()
            {
                Count = productDto.Count,
                ProductId = productDto.ProductId,
            };

            List<CartDetailsDto> cartDetailsDtos = new() { cartDetails};
            cartDto.CartDetails = cartDetailsDtos;

            ResponseDTO response = await _cartService.UpsertCartAsync(cartDto);

            if (response != null && response.isSuccess)
            {
                TempData["success"] = "Item has been added to the Shopping Cart";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(productDto);
        }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
