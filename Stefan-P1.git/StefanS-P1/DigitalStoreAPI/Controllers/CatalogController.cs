using DigitalStoreAPI.Models;
using DigitalStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DigitalStoreAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public CatalogController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Catalog>> GetAll()
    {
        string connect = _configuration.GetSection("ConnectionString").GetSection("PrintShopDB").Value;
        using SqlConnection connection = new(connect);
        return CatalogService.GetAll(connection);
    }
        

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<List<Catalog>> Get(int id)
    {
        string connect = _configuration.GetSection("ConnectionString").GetSection("PrintShopDB").Value;
        using SqlConnection connection = new(connect);
        var catalog = CatalogService.Get(id,connection);

        return catalog;
    }


    // POST action

    // PUT action

    // DELETE action
}