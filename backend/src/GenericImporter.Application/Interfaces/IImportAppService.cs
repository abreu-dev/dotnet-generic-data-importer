using GenericImporter.Application.Core.Interfaces;
using GenericImporter.Application.DataTransferObjects.ImportDTOs;

namespace GenericImporter.Application.Interfaces
{
    public interface IImportAppService : IAppService<ImportDto, AddImportDto> { }
}
