using AutoMapper;
using WKVendas.App;
using WKVendas.Dominio;

namespace WKVendas.WebApiProduto.Model
{
    public class CfgMapeamento
    {
        IMapper _mapper;
        public CfgMapeamento()
        {
          var cfg =  Mapear();
          _mapper = cfg.CreateMapper();
        }

        public IMapper Mapper { get => _mapper; }

        private MapperConfiguration Mapear()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Produto, ProdutoModel>();
                cfg.CreateMap<ProdutoModel, Produto>();
            });
        }
    }
}
