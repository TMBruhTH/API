using DataModel.Model;

namespace Service.Interface
{
    public interface IClienteService
    {
        Task adicionar(Cliente model);
        Task atualizar(Cliente model);
        Task<List<Cliente>> visualizar(int? id);
        Task remover(int id);
    }
}
