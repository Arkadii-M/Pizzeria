using API.Models;
using AutoMapper;
using BLL.Interface;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly IItemTypeService _itemTypeService;
        private readonly IMapper _mapper;

        public MenuController(IMenuService menuService, IItemTypeService itemTypeService, IMapper mapper)
        {
            _menuService = menuService;
            _itemTypeService = itemTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ProductModel>> GetAllMenu()
        {
            var products = await _menuService.GetAllMenuItems();

            var totalItems = products.Count();
            IReadOnlyList<ProductModel> rdOnly = _mapper.Map<IReadOnlyList<ProductModel>>(products.ToList().AsReadOnly());

            return Ok(new Pagination<ProductModel>(1, totalItems, totalItems, rdOnly));
        }

        [HttpGet("product/{id}")]
        public async Task<ActionResult<ProductModel>> GetProduct(int id)
        {
            return Ok(_mapper.Map<ProductModel>(await _menuService.GetAllMenuItems()));
        }

        //[HttpGet]
        //public async Task<ActionResult<MenuDTO>> GetAllMenu()
        //{
        //    return Ok(await _menuService.GetAllMenuItems());
        //}


        [HttpGet("types")]
        public async Task<ActionResult<TypeModel>> GetTypes()
        {
            return Ok(_mapper.Map<IEnumerable<TypeModel>>(await _itemTypeService.GetAllTypes()));
        }
    }
}
