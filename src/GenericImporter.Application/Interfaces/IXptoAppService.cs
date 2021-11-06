using GenericImporter.Application.Core.Interfaces;
using GenericImporter.Application.DataTransferObjects.XptoDtos;

namespace GenericImporter.Application.Interfaces
{
    public interface IXptoAppService : IAppService<XptoDto, AddXptoDto> { }
}
