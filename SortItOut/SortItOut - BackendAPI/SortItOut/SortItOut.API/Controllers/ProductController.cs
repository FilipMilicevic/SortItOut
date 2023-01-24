using Microsoft.AspNetCore.Mvc;
using SortItOut.Core.Interface;
using SortItOut.DataAccess;
using SortItOut.Models.Response;


namespace SortItOut.API.Controllers;


[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly ISortItOutService _service;

    public ProductController(ILogger<ProductController> logger, ISortItOutService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<bool> Authenticate([FromQuery]string username, [FromQuery]string password)
    { 
        return await _service.AuthenticateMe(username, password);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<bool> AddUser(string username, string password, byte AccountTypeId)
    {
        return await _service.AddUser(username, password, AccountTypeId);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<ValueResult> TrueValue(bool value)
    {
        return await _service.GetTrueValue(value);
    }
}
