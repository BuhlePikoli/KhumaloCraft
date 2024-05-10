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
    public class CouponController : Controller
    {
        private readonly ILogger<CouponController> _logger;
        private readonly ICouponService _couponService;

        public CouponController(ILogger<CouponController> logger, ICouponService couponService)
        {
            _logger = logger;
            _couponService = couponService;
        }

        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDTO> list = new();

            ResponseDTO response = await _couponService.GetAllCouponAsync();

            if(response != null && response.isSuccess){
                list = JsonConvert.DeserializeObject<List<CouponDTO>>(Convert.ToString(response.Result));
            }else{
                TempData["error"] = response.Message;
            }
            return View(list);
        }

        public async Task<IActionResult> CouponCreate(CouponDTO model){

            if(ModelState.IsValid){
                ResponseDTO response = await _couponService.CreateCouponAsync(model);

                if(response != null && response.isSuccess){
                    TempData["success"] = "Coupon created successfully";
                    return RedirectToAction(nameof(CouponIndex));
                }else{
                    TempData["error"] = response.Message;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> CouponDelete(int couponId){

            ResponseDTO response = await _couponService.GetCouponByIdAsync(couponId);

            if(response != null && response.isSuccess){
                CouponDTO model = JsonConvert.DeserializeObject<CouponDTO>(Convert.ToString(response.Result));
                return View(model);
            }else{
                TempData["error"] = response.Message;
            }            
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDTO couponDTO){

            ResponseDTO response = await _couponService.DeleteCouponAsync(couponDTO.CouponID);

            if(response != null && response.isSuccess){
                TempData["success"] = "Coupon deleted successfully";
                return RedirectToAction(nameof(CouponIndex));
                
            }else{
                TempData["error"] = response.Message;
            }
            return View(couponDTO);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}