using AutoMapper;
using GenericImporter.Application.Core.DataTransferObjects;
using GenericImporter.Application.Core.Interfaces;
using GenericImporter.Domain.Core.Commands;
using GenericImporter.Domain.Core.Entities;
using GenericImporter.Domain.Core.Interfaces;
using GenericImporter.Domain.Core.Mediator;
using GenericImporter.Domain.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericImporter.Application.Core.Services
{
    public abstract class AppService<TDTO, TAddDTO, TEntity> : IAppService<TDTO, TAddDTO>
        where TDTO : IDataTransferObject
        where TAddDTO : IDataTransferObject
        where TEntity : Entity
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TEntity> _repository;

        protected AppService(IMapper mapper, 
                             IRepository<TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<TDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<TDTO>>(await _repository.GetAll());
        }

        public async Task<TDTO> GetById(Guid id)
        {
            return _mapper.Map<TDTO>(await _repository.GetById(id));
        }

        public abstract Task Add(TAddDTO addDTO);
    }
}
