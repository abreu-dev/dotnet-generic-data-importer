using Core.Application.Interfaces;
using GenericImporter.Application.DataTransferObjects.XptoDtos;

namespace GenericImporter.Application.Interfaces
{
    public interface IXptoAppService : IAppService<XptoDto, AddXptoDto> { }
}
