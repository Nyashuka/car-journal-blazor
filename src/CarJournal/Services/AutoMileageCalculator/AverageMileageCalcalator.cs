
using CarJournal.Domain;

namespace CarJournal.Services.AutoMileageCalculator;

public class AverageMileageCalculator : IAverageMileageCalculator
{
    public double Calculate(List<MileageRecord> mileages)
    {
        if(mileages.Count < 2)
            return 0;

        var sortedMileagesArray = mileages
            .OrderBy(m => m.UpdatedAt)
            .ToArray();

        double totalAverageMileage = 0;
        int intervalsBetweenMileages = 0;

        for(int i = 1; i < sortedMileagesArray.Length; i++)
        {
            double deltaMileage = sortedMileagesArray[i].Mileage - sortedMileagesArray[i - 1].Mileage;
            double daysBetweenRecords = (sortedMileagesArray[i].UpdatedAt - sortedMileagesArray[i - 1].UpdatedAt).TotalDays;

            totalAverageMileage += deltaMileage / daysBetweenRecords;
            intervalsBetweenMileages++;
        }

        return totalAverageMileage / intervalsBetweenMileages;
    }
}