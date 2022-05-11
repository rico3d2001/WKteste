using WKVendas.App;
using WKVendas.Dominio;
using WKVendas.Repositorio;

namespace WKVendas.AppCategoria
{
    public class AppQueryCategoria
    {
        private readonly RepoCategoria _repoCategoria;
        public AppQueryCategoria()
        {
            _repoCategoria = new RepoCategoria();
        }

        public async Task<ResultadoQuery> Obter()
        {
            try
            {
                var resultado = await _repoCategoria.Obter();
                return new ResultadoQuery(resultado, new List<string>(), 200);
            }
            catch (Exception e)
            {
                var listaErros = new List<string>()
                {
                    e.Message
                };
                return new ResultadoQuery(new List<Categoria>(), listaErros, 500);
            }
        }
    }
}