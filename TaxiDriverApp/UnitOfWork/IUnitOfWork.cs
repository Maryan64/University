using Entity_Framework__Repository__UnitOfWork.DataTypes;
using Entity_Framework__Repository__UnitOfWork.Repository;

namespace Entity_Framework__Repository__UnitOfWork.UnitOfWorkNS
{
    public interface IUnitOfWork
    {
        GenericRepository<TaxiClient> Clients { get; }
        GenericRepository<TaxiDriver> Drivers { get; }
        GenericRepository<TaxiOrder> Orders { get; }
    }
}
