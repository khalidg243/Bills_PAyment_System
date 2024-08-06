using System.Linq.Expressions;
using System.Net.Http.Json;
using BPS_Shared.Services;
using Serialize.Linq.Serializers;

namespace BPS_Client.Services
{
    public class GenericService<TModel> : IGenericService<TModel> where TModel : class, new()
    {
        public HttpClient Client { get; set; } = new HttpClient();
        public GenericService()
        {
            Client.BaseAddress = new Uri("https://localhost:7182");
        }
        public async Task<TModel> CreateAsync(TModel model)
        {
            var response = await Client.PostAsJsonAsync<TModel>($"/{typeof(TModel).Name}/{nameof(CreateAsync)}", model);

            if(response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadFromJsonAsync<TModel>();

                return responseData;
            }

            var response2 = await response.Content.ReadAsStringAsync();
            return null;
        }

        public async Task<bool> DeleteAsync(TModel model)
        {
            var response = await Client.PostAsJsonAsync<TModel>($"/{typeof(TModel).Name}/{nameof(DeleteAsync)}", model);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadFromJsonAsync<TModel>();

                return true;
            }

            return false;
        }

        public async Task<List<TModel>> ReadAsync()
        {
            var response = await Client.PostAsJsonAsync<TModel>($"/{typeof(TModel).Name}/{nameof(ReadAsync)}", null);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadFromJsonAsync<List<TModel>>();

                return responseData;
            }

            return null;
        }

        public async Task<TModel> UpdateAsync(TModel model)
        {
            var response = await Client.PostAsJsonAsync<TModel>($"/{typeof(TModel).Name}/{nameof(UpdateAsync)}", model);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadFromJsonAsync<TModel>();

                return responseData;
            }

            return null;
        }

        public async Task<bool> Test()
        {
            var response = await Client.PostAsJsonAsync<TModel>($"/{typeof(TModel).Name}/{nameof(Test)}",null);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadFromJsonAsync<bool>();

                return responseData;
            }

            return false;
        }

        public async Task<List<TModel>> GetWhere(Expression<Func<TModel, bool>> lambda)
        {
            var serializer = new ExpressionSerializer(new Serialize.Linq.Serializers.JsonSerializer());
            string serializedExpression = serializer.SerializeText(lambda);
            var response = await Client.PostAsJsonAsync<string>($"/{typeof(TModel).Name}/{nameof(GetWhere)}", serializedExpression);
            if (response.IsSuccessStatusCode == true)
            {
                var responseData = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return responseData;
            }
            return null;
        }
    }
}
