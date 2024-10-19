

using System.Runtime.CompilerServices;
using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;

namespace CarJournal.Infrastructure.Persistence.Trackings;

public class TrackingsRepository : ITrackingsRepository
{
    private readonly IDbContextFactory<CarJournalDbContext> _factory;

    public TrackingsRepository(IDbContextFactory<CarJournalDbContext> factory)
    {
        _factory = factory;
    }

    public async Task AddAsync(Tracking tracking)
    {
        using(var context = _factory.CreateDbContext())
        {
            context.Trackings.Add(tracking);
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        using(var context = _factory.CreateDbContext())
        {
            if ((await GetByIdAsync(id)) is Tracking tracking)
            {
                context.Trackings.Remove(tracking);
            }
        }
    }

    public async Task<List<Tracking>> GetAllByCarIdAsync(int carId, TrackingType? type)
    {
        using(var context = _factory.CreateDbContext())
        {
            return await context.Trackings
                .Where(t => t.UserCarId == carId && (type == null ? true : t.TrackingType == type))
                .ToListAsync();
        }
    }

    public async Task<Tracking?> GetByIdAsync(int id)
    {
        using(var context = _factory.CreateDbContext())
        {
            return await context.Trackings.FirstOrDefaultAsync(t => t.Id == id);
        }
    }

    public async Task<List<Tracking>> GetByParameters(TrackingType? type)
    {
        using(var context = _factory.CreateDbContext())
        {
            return await context.Trackings
                .Where(t => t.TrackingType == type)
                .Include(t => t.UserCar)
                .ThenInclude(uc => uc.User)
                .ToListAsync();
        }
    }

    public async Task UpdateAsync(Tracking tracking)
    {
        var trackingToUpdate = await GetByIdAsync(tracking.Id);

        if(trackingToUpdate == null)
            return;

        using (var context = _factory.CreateDbContext())
        {
            trackingToUpdate.UpdateMileage(Convert.ToInt32(tracking.TotalMileage));

            context.Trackings.Update(trackingToUpdate);
            await context.SaveChangesAsync();
        }
    }
}