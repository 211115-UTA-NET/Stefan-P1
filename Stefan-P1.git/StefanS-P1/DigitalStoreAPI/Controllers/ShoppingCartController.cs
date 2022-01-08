using DigitalStoreAPI.Models;
using DigitalStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DigitalStoreAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ShoppingCartController : Controller
{
    private readonly IConfiguration _configuration;
    public ShoppingCartController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    //Post to shopping cart
    [HttpPost]
    public ActionResult AddToCart()
    {
        string connect = _configuration.GetSection("ConnectionString").GetSection("PrintShopDB").Value;
        using SqlConnection connection = new(connect);
        //ShoppingCartContext.AddToCart(id,quantity,orderID,connection);

        return StatusCode(200);
    }

}

