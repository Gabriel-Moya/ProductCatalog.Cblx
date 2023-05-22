using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Cblx.Application.AppService;
using ProductCatalog.Cblx.Application.Request;
using ProductCatalog.Cblx.Application.Response;

namespace ProductCatalog.Cblx.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        /// <summary>
        /// Dado uma página e a quantidade de itens desejado, retorna uma lista de produtos com a quantidade informada
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IList<ProductResponse>>> Get(int skip, int take)
        {
            var result = await _productAppService.GetAll(skip, take);
            return Ok(result);
        }

        /// <summary>
        /// Retorna o produto referente ao ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _productAppService.GetById(id);
            return Ok(result);
        }

        /// <summary>
        /// Cria um produto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest product)
        {
            var result = await _productAppService.Create(product);
            return Ok(result);
        }

        /// <summary>
        /// Atualizar um produto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost("{id:guid}")]
        public async Task<IActionResult> Update(UpdateProductRequest product)
        {
            var result = await _productAppService.Update(product);
            return Ok(result);
        }

        /// <summary>
        /// Exclui um produto de acordo com o ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productAppService.Delete(id);
            return StatusCode(204);
        }
    }
}
