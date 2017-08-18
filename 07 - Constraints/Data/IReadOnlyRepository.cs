using System;
using System.Linq;

namespace DataManager
{
    //<out T> : Covariant
    //Delegados, interfaces
    //TODO: 04 - Agrego parametro de covarianza
    public interface IReadOnlyRepository<out T> : IDisposable
    {
        T FindById(int id);
        IQueryable<T> FindAll();
    }
}
