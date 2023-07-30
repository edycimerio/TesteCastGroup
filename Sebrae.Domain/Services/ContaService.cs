using Sebrae.Domain.Dtos;
using Sebrae.Domain.Entities;
using Sebrae.Domain.Interfaces.Repository;
using Sebrae.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sebrae.Domain.Services
{
    public class ContaService: IContaService
    {
        private readonly IContaRepository _repository;

        public ContaService(IContaRepository repository)
        {
            _repository = repository;
        }

        public async Task<ContaDto> Consultar(int? id)
        {
            var _contas = await _repository.Consultar(id);
            ContaDto newConta = new ContaDto();

            if (_contas != null)
            {
                newConta.Id = _contas.Id;
                newConta.Descricao = _contas.Descricao;
                newConta.Nome = _contas.Nome;
            }

            return newConta;
        }
        public async Task<bool> Create(ContaDto contaDto)
        {
            Conta _conta = new Conta();

            if (contaDto != null)
            {
                _conta.Id = contaDto.Id;
                _conta.Descricao = contaDto.Descricao;
                _conta.Nome = contaDto.Nome;
                try
                {
                    await _repository.Create(_conta);

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
                
        public async Task<bool> Edit(ContaDto contaDto)
        {
            if (contaDto != null)
            {
                if (contaDto.Id > 0)
                {
                    Conta conta = new Conta();

                    conta.Id = contaDto.Id;
                    conta.Descricao = contaDto.Descricao;
                    conta.Nome = contaDto.Nome;

                    try
                    {
                        await _repository.Edit(conta);

                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                return false;
            }

            return false;
        }
               
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<IList<ContaDto>> ListContas()
        {
            var lista = await _repository.ListContas();

            IList<ContaDto> listaRetorno = new List<ContaDto>();

            foreach (Conta _conta in lista)
            {
                ContaDto newConta = new ContaDto();
                newConta.Id = _conta.Id;
                newConta.Descricao = _conta.Descricao;
                newConta.Nome = _conta.Nome;

                listaRetorno.Add(newConta);
            }

            return listaRetorno;
        }

        
    }
}
