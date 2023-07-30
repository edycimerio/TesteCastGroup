using Sebrae.Domain.Dtos;
using Sebrae.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sebrae.Domain.Interfaces.Service
{
    public interface IContaService
    {
        Task<ContaDto> Consultar(int? id);
        Task<bool> Create(ContaDto contaDto);
        Task<bool> Edit(ContaDto contaDto);
        Task Delete(int id);
        Task<IList<ContaDto>> ListContas();
    }
}
