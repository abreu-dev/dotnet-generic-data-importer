using GenericImporter.Application.Core.Interfaces;
using GenericImporter.Application.DataTransferObjects.XptoDTOs;

namespace GenericImporter.Application.Interfaces
{
    public interface IXptoAppService : IAppService<XptoDTO, AddXptoDTO> { }
}
