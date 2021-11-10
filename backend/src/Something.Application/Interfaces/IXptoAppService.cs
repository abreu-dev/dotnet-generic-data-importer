using Core.Application.Interfaces;
using Something.Application.DataTransferObjects.XptoDtos;
using System.Threading.Tasks;

namespace Something.Application.Interfaces
{
    public interface IXptoAppService : IAppService<XptoDto, AddXptoDto> 
    {
        Task Import(string file);
    }
}
