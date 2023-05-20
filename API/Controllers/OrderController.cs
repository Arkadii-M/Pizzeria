using BLL.Interface;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrderController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetUserOrders()
        { 
            var username = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            return Ok(await _orderService.GetUserOrders(username));
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrders()
        {
            return Ok(await _orderService.GetAllOrders());
        }


        [Authorize(Roles = "ADMIN")]
        [HttpPost("process/{id}")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> ProcessOrder(int id)
        {
            return Ok(await  _orderService.ProcessOrder(id));
        }



        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult<OrderDTO>> AddOrder(List<MenuDTO> orderedMenus)
        {
            var username = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            return Ok(await _orderService.AddOrder(new CustomerOrderDTO
            {
                UserId = (await _userService.GetByUserName(username)).UserId,
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
                OrderedMenu = orderedMenus

            }));
        }
    }
}
