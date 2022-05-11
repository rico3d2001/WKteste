using WKVendas.App;
using WKVendas.Dominio;
using WKVendas.Repositorio;

namespace WKVendas.AppProduto
{
    public class AppQueryProduto
    {
        private readonly RepoProduto _repoProduto;
        public AppQueryProduto()
        {
            _repoProduto = new RepoProduto();
        }
        public async Task<ResultadoQuery> Obter()
        {
            try
            {
                var resultado = await _repoProduto.Obter();
                return new ResultadoQuery(resultado, new List<string>(), 200);
            }
            catch (Exception e)
            {
                var listaErros = new List<string>()
                {
                    e.Message
                };
                return new ResultadoQuery(new List<Produto>(), listaErros, 500);
            }
        }
    }
}