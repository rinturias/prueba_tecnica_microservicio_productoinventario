using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Application.Dto;
using System.Product.Application.UseCases.Command.Product;
using System.Product.Application.UseCases.Queries.Product.searchProduct;
using System.Threading.Tasks;

namespace System.Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreatedCommand command)
        {
            try
            {

                return Ok(await _mediator.Send(command));

            }
            catch (Exception ex)
            {

                return BadRequest(new ResulService() { success = false, codError = "501", messaje = "Error al crear el producto", error = ex.Message });
            }
        }

     

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductModifiedCommand command)
        {
            try
            {

                return Ok(await _mediator.Send(command));

            }
            catch (Exception ex)
            {

                return BadRequest(new ResulService() { success = false, codError = "501", messaje = "Error al modificar el producto", error = ex.Message });
            }
        }

        [HttpPut("DesactiveProduct")]
        public async Task<IActionResult> DesactiveProduct([FromBody] ProducDesactiveCommand command)
        {
            try
            {

                return Ok(await _mediator.Send(command));

            }
            catch (Exception ex)
            {

                return BadRequest(new ResulService() { success = false, codError = "501", messaje = "Error al eliminar el producto", error = ex.Message });
            }
        }
        [HttpPut("activateProduct")]
        public async Task<IActionResult> activateProduct([FromBody] ProductActiveCommand command)
        {
            try
            {

                return Ok(await _mediator.Send(command));

            }
            catch (Exception ex)
            {

                return BadRequest(new ResulService() { success = false, codError = "501", messaje = "Error al crear el producto", error = ex.Message });
            }
        }

        [HttpGet("ListProductByIdOrAll")]
        public async Task<IActionResult> ListProductByIdOrAll([FromQuery] Guid command)
        {
            try
            {
                if (command.ToString()=="")
                {
                    return Ok(await _mediator.Send(new ListAllProductsQuery()));
                }
                else
                {
                    return Ok(await _mediator.Send(new ListAllProductsQuery(command)));
                }
                
            }
            catch (Exception ex)
            {

                return BadRequest(new ResulService() { success = false, codError = "501", messaje = "Error en la solicitud", error = ex.Message });
            }
        }
    }
}
