using WKVendas.Dominio;
using WKVendas.Repositorio;

namespace WKVendas.App
{
    public class AppLeituraCategoria
    {
        private readonly RepoCategoria _repoCategoria;
        public AppLeituraCategoria()
        {
            _repoCategoria = new RepoCategoria();
        }

        public async Task<ResultadoQuery> GetCategorias()
        {
            try
            {
                var resultado = await _repoCategoria.Get();
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