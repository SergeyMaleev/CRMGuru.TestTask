using CRMGuru.TestTask.Interfaces.Entities;
using CRMGuru.TestTask.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CRMGuru.TestTask.WebApiClient
{
    public class WebRepository : IWebRepository
    {
        private readonly HttpClient _httpClient;

        public WebRepository(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<T> Get<T>(string name, CancellationToken cancel = default) where T: class, IEntity
        {

            var res = await _httpClient.GetAsync(name, cancel).ConfigureAwait(false);
            
            if (res.IsSuccessStatusCode)
            {
                return await _httpClient.GetFromJsonAsync<T>(name, cancel).ConfigureAwait(false);
            }
            else
            {                     
                throw new Exception(await res.Content.ReadAsStringAsync());
            }          
        }

        public async Task<IEnumerable<T>> GetArray<T>(string name, CancellationToken cancel = default) where T : class
        {
            var res = await _httpClient.GetAsync(name, cancel).ConfigureAwait(false);
            
            if (res.IsSuccessStatusCode)
            {
                return await _httpClient.GetFromJsonAsync<T[]>(name, cancel).ConfigureAwait(false);
            }
            else
            {                              
                throw new Exception(await res.Content.ReadAsStringAsync());
            }         
        }
    }
}
