namespace CarJournal.Services.Vendors;

public interface IAdminVendorService
{
    VendorResult CreateVendor(string name);
    VendorResult EditVendor(int id, string name);
    void DeleteVendor(int id);
}