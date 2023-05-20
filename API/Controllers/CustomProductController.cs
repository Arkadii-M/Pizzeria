using BLL.Implementation;
using BLL.Interface;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomProductController : ControllerBase
    {
        private readonly ICustomProductSevice customProductSevice;

        public CustomProductController(ICustomProductSevice customProductSevice)
        {
            this.customProductSevice = customProductSevice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomProductDTO>>> GetAllCustomProducts()
        {
            return Ok(await customProductSevice.GetAllCustomProducts());
        }

        [HttpGet("pizza")]
        public async Task<ActionResult<IEnumerable<CustomProductDTO>>> GetPizzaCustomProducts()
        {
            return Ok(await customProductSevice.GetPizzaCustomProducts());
        }

        [HttpGet("salad")]
        public async Task<ActionResult<IEnumerable<CustomProductDTO>>> GetSaladCustomProducts()
        {
            return Ok(await customProductSevice.GetSaladCustomProducts());
        }

    }
}
