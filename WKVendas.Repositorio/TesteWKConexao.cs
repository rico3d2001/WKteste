using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WKVendas.Dominio;

namespace WKVendas.Repositorio
{
    public class TesteWKConexao : IDisposable
    {
        private readonly IDbConnection _conexao;

        public TesteWKConexao()
        {
            _conexao = new MySqlConnection("Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;");
        }

        public void Dispose() => _conexao.Dispose();

    }
}
