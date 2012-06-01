using System;

namespace cqrs7.utilities.Interfaces
{
    public interface IRepository<T> where T: ReservationItem 
    {
        T GetById(Guid id);
        void Save(ReservationItem  aggregate);
    }
}