using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WKVendas.App;
using WKVendas.Dominio;
using WKVendas.Repositorio;

namespace WKVendas.AppProduto
{
    public class AppCommandProduto
    {

        private readonly RepoProduto _repoProduto;
        public AppCommandProduto()
        {
            _repoProduto = new RepoProduto();
        }

        public async Task<ResultadoQuery> Inserir(Produto produto)
        {
            try
            {
                var linhasAfetadas = await _repoProduto.Inserir(produto);

                if (linhasAfetadas > 0)
                {
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
                return new ResultadoQuery(new List<Produto>(), listaErros, 500);
            }
        }
        public async Task<ResultadoQuery> Atualizar(Produto produto)
        {
            try
            {
                var linhasAfetadas = await _repoProduto.Atualizar(produto);

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
                return new ResultadoQuery(new List<Produto>(), listaErros, 500);
            }
        }

        
        public async Task<ResultadoQuery> Apagar(Produto produto)
        {
            try
            {
                var linhasAfetadas = await _repoProduto.Apagar(produto);

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
