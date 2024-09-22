using CarJournal.Domain;

namespace CarJournal.Pages;

public interface ISearchCarComponents
{
    Task<IEnumerable<Vendor>> SearchVendor(string value, CancellationToken token);

    Task<IEnumerable<Gearbox>> SearchGearbox(string value, CancellationToken token);

    Task<IEnumerable<FuelType>> SearchFuelType(string value, CancellationToken token);

    Task<IEnumerable<BodyType>> SearchBodyType(string value, CancellationToken token);
    Task<IEnumerable<Engine>> SearchEngine(string value, CancellationToken token);
}