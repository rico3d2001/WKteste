using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WKVendas.Dominio
{
    public class Produto
    {
        public Produto(string guid, string nome, int idCategoria)
        {
            Guid = guid;
            Nome = nome;
            IdCategoria = idCategoria;
        }

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
