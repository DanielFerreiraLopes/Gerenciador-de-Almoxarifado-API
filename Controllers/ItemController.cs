using Almoxarifado.DTO;
using Almoxarifado.Entities;
using Almoxarifado.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Almoxarifado.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController: ControllerBase
    {

        private readonly IItemService _service;
        public ItemController(IItemService service)
        {
            _service = service;
        }

        [HttpGet("GetItem/{name}")]
        public IActionResult Get(string name)
        {
            Item item = _service.GetItem(name);

            if (item == null)
            {
                return NotFound("Item não Encontrado");
            }

            return Ok(item);
        }

        [HttpGet("GetAllItems")]
        public IActionResult GetAll() {

            List<Item> item = _service.GetAllItems();

            if (item == null)
            {
                return NotFound("Nenhum Item Encontrado");
            }

            return Ok(item);
        }

        [HttpPost("CreateItem")]
        public IActionResult Add(ItemDTO itemDTO)
        {
            try
            {
                _service.CreateItem(itemDTO);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AddItem")]
        public IActionResult Update(AddItemDTO addItemDTO)
        {
            try
            {
                _service.AddItem(addItemDTO);
                return Ok("Item Atualizado com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveItem")]
        public IActionResult Remove(RemoveItemDTO removeItemDTO)
        {
            try
            {
                _service.RemoveItem(removeItemDTO);
                return Ok("Item Removido com Sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
