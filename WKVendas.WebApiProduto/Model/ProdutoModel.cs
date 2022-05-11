namespace WKVendas.WebApiProduto.Model
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Nome { get; set; }
        public int IdCategoria { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public decimal Preco { get; set; }
        public DateTime Data { get; set; }
    }
}
