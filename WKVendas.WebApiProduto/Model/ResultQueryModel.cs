namespace WKVendas.WebApiProduto.Model
{
    public class ResultQueryModel
    {
        public ResultQueryModel(List<ProdutoModel> dados, List<string> erros, int tipo)
        {
            Dados = dados;
            Erros = erros;
            Tipo = tipo;
        }

        public List<ProdutoModel> Dados { get; private set; }
        public List<string> Erros { get; private set; }
        public int Tipo { get; private set; }
    }
}
