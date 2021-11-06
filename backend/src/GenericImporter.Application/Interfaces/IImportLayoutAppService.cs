using GenericImporter.Application.Core.Interfaces;
using GenericImporter.Application.DataTransferObjects.ImportLayoutDTOs;

namespace GenericImporter.Application.Interfaces
{
    public interface IImportLayoutAppService : IAppService<ImportLayoutDto, AddImportLayoutDto> { }
}

