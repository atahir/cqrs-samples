using System;

namespace cqrs6.utilities.Interfaces
{
    public interface IRepository<T> where T: ReservationItem 
    {
        T GetById(Guid id);
        void Save(ReservationItem  aggregate);
    }
}