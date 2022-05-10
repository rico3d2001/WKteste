using Dapper;
using MySql.Data.MySqlClient;
using WKVendas.Dominio;

namespace WKVendas.Repositorio
{
    public class RepoCategoria
    {
        private readonly string _strConection;
        public RepoCategoria()
        {
            _strConection = "Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;";
        }

        public async Task<List<Categoria>> Get()
        {
            try
            {
                var categorias = new List<Categoria>();

                using (var connection = new MySqlConnection(_strConection))
                {
                    categorias = (List<Categoria>)await connection.QueryAsync<List<Categoria>>("SELECT * FROM categoria");
                }

                return categorias;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<Categoria> Post(Categoria categoria)
        {
            try
            {
                using (var connection = new MySqlConnection(_strConection))
                {
                    string sqlQuery = "INSERT INTO `testewk`.`categoria` (`nome`,`descricao`,`foto`)"
                        + $"VALUES (@Nome,@Descricao,@Foto); ";
                    connection.Execute(sqlQuery, categoria);
                }

                return categoria;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Categoria> Get(string id)
        {
            Categoria categoria = null;

            using (var connection = new MySqlConnection(_strConection))
            {
                categoria = (Categoria)await connection.QueryAsync<List<Categoria>>($"SELECT * FROM categoria WHERE categoria.id={id}");
            }

            return categoria;
        }
    }
}
