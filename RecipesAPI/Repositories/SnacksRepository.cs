using Microsoft.EntityFrameworkCore;
using SnackyAPI.Models.Database;

namespace SnackyAPI.Repositories
{
    public class SnacksRepository(SnackyDbContext dbContext) : ISnacksRepository
    {
        private readonly SnackyDbContext _dbContext = dbContext;

        public async Task<Snack> CreateSnack(Snack snack)
        {
            _dbContext.Snacks.Add(snack);
            await _dbContext.SaveChangesAsync();
            return snack;
        }

        public Task<Snack?> GetSnack(int id)
            => _dbContext.Snacks.SingleOrDefaultAsync(sn => sn.Id == id);

        public Task<List<Snack>> GetSnacks()
            => _dbContext.Snacks.ToListAsync();
    }

    public interface ISnacksRepository
    {
        Task<List<Snack>> GetSnacks();

        Task<Snack?> GetSnack(int id);

        Task<Snack> CreateSnack(Snack snack);
    }
}
