using DataModel.Model;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class LogradouroService : ILogradouroService
    {
        private readonly ILogradouroRepository _repository;
        public LogradouroService(ILogradouroRepository repository)
        {
            _repository = repository;
        }
        public async Task adicionar(Logradouro model)
        {
            await _repository.adicionar(model);
        }

        public async Task atualizar(Logradouro model)
        {
            await _repository.atualizar(model);
        }

        public async Task remover(int id)
        {
            await _repository.remover(id);
        }

        public async Task<List<Logradouro>> visualizar(int? id)
        {
            return await _repository.visualizar(id);
        }
    }
}
