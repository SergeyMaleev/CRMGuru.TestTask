using CRMGuru.TestTask.Interfaces.Entities;
using CRMGuru.TestTask.Interfaces.Repositories;
using CRMGuru.TestTask.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRMGuru.TestTask.WebApiClient
{
    public class WebRepository : IWebRepository
    {
        private readonly HttpClient _httpClient;

        public WebRepository(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<T> Get<T>(string name, CancellationToken cancel = default) where T: class
        {
            return await _httpClient.GetFromJsonAsync<T>(name, cancel).ConfigureAwait(false);
        }

        public async Task<T[]> GetArray<T>(string name, CancellationToken cancel = default) where T : class
        {
            return await _httpClient.GetFromJsonAsync<T[]>(name, cancel).ConfigureAwait(false);
        }
    }
}
