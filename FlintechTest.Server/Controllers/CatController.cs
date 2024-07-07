using FlintechTest.Server.Interface;
using FlintechTest.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;

namespace FlintechTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatController : ControllerBase
    {
        private readonly ILogger<CatController> logger;
        private readonly IRestRequest<CatRoot> restRequest;
        private readonly IOptions<AppSettings> appSettings;

        public CatController(ILogger<CatController> logger, IRestRequest<CatRoot> restRequest, IOptions<AppSettings> appSettings)
        {
            this.logger = logger;
            this.restRequest = restRequest;
            this.appSettings = appSettings;
        }

        [HttpGet]
        public async Task<ListCatPagination> Get(int? page)
        {
            if (!page.HasValue || page.Value < 0)
            {
                page = 0;
            }

            int limit = 5;
            if (appSettings != null && appSettings.Value != null)
            {
                if (appSettings.Value.PaginationLimitPerPage.HasValue && appSettings.Value.PaginationLimitPerPage > 0) {
                    limit = appSettings.Value.PaginationLimitPerPage.Value;
                }
            }

            // assuming the total count returned by the API to be 1000.
            int total = 1000;

            Dictionary<string, string> customHeader = new Dictionary<string, string>();
            customHeader.Add("x-api-key", "DEMO-API-KEY");

            RequestParam requestParam = new RequestParam
            {
                Url = "https://api.thecatapi.com/v1/images/search?size=med&mime_types=jpg&format=json&has_breeds=true&&page=" + page.ToString() + "&limit=" + limit.ToString(),
                ContentType = "application/json",
                CustomHeader = customHeader
            };

            IEnumerable<CatRoot> catRoots = await restRequest.Get(requestParam);
            ListCatPagination catRootList = new ListCatPagination
            {
                catRoots = catRoots,
                pagination = new Pagination
                {
                    page = page.Value,
                    limit = limit,
                    total = total
                }
            };

            return catRootList;
        }
    }
}
