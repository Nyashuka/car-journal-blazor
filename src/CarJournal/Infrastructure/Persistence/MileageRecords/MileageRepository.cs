
using CarJournal.Domain;

using Microsoft.EntityFrameworkCore;

namespace CarJournal.Infrastructure.Persistence.MileageRecords;

public class MileageRepository : IMileageRepository
{
    private readonly CarJournalDbContext _dbContext;

    public MileageRepository(CarJournalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(MileageRecord mileage)
    {
        _dbContext.MileageRecords.Add(mileage);

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var recordToDelete = await GetByIdAsync(id);

        if(recordToDelete == null)
            throw new Exception("Mileage Record with given id is not exist");

        _dbContext.MileageRecords.Remove(recordToDelete);
    }

    public async Task<List<MileageRecord>> GetAllAsync(int userCarId)
    {
        return await _dbContext.MileageRecords.Where(mr => mr.UserCarId == userCarId).ToListAsync();
    }

    public async Task<MileageRecord?> GetByIdAsync(int id)
    {
        return await _dbContext.MileageRecords.FirstOrDefaultAsync(mr => mr.Id == id);
    }

    public async Task UpdateAsync(MileageRecord mileage)
    {
        _dbContext.MileageRecords.Update(mileage);

        await _dbContext.SaveChangesAsync();
    }
}