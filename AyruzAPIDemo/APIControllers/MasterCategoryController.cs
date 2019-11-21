using AyruzAPIDemo.Models;
using System.Collections.Generic;
using System.Web.Http;
using Umbraco.Web.WebApi;
using AyruzAPIDemo.Services.Interfaces;
using System;
using System.Net.Http;
using System.Net;
using Umbraco.Core.Logging;

namespace AyruzAPIDemo.APIControllers
{
    public class MasterCategoryController : UmbracoApiController
    {
        private readonly IMasterCategoryService _masterCategoryService;
        private readonly ILogger _logger;

        public MasterCategoryController(IMasterCategoryService masterCategoryService, ILogger logger)
        {
            _masterCategoryService = masterCategoryService;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/v1/mastercategory")]
        public IEnumerable<MasterCategory> GetAll()
        {
            try
            {
                var categories = _masterCategoryService.GetAll();
                
                return categories;
            }
            catch (Exception ex)
            {
                _logger.Error<MasterCategoryController>(ex, "Error Occured while getting all master categories.");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
    }
}