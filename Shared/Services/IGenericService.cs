using BPS_Shared.Models;

namespace BPS_Shared.Services
{
    public interface IGenericService<TModel> where     TModel: class
    {
        Task<TModel> CreateAsync(TModel model);

        Task<TModel> UpdateAsync(TModel model);

        Task<bool> DeleteAsync(TModel model);

        Task<List<TModel>> ReadAsync();

       
    }
}
