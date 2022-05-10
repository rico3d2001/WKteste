using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WKVendas.Dominio;
using WKVendas.Repositorio;

namespace WKVendas.App
{
    public class AppMudancaCategorias
    {
        private readonly RepoCategoria _repoCategoria;
        public AppMudancaCategorias()
        {
            _repoCategoria = new RepoCategoria();
        }

        public async Task<ResultadoQuery> PostCategoria(Categoria categoria)
        {
            try
            {
                var resultado = await _repoCategoria.Post(categoria);
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
