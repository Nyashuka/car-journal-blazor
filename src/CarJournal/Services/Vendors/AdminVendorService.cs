using CarJournal.Domain;
using CarJournal.Infrastructure.Persistence.Vendors;

namespace CarJournal.Services.Vendors;

public class AdminVendorService : IAdminVendorService
{
    private readonly IVendorRepository _vendorRepository;

    public AdminVendorService(IVendorRepository vendorRepository)
    {
        _vendorRepository = vendorRepository;
    }

    public VendorResult CreateVendor(string name)
    {
        var vendor = new Vendor(0, name);

        _vendorRepository.Add(vendor);

        return new VendorResult(vendor.Id, vendor.Name);
    }

    public void DeleteVendor(int id)
    {
        throw new NotImplementedException();
    }

    public VendorResult EditVendor(int id, string name)
    {
        if(_vendorRepository.GetById(id) is not Vendor vendor)
        {
            throw new Exception("Vendor with given id is not exists");
        }

        throw new NotImplementedException();
    }
}