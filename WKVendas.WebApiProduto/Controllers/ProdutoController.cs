using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WKVendas.App;
using WKVendas.AppProduto;
using WKVendas.WebApiProduto.Model;

namespace WKVendas.WebApiProduto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {

        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(ILogger<ProdutoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllProdutos")]
        public async Task<ResultQueryModel> Get()
        {
            var consumoMS = new ConsumoMS();
            var result = await consumoMS.GetAll();
            return result;
        }

    }
}
