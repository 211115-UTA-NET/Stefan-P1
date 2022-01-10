using DigitalStoreAPI.Models;
using DigitalStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DigitalStoreAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public OrdersController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<ExistingOrders>> Get(string user)
    {
        string connect = _configuration.GetSection("ConnectionString").GetSection("PrintShopDB").Value;
        using SqlConnection connection = new(connect);
        return ExistingOrderService.Get(user,connection);
    }
}