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

    [HttpGet]
    [Route("[action]")]
    public async Task<ValueResult> TrueValue(bool value)
    {
        return await _service.GetTrueValue(value);
    }
}
