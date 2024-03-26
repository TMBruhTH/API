using Dapper;
using DataModel.Model;
using Repository.Interface;
using System.Data;
using System.Data.SqlClient;

namespace Repository.Repository
{
    public class LogradouroRepository : ILogradouroRepository
    {
        #region [conexao string]
        const string conn = @"Data Source=BRUNO-PC\SQLEXPRESS;Initial Catalog=DBThomasGreg;Integrated Security=True;Encrypt=False;";
        #endregion

        #region [adicionar]
        public async Task adicionar(Logradouro model)
        {
            using (IDbConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                var values = new
                {
                    Nome = model.DescLogradouro,
                };

                await connection.ExecuteScalarAsync("inserir_logradouro", values, commandType: CommandType.StoredProcedure);

                connection.Close();
            }
        }
        #endregion

        #region [atualizar]
        public async Task atualizar(Logradouro model)
        {
            using (IDbConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                var id = new { id = model.Id };

                var result = await connection.QueryFirstAsync<Logradouro>("visualizar_logradouro", id, commandType: CommandType.StoredProcedure);

                if (result != null)
                {
                    result = new Logradouro { Id = model.Id, DescLogradouro = model.DescLogradouro };

                    await connection.ExecuteScalarAsync("atualizar_logradouro", result, commandType: CommandType.StoredProcedure);
                }

                connection.Close();
            }
        }
        #endregion

        #region [remover]
        public async Task remover(int id)
        {
            using (IDbConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                var idRemover = new { id = id };

                await connection.ExecuteScalarAsync("remover_logradouro", idRemover, commandType: CommandType.StoredProcedure);

                connection.Close();
            }
        }
        #endregion

        #region [visualizar]
        public async Task<List<Logradouro>> visualizar(int? id)
        {
            var lista = new List<Logradouro>();
            using (IDbConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                var values = new
                {
                    Id = id
                };

                var result = connection.QueryAsync<Logradouro>("visualizar_logradouro", values, commandType: CommandType.StoredProcedure).Result.ToList();

                result.ForEach(x =>
                {
                    lista.Add(x);
                });

                connection.Close();
            }

            return await Task.FromResult(lista);
        }
        #endregion

    }
}
