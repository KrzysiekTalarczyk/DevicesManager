using DevicesManager.Server.Helpers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace DevicesManager.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : Controller
    {
        public OkObjectResult Ok<T>(IEnumerable<T> value, SieveModel sieveModel, int totalResultCount)
        {
            return base.Ok(new PagedResult<T>(value, sieveModel.Page, sieveModel.PageSize, totalResultCount));
        }
    }
}
