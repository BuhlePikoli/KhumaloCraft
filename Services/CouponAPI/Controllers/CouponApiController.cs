using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CouponAPI.Data;
using CouponAPI.Models;
using CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CouponAPI.Controllers
{
    [ApiController]
    [Route("api/coupon")]
    [Authorize]
    public class CouponApiController : ControllerBase
    {
        private readonly AppDbContext  _context;
        private IMapper  _mapper;
        private ResponseDTO  _response;
        public CouponApiController(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
            _response = new ResponseDTO();
        }

        [HttpGet]
        public ResponseDTO Get(){
            try{
                IEnumerable<Coupon> coupons = _context.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDTO>> (coupons);
            }catch(Exception e){
                _response.isSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDTO Get(int id){
            try{
                Coupon coupon = _context.Coupons.First(x => x.CouponID == id);
                _response.Result = _mapper.Map<CouponDTO>(coupon);
            }catch(Exception e){
                _response.isSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDTO GetByCode(string code){
            try{
                Coupon coupon = _context.Coupons.First(x => x.CouponCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDTO>(coupon);
            }catch(Exception e){
                _response.isSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDTO Post([FromBody]  CouponDTO model) {
            try{
                Coupon obj = _mapper.Map<Coupon>(model);
                _context.Coupons.Add(obj);
                _context.SaveChanges();


               
                var options = new Stripe.CouponCreateOptions
                {
                    AmountOff = (long)(model.DiscountAmount*100),
                    Name = model.CouponCode,
                    Currency="usd",
                    Id=model.CouponCode,
                };
                var service = new Stripe.CouponService();
                service.Create(options);


                _response.Result = _mapper.Map<CouponDTO>(obj);
            }catch(Exception e){
                _response.isSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDTO Put([FromBody]  CouponDTO model) {
            try{
                Coupon obj = _mapper.Map<Coupon>(model);
                _context.Update(obj);
                _context.SaveChanges();
                _response.Result = _mapper.Map<CouponDTO>(obj);
            }catch(Exception e){
                _response.isSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDTO Delete(int id) {
            try{
                
                Coupon obj = _context.Coupons.First(u=>u.CouponID==id);
                _context.Coupons.Remove(obj);
                _context.SaveChanges();


                var service = new Stripe.CouponService();
                service.Delete(obj.CouponCode);
            }catch(Exception e){
                _response.isSuccess = false;
                _response.Message = e.Message;
            }
            return _response;
        }
    }
}