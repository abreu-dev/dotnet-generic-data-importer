using GenericImporter.Application.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericImporter.Application.Core.Interfaces
{
    public interface IAppService<TDTO, TAddDTO>
        where TDTO : IDataTransferObject
        where TAddDTO : IDataTransferObject
    {
        Task<IEnumerable<TDTO>> GetAll();
        Task<TDTO> GetById(Guid id);

        Task Add(TAddDTO addDTO);
    }
}
