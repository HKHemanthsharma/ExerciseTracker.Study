using ExerciseTracker.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExerciseTracker.UI.Repositories
{
    public class Repository<T> where T : class
    {
        public string BaseURL { get; set; }
        HttpClientService ClientService = new();
        HttpClient Client;
        public Repository()
        {
            BaseURL = ClientService.GetBaseURL() + typeof(T).Name;
            Client = ClientService.GetHttpClient();
        }
        public async Task<ResponseDto<T>> GetAllEntities()
        {
            var response=await Client.GetStreamAsync(BaseURL);
            ResponseDto<T> GetResponse = JsonSerializer.Deserialize<ResponseDto<T>>(response);
            return GetResponse;
        }
        public async Task<ResponseDto<T>> GetEntiryById(int Id)
        {
            var response = await Client.GetStreamAsync(BaseURL+$"/{Id}");
            ResponseDto<T> GetResponse = JsonSerializer.Deserialize<ResponseDto<T>>(response);
            return GetResponse;
        }
        public async Task<ResponseDto<T>> CreateEntity(T Entity)
        {
            var response = await Client.PostAsJsonAsync(BaseURL, Entity);
            var StreamResponse = await response.Content.ReadAsStreamAsync();
            ResponseDto<T> Response = JsonSerializer.Deserialize<ResponseDto<T>>(StreamResponse);
            return Response;
        }
        public async Task<ResponseDto<T>> UpdateEntity(T Entity, int Id)
        {
            var response = await Client.PutAsJsonAsync(BaseURL+$"/{Id}", Entity);
            var StreamResponse = await response.Content.ReadAsStreamAsync();
            ResponseDto<T> Response = JsonSerializer.Deserialize<ResponseDto<T>>(StreamResponse);
            return Response;
        }
        public async Task<ResponseDto<T>> DeleteEntity(T Entity, int Id)
        {
            var response = await Client.DeleteAsync(BaseURL + $"/{Id}");
            var StreamResponse = await response.Content.ReadAsStreamAsync();
            ResponseDto<T> Response = JsonSerializer.Deserialize<ResponseDto<T>>(StreamResponse);
            return Response;
        }

    }
}
