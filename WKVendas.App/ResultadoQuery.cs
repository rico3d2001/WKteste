using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WKVendas.App
{
    public class ResultadoQuery
    {
        public ResultadoQuery(object dados, List<string> erros, int tipo)
        {
            Dados = dados;
            Erros = erros;
            Tipo = tipo;
        }

        public object Dados { get; private set; }
        public List<string> Erros { get; private set; }
        public int  Tipo { get; private set; }


    }
}
