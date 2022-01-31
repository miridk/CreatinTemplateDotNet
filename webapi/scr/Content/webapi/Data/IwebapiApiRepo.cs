using System.Collections.Generic;
using webapiApiService.Models;

namespace webapiApiService.Data
{
    public interface IwebapiApiRepo
    {
        bool SaveChanges();

        IEnumerable<webapiApi> GetAllwebapiApis();
        webapiApi GetwebapiApiById(int Id);
        void CreatewebapiApi(webapiApi plat);
    }
}