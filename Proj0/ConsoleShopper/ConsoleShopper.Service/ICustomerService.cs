using ConsoleShopper.Domain;

namespace ConsoleShopper.Service
{
    public interface ICustomerService
    {
        Customer GetCustomerId(int id);
    }
}