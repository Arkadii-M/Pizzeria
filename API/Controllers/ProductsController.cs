using BLL.Interface;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IMenuService _menuService;

        public ProductsController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        //[HttpGet]
        //public async Task<ActionResult<MenuDTO>> GetAllMenu()
        //{
        //    var products = await _menuService.GetAllMenuItems();

        //    var totalItems = products.Count();



        //    return Ok(await _menuService.GetAllMenuItems());
        //}
    }
}
