using CarJournal.Domain;

namespace CarJournal.Infrastructure.Persistence.FuelTypes;

public static class FuelTypeCollection
{
    public static Dictionary<FuelTypeEnum, FuelType> FuelTypes =
        new Dictionary<FuelTypeEnum, FuelType>()
        {
            {
                FuelTypeEnum.Gasoline,
                new FuelType(1, "Gasoline")
            },
            {
                FuelTypeEnum.Diesel,
                new FuelType(2, "Diesel")
            }
        };
}