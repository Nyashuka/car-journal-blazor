
using CarJournal.Domain;

namespace CarJournal.Services.AutoMileageCalculator;

public class AverageMileageCalculator : IAverageMileageCalculator
{
    public double Calculate(MileageRecord[] mileages)
    {
        if(mileages.Length < 2)
            return 0;

        double totalAverageMileage = 0;
        int intervalsBetweenMileages = 0;

        for(int i = 1; i < mileages.Length; i++)
        {
            double deltaMileage = mileages[i].Mileage - mileages[i - 1].Mileage;
            double daysBetweenRecords = (mileages[i].UpdatedAt - mileages[i - 1].UpdatedAt).TotalDays;

            totalAverageMileage += deltaMileage / daysBetweenRecords;
            intervalsBetweenMileages++;
        }

        return totalAverageMileage / intervalsBetweenMileages;
    }
}