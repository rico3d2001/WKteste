using AutoMapper;
using WKVendas.App;
using WKVendas.AppProduto;
using WKVendas.Dominio;

namespace WKVendas.WebApiProduto.Model
{
    public class ConsumoMS
    {
        IMapper _mapper;
        public ConsumoMS()
        {
            _mapper = new CfgMapeamento().Mapper;
        }

        public async Task<ResultQueryModel> GetAll()
        {
            var appLeituraProduto = new AppQueryProduto();
            var resultado = await appLeituraProduto.Obter();
            var lista = (List<Produto>)resultado.Dados;
            var listaModel =_mapper.Map<List<ProdutoModel>>(lista);
            return new ResultQueryModel(listaModel, resultado.Erros,resultado.Tipo);
        }


    }
}
