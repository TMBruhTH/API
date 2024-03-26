using Dapper;
using DataModel.Model;
using Repository.Interface;
using System.Data;
using System.Data.SqlClient;

namespace Repository.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        #region [conexao string]
        const string conn = @"Data Source=BRUNO-PC\SQLEXPRESS;Initial Catalog=DBThomasGreg;Integrated Security=True;Encrypt=False;";
        #endregion

        #region [adicionar]
        public async Task adicionar(Cliente model)
        {
            using (IDbConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                var values = new
                {
                    Nome = model.Nome,
                    Email = model.Email,
                    Logotipo = model.Logotipo
                };

                await connection.ExecuteScalarAsync("inserir_cliente", values, commandType: CommandType.StoredProcedure);

                connection.Close();
            }
        }
        #endregion

        #region [atualizar]
        public async Task atualizar(Cliente model)
        {
            using (IDbConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                var id = new { id = model.Id };

                var result = await connection.QueryFirstAsync<Cliente>("visualizar_cliente", id, commandType: CommandType.StoredProcedure);

                if (result != null)
                {
                    result = new Cliente { Id = model.Id, Email = model.Email, Nome = model.Nome, Logotipo = model.Logotipo };
                    
                    await connection.ExecuteScalarAsync("atualizar_cliente", result, commandType: CommandType.StoredProcedure);
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

                await connection.ExecuteScalarAsync("remover_cliente", idRemover, commandType: CommandType.StoredProcedure);

                connection.Close();
            }
        }
        #endregion

        #region [visualizar]
        public async Task<List<Cliente>> visualizar(int? id)
        {
            var lista = new List<Cliente>();
            using (IDbConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                var values = new
                {
                    Id = id
                };

                var result = connection.QueryAsync<Cliente>("visualizar_cliente", values, commandType: CommandType.StoredProcedure).Result.ToList();

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
