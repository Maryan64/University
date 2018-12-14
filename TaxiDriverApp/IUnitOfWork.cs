using TaxiDriverApp.DataTypes;
using TaxiDriverApp.Repository;

namespace TaxiDriverApp.UnitOfWorkNS
{
    public interface IUnitOfWork
    {
        GenericRepository<TaxiClient> Clients { get; }
        GenericRepository<TaxiDriver> Drivers { get; }
        GenericRepository<TaxiOrder> Orders { get; }
    }
}
