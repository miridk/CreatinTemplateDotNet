using System.Threading.Tasks;
using webapiApiService.Dtos;

namespace webapiApiService.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendwebapiApiToCommand(webapiApiReadDto plat);
    }
}