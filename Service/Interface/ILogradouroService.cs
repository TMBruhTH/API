using DataModel.Model;

namespace Service.Interface
{
    public interface ILogradouroService
    {
        Task adicionar(Logradouro model);
        Task atualizar(Logradouro model);
        Task<List<Logradouro>> visualizar(int? id);
        Task remover(int id);
    }
}
