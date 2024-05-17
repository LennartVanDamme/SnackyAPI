using SnackyAPI.Models.Database;
using SnackyAPI.Repositories;

namespace SnackyAPI.Services
{
    public class SnacksService(ISnacksRepository recipesRepositry) : ISnacksService
    {
        private readonly ISnacksRepository _recipesRepositry = recipesRepositry;

        public Task<List<Snack>> GetAll()
            => _recipesRepositry.GetSnacks();

        public Task<Snack?> GetById(int id)
        {
            return _recipesRepositry.GetSnack(id);
        }

        public async Task<Snack> AddSnack(Snack snack)
            => await _recipesRepositry.CreateSnack(snack);
        
    }

    public interface ISnacksService
    {
        Task<List<Snack>> GetAll();

        Task<Snack?> GetById(int id);

        Task<Snack> AddSnack(Snack snack);
    }
}
