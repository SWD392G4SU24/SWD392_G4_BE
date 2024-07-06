using JewelrySalesSystem.Application.Category.Create;
using JewelrySalesSystem.Application.Category.Delete;
using JewelrySalesSystem.Application.Category.GetByID;
using JewelrySalesSystem.Application.Category.GetCategory;
using JewelrySalesSystem.Application.Category.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JewelrySalesSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID trong đường dẫn không khớp với ID trong thân");
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("get_by/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCategoryByIDQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("Get All")]
        public async Task<IActionResult> Get()
        {
            var query = new GetCategoryQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
