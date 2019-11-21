using AyruzAPIDemo.Models;
using AyruzAPIDemo.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Http;
using Umbraco.Web.WebApi;
using Umbraco.Core.Logging;
using System;
using System.Net.Http;
using System.Net;

namespace AyruzAPIDemo.APIControllers
{
    public class ShopController : UmbracoApiController
    {
        private readonly IShopService _shopService;
        private readonly ILogger _logger;
        public ShopController(IShopService shopService, ILogger logger)
        {
            _shopService = shopService;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/v1/shop")]
        public IEnumerable<Shop> GetAll()
        {
            try
            {
                var shops = _shopService.GetAll();
               
                return shops;
            }
            catch (Exception ex)
            {
                _logger.Error<ShopController>(ex, "Error Occured while getting all shops.");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpGet]
        [Route("api/v1/shop/bymastercategory/{mastercategory}")]
        public IEnumerable<Shop> ByMasterCategory(string mastercategory)
        {
            try
            {
                var shops = _shopService.ByMasterCategory(mastercategory);
                
                return shops;
            }
            catch (Exception ex)
            {
                _logger.Error<ShopController>(ex, "Error Occured while getting shops by master category.");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpGet]
        [Route("api/v1/shop/bysubcategory/{subcategory}")]
        public IEnumerable<Shop> BySubCategory(string subcategory)
        {
            try
            {
                var shops = _shopService.BySubCategory(subcategory);
                
                return shops;
            }
            catch (Exception ex)
            {
                _logger.Error<ShopController>(ex, "Error Occured while getting shops by sub category.");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
    }
}