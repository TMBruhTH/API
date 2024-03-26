using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IClienteRepository
    {
        Task adicionar(Cliente model);
        Task atualizar(Cliente model);
        Task<List<Cliente>> visualizar(int? id);
        Task remover(int id);
    }
}
