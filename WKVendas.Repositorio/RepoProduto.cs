using Dapper;
using MySql.Data.MySqlClient;
using WKVendas.Dominio;

namespace WKVendas.Repositorio
{
    public class RepoProduto : RepoBase
    {
        public async Task<int> Inserir(Produto produto)
        {
            int linhasAfetadas = 0;

            try
            {
                using (var connection = new MySqlConnection(_strConection))
                {
                    string sqlQuery = "INSERT INTO `testewk`.`produto`"
                     + "(`guid`,`nome`,`descricao`,`foto`,`preco`,`data`,`idCategoria`)"
                     + "VALUES"
                     + "(@Guid,@Nome,@Descricao,@Foto,@Preco,@Data,@IdCategoria);";
                    linhasAfetadas = await connection.ExecuteAsync(sqlQuery, produto);

                }

                return linhasAfetadas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Produto>> Obter()
        {
            try
            {
                using (var connection = new MySqlConnection(_strConection))
                {
                    var lista = await connection.QueryAsync<Produto>("SELECT * FROM testewk.produto");
                    return lista.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<int> Atualizar(Produto produto)
        {
            int linhasAfetadas = 0;

            try
            {
                using (var connection = new MySqlConnection(_strConection))
                {
                    string sqlQuery = "UPDATE `testewk`.`produto`"
                                    + "SET"
                                    + $"`nome` = @Nome,"
                                    + $"`descricao` = @Descricao,"
                                    + $"`foto` = @Foto,"
                                    + $"`preco` = @Preco,"
                                    + $"`data` = @Data,"
                                    + $"`idCategoria` = @IdCategoria"
                                    + " WHERE `guid` = @Guid; ";
                    linhasAfetadas = await connection.ExecuteAsync(sqlQuery, produto);
                }

                return linhasAfetadas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Apagar(Produto produto)
        {
            int linhasAfetadas = 0;

            try
            {
                using (var connection = new MySqlConnection(_strConection))
                {
                    string sqlQuery = $"DELETE FROM `testewk`.`produto` WHERE guid='{produto.Guid}'; ";
                    linhasAfetadas = await connection.ExecuteAsync(sqlQuery, produto);
                }

                return linhasAfetadas;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}