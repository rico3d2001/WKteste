using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WKVendas.Dominio
{
    public class Categoria : BaseEntity
    {
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Foto { get; set; }
    }
}
