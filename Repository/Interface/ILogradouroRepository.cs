using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ILogradouroRepository
    {
        Task adicionar(Logradouro model);
        Task atualizar(Logradouro model);
        Task<List<Logradouro>> visualizar(int? id);
        Task remover(int id);
    }
}
