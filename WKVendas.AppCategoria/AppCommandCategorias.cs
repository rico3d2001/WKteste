using WKVendas.App;
using WKVendas.Dominio;
using WKVendas.Repositorio;

namespace WKVendas.AppCategoria
{
    public class AppCommandCategorias
    {
        private readonly RepoCategoria _repoCategoria;
        public AppCommandCategorias()
        {
            _repoCategoria = new RepoCategoria();
        }

        public async Task<ResultadoQuery> Inserir(Categoria categoria)
        {
            try
            {
                var linhasAfetadas = await _repoCategoria.Inserir(categoria);

                if (linhasAfetadas > 0){
                    return new ResultadoQuery(linhasAfetadas, new List<string>(), 200);
                }

                var erros = new List<string>() { "Categoria não inserida no banco" };
                return new ResultadoQuery(0, erros, 200);
                
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

        public async Task<ResultadoQuery> Atualizar(string nome, Categoria categoria)
        {
            try
            {
                var linhasAfetadas = await _repoCategoria.Atualizar(nome, categoria);

                if (linhasAfetadas > 0)
                {
                    return new ResultadoQuery(linhasAfetadas, new List<string>(), 200);
                }

                var erros = new List<string>() { "Categoria não apagada do banco" };
                return new ResultadoQuery(0, erros, 200);

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
        public async Task<ResultadoQuery> Apagar(Categoria categoria)
        {
            try
            {
                var linhasAfetadas = await _repoCategoria.Apagar(categoria);

                if (linhasAfetadas > 0)
                {
                    return new ResultadoQuery(linhasAfetadas, new List<string>(), 200);
                }

                var erros = new List<string>() { "Categoria não apagada do banco" };
                return new ResultadoQuery(0, erros, 200);

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
