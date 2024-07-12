using JewelrySalesSystem.Application.Common.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using JewelrySalesSystem.Application.Product;
using JewelrySalesSystem.Application.Product.GetProduct;
using JewelrySalesSystem.Application.Product.Create;
using JewelrySalesSystem.Application.Product.Update;
using JewelrySalesSystem.Application.Product.Delete;
using JewelrySalesSystem.Application.Product.GetByID;
using AuthorizeAttribute = JewelrySalesSystem.Application.Common.Security.AuthorizeAttribute;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Application.Product.FliterProduct;


namespace Jewelry_Sales_System.API.Controllers
{
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("[controller]")]
        [ProducesResponseType(typeof(JsonResponse<List<ProductDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ProductDto>>> GetAllPrducts(
           CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductQuery(), cancellationToken);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        [ProducesResponseType(typeof(JsonResponse<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductDto>> GetProductByID(
            [FromRoute]string id,
           CancellationToken cancellationToken)
        { 
            var result = await _mediator.Send(new GetProductByIDQuery(iD : id), cancellationToken);
            return result != null ? Ok(result) : NotFound();
        }
        [HttpGet]
        [Route("[controller]/filter-user")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ProductDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ProductDto>>>> GetByFilter([FromQuery] FilterProductQuery query
            , CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }


        [HttpPost]
        [Route("[controller]/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateNewProduct(
            [FromBody] CreateProductCommand command,
           CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
       
        [HttpPut]
        [Route("[controller]/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdateProduct(
           [FromBody] UpdateProductCommand command,
           CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            if (result.Contains("thất bại"))
            {
                return BadRequest(new JsonResponse<string>(result));
            }
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete]
        [Route("[controller]/delete/{id}")]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteProduct(
            string id,
           CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteProductCommand(iD : id), cancellationToken);
            if (result.Contains("thất bại"))
            {
                return BadRequest(new JsonResponse<string>(result));
            }
            return Ok(new JsonResponse<string>(result));
        }

    }
}
