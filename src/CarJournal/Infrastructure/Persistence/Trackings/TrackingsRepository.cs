

using System.Runtime.CompilerServices;
using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;

namespace CarJournal.Infrastructure.Persistence.Trackings;

public class TrackingsRepository : ITrackingsRepository
{
    private readonly CarJournalDbContext _dbContext;

    public TrackingsRepository(CarJournalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task AddAsync(Tracking tracking)
    {
        _dbContext.Trackings.Add(tracking);
        _dbContext.SaveChanges();

        return Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        if((await GetByIdAsync(id)) is Tracking tracking)
        {
            _dbContext.Trackings.Remove(tracking);
        }
    }

    public async Task<List<Tracking>> GetAllByCarIdAsync(int carId)
    {
        return await _dbContext.Trackings.Where(t => t.UserCarId == carId).ToListAsync();
    }

    public async Task<Tracking?> GetByIdAsync(int id)
    {
        return await _dbContext.Trackings.FirstOrDefaultAsync(t => t.Id == id);
    }

    public Task UpdateAsync(Tracking tracking)
    {
        throw new NotImplementedException();
    }
}