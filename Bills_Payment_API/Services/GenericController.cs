using BPS_API.Database;
using BPS_Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serialize.Linq.Serializers;
using System.Linq.Expressions;
using BPS_Shared.Services;
using BCrypt.Net;

namespace Bills_Payment_API.Services
{

    public class GenericController<TModel> : ControllerBase, IGenericService<TModel> where TModel : class, new()
    {
        [Inject]
        protected BPS_dbcontext Database { get; set; }

        public GenericController(IServiceProvider provider)
        {
            Database = provider.GetRequiredService<BPS_dbcontext>();
        }

        [HttpPost(nameof(CreateAsync))]
        public async Task<TModel> CreateAsync(TModel model)
        {
            Database.Set<TModel>().Add(model);
            await Database.SaveChangesAsync();

            return model;
        }

        [HttpPost(nameof(UpdateAsync))]
        public async Task<TModel> UpdateAsync(TModel model)
        {
            Database.Set<TModel>().Update(model);
            await Database.SaveChangesAsync();

            return model;
        }

        [HttpPost(nameof(DeleteAsync))]
        public async Task<bool> DeleteAsync(TModel model)
        {
            Database.Set<TModel>().Remove(model);
            await Database.SaveChangesAsync();

            return true;
        }


        [HttpPost(nameof(ReadAsync))]
        public async Task<List<TModel>> ReadAsync()
        {

            await Database.SaveChangesAsync();
            return await Database.Set<TModel>().ToListAsync();

        }


        [HttpPost(nameof(GetWhere))]
        public async Task<List<TModel>> GetWhere([FromBody] string serialData)
        {
            var serializer = new ExpressionSerializer(new JsonSerializer());
            var lambda = (Expression<Func<TModel, bool>>)serializer.DeserializeText(serialData);
            return await Database.Set<TModel>().Where(lambda).ToListAsync();
        }

    }

}
//C: \Users\hp\source\repos\Bills_Payment_System\Bills_Payment_System.sln