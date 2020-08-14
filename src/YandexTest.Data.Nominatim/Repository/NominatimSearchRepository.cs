using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YandexTest.Core.RestBase.Repository;
using YandexTest.Data.Nominatim.Model;

namespace YandexTest.Data.Nominatim.Repository
{
    public class NominatimSearchRepository : RestRepositoryBase
    {
        public async Task<List<NominatimSearchResponseItem>> GetPoints(NominatimSearchRequest request)
        {
            var route = $"/search.php?q={request.SearchText}&format=json";

            var result = await Get<List<NominatimSearchResponseItem>>("https://nominatim.openstreetmap.org", route, new Dictionary<string, string> { { "User-Agent", "PostmanRuntime/7.22.0" } });
          
            return result;
        }
    }
}
