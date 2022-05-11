using Dapper;
using MySql.Data.MySqlClient;
using WKVendas.Dominio;

namespace WKVendas.Repositorio
{
    public class RepoCategoria : RepoBase
    {
       
        public async Task<int> Inserir(Categoria categoria)
        {
            int linhasAfetadas = 0;

            try
            {
                using (var connection = new MySqlConnection(_strConection))
                {
                    string sqlQuery = "INSERT INTO `testewk`.`categoria` (`nome`,`descricao`,`foto`)"
                        + $"VALUES (@Nome,@Descricao,@Foto); ";
                   linhasAfetadas =  await connection.ExecuteAsync(sqlQuery, categoria);

                }

                return linhasAfetadas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Categoria>> Obter()
        {
            try
            {
                using (var connection = new MySqlConnection(_strConection))
                {
                   var lista = await connection.QueryAsync<Categoria>("SELECT * FROM testewk.categoria");  
                    return lista.ToList(); 
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<int> Apagar(Categoria categoria)
        {

            var categoriaToDel = Obter(categoria.Nome);
            int linhasAfetadas = 0;

            try
            {
                using (var connection = new MySqlConnection(_strConection))
                {
                    string sqlQuery = $"DELETE FROM `testewk`.`categoria` WHERE nome='{categoria.Nome}'; ";
                    linhasAfetadas = await connection.ExecuteAsync(sqlQuery, categoriaToDel);
                }

                return linhasAfetadas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Atualizar(string nome, Categoria categoria)
        {
            var categoriaToUpdate = Obter(nome);
            int linhasAfetadas = 0;

            try
            {
                using (var connection = new MySqlConnection(_strConection))
                {
                    string sqlQuery = $"UPDATE `testewk`.`categoria`"
                                    + "SET"
                                    + $"`nome` = '{ categoria.Nome }',"
                                    + $"`descricao` = '{ categoria.Descricao }',"
                                    + $"`foto` = '{ categoria.Foto }'"
                                    + $"WHERE `nome` = '{ nome }'; ";
                    linhasAfetadas = await connection.ExecuteAsync(sqlQuery, categoriaToUpdate);
                }

                return linhasAfetadas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Categoria? Obter(string? nome)
        {
            try
            {
                using (var connection = new MySqlConnection(_strConection))
                {
                    var lista = connection
                        .Query<Categoria>($"SELECT * FROM testewk.categoria WHERE nome='{nome}'");
                    return lista.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
