using JewelrySalesSystem.Application.Category;
using JewelrySalesSystem.Application.Category.Create;
using JewelrySalesSystem.Application.Category.Delete;
using JewelrySalesSystem.Application.Category.FilterCategory;
using JewelrySalesSystem.Application.Category.GetAll;
using JewelrySalesSystem.Application.Category.GetByID;
using JewelrySalesSystem.Application.Category.GetByName;
using JewelrySalesSystem.Application.Category.GetByNameKeyword;
using JewelrySalesSystem.Application.Category.GetByPagination;
using JewelrySalesSystem.Application.Category.Update;
using JewelrySalesSystem.Application.Common.Pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;


namespace Jewelry_Sales_System.API.Controllers
{
    [Authorize]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("category/create")]
        [Authorize(Roles = "Admin")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateCategory(
            [FromBody] CreateCategoryCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            if (!result.Contains("thành công"))
            {
                return BadRequest(new JsonResponse<string>(result));
            }
            return Ok(new JsonResponse<string>(result));
        }

        [AllowAnonymous]
        [HttpGet("filter-category")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<CategoryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<CategoryDto>>>> GetByFilter([FromQuery] FilterCategoryQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("category/pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<CategoryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<CategoryDto>>>> GetPagination([FromQuery] GetCategoryByPaginationQuery query
            , CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("category/by-name-keyword")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<CategoryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<CategoryDto>>>> GetCategoriesByNameKeyword([FromQuery] GetCategoriesByNameKeywordQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("category/{id}")]
        [ProducesResponseType(typeof(JsonResponse<CategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<CategoryDto>>> GetByID(
            [FromRoute] int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetCategoryByIDQuery(id: id), cancellationToken);
            return result != null ? Ok(new JsonResponse<CategoryDto>(result)) : NotFound();
        }

        [HttpGet("category/by-name")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<CategoryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<CategoryDto>>>> GetCategoriesByName([FromQuery] GetCategoriesByNameQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }


        [HttpPut("category/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdateRole(UpdateCategoryCommand command
            , CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            if (!result.Contains("thành công"))
            {
                return BadRequest(new JsonResponse<string>(result));
            }
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("category/delete/{id}")]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteCategory([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id: id), cancellationToken);
            if (!result.Contains("thành công"))
            {
                return BadRequest(new JsonResponse<string>(result));
            }
            return Ok(new JsonResponse<string>(result));
        }

        [AllowAnonymous]
        [HttpGet("category")]
        [ProducesResponseType(typeof(JsonResponse<List<CategoryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<CategoryDto>>>> GetAllCategory(
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(new GetAllCategoryQuery(), cancellationToken);
            return result != null ? Ok(new JsonResponse<List<CategoryDto>>(result)) : NotFound();
        }
    }
}
