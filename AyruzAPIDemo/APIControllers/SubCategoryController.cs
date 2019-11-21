using AyruzAPIDemo.Models;
using AyruzAPIDemo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using Umbraco.Core.Logging;

namespace AyruzAPIDemo.APIControllers
{
    public class SubCategoryController : UmbracoApiController
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ILogger _logger;

        public SubCategoryController(ISubCategoryService subCategoryService, ILogger logger)
        {
            _subCategoryService = subCategoryService;
            _logger = logger;
        }
        [HttpGet]
        [Route("api/v1/subcategory")]
        public IEnumerable<SubCategory> GetAll()
        {
            try
            {
                var categories =  _subCategoryService.GetAll();
                
                return categories;
            }
            catch (Exception ex)
            {
                _logger.Error<MasterCategoryController>(ex, "Error Occured while getting all sub categories.");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
    }
}