using CarJournal.Domain;

namespace CarJournal.Services.AutoMileageCalculator;

public interface IAverageMileageCalculator
{
    double Calculate(MileageRecord[] mileages);
}